extern crate crypto;

use crypto::aes::{self, KeySize};
use std::fs::File;
use std::io::{Read, Write};
use rand::Rng;

fn encrypt_file(input_path: &str, output_path: &str, key: &[u8], iv: &[u8]) -> Result<(), Box<dyn std::error::Error>> {
    let mut input_file = File::open(input_path)?;
    let mut output_file = File::create(output_path)?;

    let mut encryptor = aes::ctr(KeySize::KeySize256, key, iv);

    let mut buffer = vec![0; 4096];
    let mut buffer_copy = buffer.clone();

    let mut buffer_out = [0u8; 4096];

    loop {
        let result = input_file.read(&mut buffer)?;
        if result == 0 {
            break;
        }
        buffer_copy[..result].copy_from_slice(&buffer[..result]);
        encryptor.process(&mut buffer_copy, &mut buffer_out);
        output_file.write_all(&buffer_out[..result])?;
    }

    Ok(())
}

fn decrypt_file(input_path: &str, output_path: &str, key: &[u8], iv: &[u8]) -> Result<(), Box<dyn std::error::Error>> {
    let mut input_file = File::open(input_path)?;
    let mut output_file = File::create(output_path)?;

    let mut decryptor = aes::ctr(KeySize::KeySize256, key, iv);
    let mut buffer = [0; 4096];
    let mut buffer_out = [0u8; 4096];

    loop {
        let result = input_file.read(&mut buffer)?;
        if result == 0 {
            break;
        }
        decryptor.process(&mut buffer, &mut buffer_out);
        output_file.write_all(&buffer_out[..result])?;
    }

    Ok(())
}

fn generate_random_key_iv() -> ([u8; 32], [u8; 16]) {
    let mut rng = rand::thread_rng();
    let mut key = [0u8; 32];
    let mut iv = [0u8; 16];
    rng.fill(&mut key);
    rng.fill(&mut iv);
    (key, iv)
}

fn main() -> Result<(), Box<dyn std::error::Error>> {
    let (key, iv) = generate_random_key_iv();

    let key = b"fd91a45632c798e415cb632aa37b4c9e3cc3f76a2272cbcfabe5d6d0551e3a90"; // 64 bytes (512 bits)
    let iv = b"de6a91487fbb20cc7420aa42b92d7df3"; // 32 bytes (256 bits)

    encrypt_file("input.txt", "encrypted.txt", key, iv)?;
    decrypt_file("encrypted.txt", "decrypted.txt", key, iv)?;

    Ok(())
}