namespace KSA_PSG;

using KSA;
using Brutal;

public class KSA_PSG_Functions
{
    private String[] starTypes = new String[] { "Red Dwarf", "Yellow Dwarf", "Blue Giant", "White Dwarf", "Neutron Star", "Brown Dwarf", "Black Hole", "Red Giant", "Rogue" };
    private String[] systemTypes = new String[] { "Binary", "Trinary", "Uniary", "Binary-Uniary", "Independent-Binary", "Pulsar", "Black Hole", "Dead System", "Young System", "Red Giant"};
    private String[] planetTypes = new String[] { "Barren", "Super-Earth", "Cold Jupiter", "Hot Jupiter", "Mini-Neptune", "Neptune", "Terra", "Lava", "Volcanic", "Desert", "Venus", "Basaltic", "Dead World", "Dwarf", "Astroid", "KBO", "Underground-Ocean", "Gaia", "Ocean World", "Gas Giant", "Artificial", "Abandoned", "Comet" };
    private String[] moonTypes = new string[] {"Dwarf", "Barren", "Volcanic", "Ice", "Ocean", "Terra", "Artificial", "Abandoned", "Dwarf"};
    private String[] systemPrefix = new string[] { "Alpha", "Beta", "Gamma", "Delta", "Epsilon", "Zeta", "Eta", "Theta", "Iota", "Kappa", "Lambda", "Mu", "Nu", "Xi", "Omicron", "Pi", "Rho", "Sigma", "Tau", "Upsilon", "Phi", "Chi", "Psi", "Omega", "Krieg", "Kiwi", "Kosmina" };
    private String[] systemSuffix = new string[] { "Prime", "Secundus", "Tertius", "Quartus", "Quintus", "Sextus", "Septimus", "Octavus", "Nonus", "Decimus", "" };
    private String[] systemNumericPrefix = new string[] { "Kipler", "Gliese", "Ross", "Luyten", "Barnard", "Tiger", "Lacaille", "Struve", "Giclas", "Kapteyn", "Lalande", "van Biesbroeck", "WISE", "2KAT", "SSD", "Tomservo", "Hunter", "Polaris", "Banjo", "AMPW", "Lowne", "Hall", "Manley", "Jebadiah", "Klass"};
    private String[] systemName = new string[] { "Andromeda", "Centauri", "Sirius", "Vega", "Altair", "Procyon", "Betelgeuse", "Rigel", "Aldebaran", "Spica", "Antares", "Pollux", "Fomalhaut", "Deneb", "Regulus", "Castor", "Arcturus", "Capella", "Bellatrix", "Alnitak", "Chitak", "Shark", "Daishi", "Linx" };
    private String[] letters = new string[] { "A", "B", "C", "D", "E" };
    private String[] lowerCasedLetters = new string[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
    private String[] romanNumerals = new string[] { "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX", "X", "XI", "XII", "XIII", "XIV", "XV", "XVI", "XVII", "XVIII", "XIX", "XX", "XXI", "XXII", "XXIII", "XXIV", "XXV", "XXVI", "XXVII", "XXVIII", "XXIX", "XXX" };
    public System[] systems = new System[0];
    public class System
    {
        public required String name;
        public required String type;
        public required Star[] stars;
        public Planet[]? planets;
    }
    public class Star
    {
        public required String name;
        public required String type;
        public required int radius;
        public required double luminosity;
        public required int mass;
    }
    public class Planet
    {
        public required String name;
        public  required String type;
        public Moon[]? moons;
    }
    public class Moon
    {
        public required String name;
        public required String type;
    }
    public string GenerateSystemName(int seed)
    {
        var tempRand = new Random(seed).Next(2);
        var tempRand2 = new Random(seed);

        if (tempRand == 0)
        {
            return systemPrefix[tempRand2.Next(systemPrefix.Length)] + " " + systemName[tempRand2.Next(systemName.Length)];
        }
        else
        {
            return systemNumericPrefix[tempRand2.Next(systemNumericPrefix.Length)] + "-" + tempRand2.Next(1000);
        }
    }
    public void GenerateSystems(int numberOfSystems, int seed)
    {
        var rand = new Random(seed);
        for (int i = 0; i < numberOfSystems; i++)
        {
            GenerateSystem(systemTypes[rand.Next(systemTypes.Length)], seed+i);
        }
    }
    public void GenerateSystem(String type, int seed)
    {
        var rand = new Random(seed);
        var numberOfStars = 1;
        if (type == "Binary")
        {
            var Star1 = GenerateStar(type, seed);
            var Star2 = GenerateStar(type, seed);
            var planetCount1 = rand.Next(2,6);
        }
        else if (type == "Trinary")
        {
            var Star1 = GenerateStar(type, seed);
            var Star2 = GenerateStar(type, seed);
            var Star3 = GenerateStar(type, seed);
            var planetCount1 = rand.Next(1,4);
        }
        else if (type == "Binary-Uniary")
        {
            var Star1 = GenerateStar("Binary", seed);
            var Star2 = GenerateStar("Binary", seed);
            var Star3 = GenerateStar("Uniary-Small", seed);
            var planetCount1 = rand.Next(1,4);
            var planetCount2 = rand.Next(1,4);
        }
        else if (type == "Independent-Binary")
        {
            var Star1 = GenerateStar("Uniary", seed);
            var Star2 = GenerateStar("Uniary-Small", seed);
            var planetCount1 = rand.Next(1,4);
            var planetCount2 = rand.Next(1,4);
        }
        else if (type == "Pulsar")
        {
            var Star1 = GenerateStar("Pulsar", seed);
            var planetCount1 = rand.Next(0,3);
        }
        else if (type == "Black Hole")
        {
            var Star1 = GenerateStar("Black Hole", seed);
            var planetCount1 = rand.Next(0,3);
        }
        else if (type == "Dead System")
        {
            var Star1 = GenerateStar("Dead System", seed);
            var planetCount1 = rand.Next(2,5);
        }
        else if (type == "Young System")
        {
            var Star1 = GenerateStar("Young System", seed);
            var planetCount1 = rand.Next(6,10);
        }
        else if (type == "Red Giant")
        {
            var Star1 = GenerateStar("Red Giant", seed);
            var planetCount1 = rand.Next(0,2);
        }
        else
        {
            var Star1 = GenerateStar("Uniary", seed);
            var planetCount1 = rand.Next(3,9);
        }
        Star[] stars = new Star[numberOfStars];
        var system = new System() { name = GenerateSystemName(seed), type = type, stars = stars };
    }
    public Star GenerateStar(String type, int seed, int index = 0)
    {
        if (type == "Binary")
        {
            return new Star() { name = GenerateSystemName(seed) + " " + letters[index], type = starTypes[new Random(seed).Next(starTypes.Length)], radius = new Random(seed).Next(100000, 1000000), luminosity = new Random(seed).NextDouble() * 100, mass = new Random(seed).Next(1, 100) };
        }
        else if (type == "Trinary")
        {
            return new Star() { name = GenerateSystemName(seed) + " " + letters[index], type = starTypes[new Random(seed).Next(starTypes.Length)], radius = new Random(seed).Next(100000, 1000000), luminosity = new Random(seed).NextDouble() * 100, mass = new Random(seed).Next(1, 100) };
        }
        else if (type == "Binary-Uniary")
        {
            return new Star() { name = GenerateSystemName(seed) + " " + letters[index], type = starTypes[new Random(seed).Next(starTypes.Length)], radius = new Random(seed).Next(100000, 1000000), luminosity = new Random(seed).NextDouble() * 100, mass = new Random(seed).Next(1, 100) };
        }
        else if (type == "Uniary-Small")
        {
            return new Star() { name = GenerateSystemName(seed) + " " + letters[index], type = starTypes[new Random(seed).Next(starTypes.Length)], radius = new Random(seed).Next(50000, 500000), luminosity = new Random(seed).NextDouble() * 50, mass = new Random(seed).Next(1, 50) };
        }
        else if (type == "Uniary")
        {
            return new Star() { name = GenerateSystemName(seed) + " " + letters[index], type = starTypes[new Random(seed).Next(starTypes.Length)], radius = new Random(seed).Next(100000, 1000000), luminosity = new Random(seed).NextDouble() * 100, mass = new Random(seed).Next(1, 100) };
        }
        else if (type == "Pulsar")
        {
            return new Star() { name = GenerateSystemName(seed) + " " + letters[index], type = "Pulsar", radius = new Random(seed).Next(10000, 50000), luminosity = new Random(seed).NextDouble() * 10, mass = new Random(seed).Next(1, 10) };
        }
        else if (type == "Black Hole")
        {
            return new Star() { name = GenerateSystemName(seed) + " " + letters[index], type = "Black Hole", radius = new Random(seed).Next(5000, 20000), luminosity = 0, mass = new Random(seed).Next(10, 50) };
        }
        else if (type == "Dead System")
        {
            return new Star() { name = GenerateSystemName(seed) + " " + letters[index], type = "Dead System", radius = new Random(seed).Next(50000, 500000), luminosity = 0, mass = new Random(seed).Next(1, 50) };
        }
        else
        {
            return new Star() { name = GenerateSystemName(seed) + " " + letters[index], type = starTypes[new Random(seed).Next(starTypes.Length)], radius = new Random(seed).Next(100000, 1000000), luminosity = new Random(seed).NextDouble() * 100, mass = new Random(seed).Next(1, 100) };
        }
    }
    public void GeneratePlanet(String type, int seed)
    {
        return;
    }
}
