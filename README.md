# TrucUtileEnToutGenre

Voici un exemple de regex qui peut être utilisé pour valider un chemin d'accès Windows : <br>
<br>
" ^([a-zA-Z]\:|\\)(\\[^<>:"/\\|?*]+)+\\?$ "<br>
<br>
Voici un exemple de regex qui peut être utilisé pour diviser une URL en ses différentes parties en C# :<br>
<br>
" ^(https?:\/\/)?([\da-z\.-]+)\.([a-z\.]{2,6})([\/\w \.-]*)*\/?$ "<br>
<br>
Detect VM with c# <br>
```csharp
DateTime t1 = DateTime.Now;
Sleep(5000);
double t2 = DateTime.Now.Subtract(t1).TotalSeconds;
if(t2<4.5){
    Console.WriteLine("vm detected.");
    return;
}
```
<br>
Detect VM by memory allocation with c# <br>

```csharp
using System.Runtime.InteropServices;

[DllImport("kernel32.dll", SetLastError = true, ExactSpelling =true)]
static extern IntPtr VirtualAllocExNuma(IntPtr hProcess, IntPtr lpAddress, uint dwSize, UInt32 flAllocationType, UInt32 flProtect, UInt32 nndPreferred);
[DllImport("kernel32.dll")]
static extern IntPtr GetCurrentProcess();
        
IntPtr mem = VirtualAllocExNuma(GetCurrentProcess(), IntPtr.Zero, 0x1000, 0x3000, 0x4, 0);
if(mem == null){
    Console.WriteLine("vm detected.");
    return;
}
```
<br>
dotnet publish -p:PublishSingleFile=true -r win-x64 -c Release --self-contained true -p:PublishTrimmed=true
