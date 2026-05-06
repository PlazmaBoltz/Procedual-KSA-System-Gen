using KSA_PSG;
using System;

var generator = new KSA_PSG.KSA_PSG_Functions();
var seed = Random.Shared.Next();
for (int i = 0; i < 10; i++)
{
    Console.WriteLine(generator.GenerateSystemName(seed+i));
    Console.WriteLine(generator.GenerateStar("Binary", seed+i, 0));
    Console.WriteLine(generator.GenerateStar("Trinary", seed+i, 0));
    Console.WriteLine(generator.GenerateStar("Uniary", seed+i, 0));
    Console.WriteLine(generator.GenerateStar("Uniary-Small", seed+i, 0));
    Console.WriteLine(generator.GenerateStar("Young System", seed+i, 0));

    Console.WriteLine(generator.GenerateSystem("Binary-Uniary", seed+i, 0));
}