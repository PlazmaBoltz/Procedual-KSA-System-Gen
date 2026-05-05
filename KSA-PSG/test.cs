using KSA_PSG;
using System;

var generator = new KSA_PSG.KSA_PSG_Functions();
var seed = Random.Shared.Next();
for (int i = 0; i < 100; i++)
{
    Console.WriteLine(generator.GenerateSystemName(seed+i));
}