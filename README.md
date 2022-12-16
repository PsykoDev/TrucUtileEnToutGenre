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
