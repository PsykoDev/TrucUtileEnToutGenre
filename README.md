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
dotnet publish -p:PublishSingleFile=true -r win-x64 -c Release --self-contained true -p:PublishTrimmed=true<br>
<br>
Adresses e-mail   <br>  
^[\w\.=-]+@[\w\.-]+\.[\w]{2,3}$	    T.Simpson@netwrix.com<br><br>
Numéros de sécurité sociale américains	 <br>   
\b(?!000|666|9\d{2})([0-8]\d{2}|7([0-6]\d))([-]?|\s{1})(?!00)\d\d\2(?!0000)\d{4}\b	    513-84-7329<br><br>
Adresses IPV4	 <br>   
^\d{1,3}[.]\d{1,3}[.]\d{1,3}[.]\d{1,3}$	    192.168.1.1<br><br>
Dates au format MM/JJ/AAAA	<br>
^([1][12]|[0]?[1-9])[\/-]([3][01]|[12]\d|[0]?[1-9])[\/-](\d{4}|\d{2})$	05/05/2018<br><br>
Numéros de cartes Mastercard<br>	
^(?:5[1-5][0-9]{2}|222[1-9]|22[3-9][0-9]|2[3-6][0-9]{2}|27[01][0-9]|2720)[0-9]{12}$	5258704108753590<br><br>
Numéros de cartes Visa	<br>
\b([4]\d{3}[\s]\d{4}[\s]\d{4}[\s]\d{4}|[4]\d{3}[-]\d{4}[-]\d{4}[-]\d{4}|[4]\d{3}[.]\d{4}[.]\d{4}[.]\d{4}|[4]\d{3}\d{4}\d{4}\d{4})\b 4563-7568-5698-4587<br><br>
Numéros de cartes American Express	<br>
^3[47][0-9]{13}$	34583547858682157<br><br>
Codes ZIP US	<br>
^((\d{5}-\d{4})|(\d{5})|([A-Z]\d[A-Z]\s\d[A-Z]\d))$	97589<br><br>
Chemins d’accès à des fichiers	<br>
\\[^\\]+$	\\fs1\shared<br><br>
URL	<br>
(?i)\b((?:[a-z][\w-]+:(?:\/{1,3}|[a-z0-9%])|www\d{0,3}[.]|[a-z0-9.\-]+[.][a-z]{2,4}\/)(?:[^\s()<>]+|\(([^\s()<>]+|(\([^\s()<>]+\)))*\))+(?:\(([^\s()<>]+|(\([^\s()<>]+\)))*\)|[^\s`!()\[\]{};:'".,<>?«»“”‘’]))	www.netwrix.com<br>
<br><br>
