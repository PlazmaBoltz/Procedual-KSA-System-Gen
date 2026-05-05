namespace KSA_PSG.Mod;

using KSA_PSG;
using StarMap.API;
using KSA;
using System;
using Tomlet;

[StarMapMod]
public class ProcedualMod
{
    [StarMapBeforeGui]
    public void BeforeGui()
    {
        var seed = new Random().Next();
        var generator = new KSA_PSG_Functions();
        System.Console.WriteLine(generator.GenerateSystemName(seed));
    }
}