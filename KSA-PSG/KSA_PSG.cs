namespace KSA_PSG;

using KSA;
using Brutal;

public class KSA_PSG_Functions
{
    private String[] starTypes = new String[] { "Red Dwarf", "Yellow Dwarf", "Blue Giant", "White Dwarf", "Neutron Star", "Brown Dwarf", "Black Hole", "Red Giant", "Rogue", "Class B", "Pulsar" };
    private String[] binaryTypes = new String[] { "Neutron Star", "Blue Giant","Blue Giant", "Black Hole", "Class B", "Class B", "Class B", "Class B" };
    private String[] trinaryTypes = new String[] { "Red Dwarf", "Yellow Dwarf", "Blue Giant", "Black Hole", "Neutron Star", "Red Giant", "Class B" };
    private String[] uniarySmallTypes = new String[] { "Red Dwarf", "Yellow Dwarf", "Brown Dwarf"};
    private String[] youngTypes = new String[] { "Red Dwarf", "Yellow Dwarf"};
    private String[] deadSystemTypes = new String[] { "White Dwarf", "Neutron Star" };
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
        public override string ToString()
        {
            return $"System Name: {name}, Type: {type}, Stars: {stars.Length}, Planets: {(planets != null ? planets.Length : 0)}\nStars:\n{string.Join("\n", stars)}\nPlanets:\n{(planets != null ? string.Join("\n", planets) : "None")}";
        }
    }
    public class Star
    {
        public required String name;
        public required String type;
        public required double radius;
        public required double luminosity;
        public required double mass;
        public override string ToString()
        {
            return $"Star Name: {name}, Type: {type}, Radius: {radius*696340} km, Luminosity: {luminosity} L☉, Mass: {mass} M☉";
        }
    }
    public class Planet
    {
        public required String name;
        public required String type;
        public required double radius;
        public required double mass;
        public required (double, double) terrain;
        public required double apoapsis;
        public required double periapsis;
        public required double inclination;
        public required double eccentricity;
        public required double ascendingNode;
        public required Star parent;
        public Moon[]? moons;
        public override string ToString()
        {
            return $"Planet Name: {name}, Type: {type}, Radius: {radius} km, Mass: {mass} M⊕, Terrain: ({terrain.Item1}, {terrain.Item2}), Apoapsis: {apoapsis} km, Periapsis: {periapsis} km, Inclination: {inclination}°, Eccentricity: {eccentricity}, Ascending Node: {ascendingNode}°";
        }
    }
    public class Moon
    {
        public required String name;
        public required String type;
        public required int radius;
        public required int mass;
        public required (double, double) terrain;
        public required KSA.Orbit orbit;
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
    public System[] GenerateSystems(int numberOfSystems, int seed)
    {
        var rand = new Random(seed);
        var Systems = new System[numberOfSystems];
        for (int i = 0; i < numberOfSystems; i++)
        {
            Systems[i] = GenerateSystem(systemTypes[rand.Next(systemTypes.Length)], seed+i, i);
        }
        return Systems;
    }
    public System GenerateSystem(String type, int seed, int index = 0)
    {
        var rand = new Random(seed);
        var numberOfStars = 1;
        var stars = new Star[0];
        if (type == "Binary")
        {
            numberOfStars = 2;
            var Star1 = GenerateStar(type, seed,0);
            var Star2 = GenerateStar(type, seed,1);
            var planetCount1 = rand.Next(2,6);
            stars = new Star[numberOfStars];
            stars[0] = Star1;
            stars[1] = Star2;
        }
        else if (type == "Trinary")
        {
            numberOfStars = 3;
            var Star1 = GenerateStar(type, seed,0);
            var Star2 = GenerateStar(type, seed,1);
            var Star3 = GenerateStar(type, seed,2);
            stars = new Star[numberOfStars];
            stars[0] = Star1;
            stars[1] = Star2;
            stars[2] = Star3;
            var planetCount1 = rand.Next(1,4);
        }
        else if (type == "Binary-Uniary")
        {
            numberOfStars = 3;
            var Star1 = GenerateStar("Binary", seed,0);
            var Star2 = GenerateStar("Binary", seed,1);
            var Star3 = GenerateStar("Uniary-Small", seed,2);
            var planetCount1 = rand.Next(1,4);
            var planetCount2 = rand.Next(1,4);
            stars = new Star[numberOfStars];
            stars[0] = Star1;
            stars[1] = Star2;
            stars[2] = Star3;
        }
        else if (type == "Independent-Binary")
        {
            numberOfStars = 2;
            var Star1 = GenerateStar("Uniary", seed,0);
            var Star2 = GenerateStar("Uniary-Small", seed,1);
            var planetCount1 = rand.Next(1,4);
            var planetCount2 = rand.Next(1,4);
            stars = new Star[numberOfStars];
            stars[0] = Star1;
            stars[1] = Star2;
        }
        else if (type == "Pulsar")
        {
            numberOfStars = 1;
            var Star1 = GenerateStar("Pulsar", seed);
            var planetCount1 = rand.Next(0,3);
            stars = new Star[numberOfStars];
            stars[0] = Star1;
        }
        else if (type == "Black Hole")
        {
            numberOfStars = 1;
            var Star1 = GenerateStar("Black Hole", seed);
            var planetCount1 = rand.Next(0,3);
            stars = new Star[numberOfStars];
            stars[0] = Star1;
        }
        else if (type == "Dead System")
        {
            numberOfStars = 1;
            var Star1 = GenerateStar("Dead System", seed);
            var planetCount1 = rand.Next(2,5);
            stars = new Star[numberOfStars];
            stars[0] = Star1;
        }
        else if (type == "Young System")
        {
            numberOfStars = 1;
            var Star1 = GenerateStar("Young System", seed);
            var planetCount1 = rand.Next(6,10);
            stars = new Star[numberOfStars];
            stars[0] = Star1;
        }
        else if (type == "Red Giant")
        {
            numberOfStars = 1;
            var Star1 = GenerateStar("Red Giant", seed);
            var planetCount1 = rand.Next(0,2);
            stars = new Star[numberOfStars];
            stars[0] = Star1;
        }
        else
        {
            numberOfStars = 1;
            var Star1 = GenerateStar("Uniary", seed);
            var planetCount1 = rand.Next(3,9);
            stars = new Star[numberOfStars];
            stars[0] = Star1;
        }
        var system = new System() { name = GenerateSystemName(seed), type = type, stars = stars };
        return system;
    }
    public Star GenerateStar(String type, int seed, int index = 0)
    {
        var star = new Star() { name = "", type = "", radius = 0, luminosity = 0.0, mass = 0.0 };
        var Random = new Random(seed);
        if (type == "Binary")
        {
            star = new Star() { name = GenerateSystemName(seed) + " " + letters[index], type = binaryTypes[new Random(seed+index).Next(binaryTypes.Length)], radius = new Random(seed+index).Next(100000, 1000000), luminosity = new Random(seed+index).NextDouble() * 100, mass = new Random(seed+index).Next(1, 100) };
        }
        else if (type == "Trinary")
        {
            star = new Star() { name = GenerateSystemName(seed) + " " + letters[index], type = trinaryTypes[new Random(seed+index).Next(trinaryTypes.Length)], radius = new Random(seed+index).Next(100000, 1000000), luminosity = new Random(seed+index).NextDouble() * 100, mass = new Random(seed+index).Next(1, 100) };
        }
        else if (type == "Uniary-Small")
        {
            star = new Star() { name = GenerateSystemName(seed) + " " + letters[index], type = uniarySmallTypes[new Random(seed+index).Next(uniarySmallTypes.Length)], radius = new Random(seed+index).Next(50000, 500000), luminosity = new Random(seed+index).NextDouble() * 50, mass = new Random(seed+index).Next(1, 50) };
        }
        else if (type == "Uniary")
        {
            star = new Star() { name = GenerateSystemName(seed) + " " + letters[index], type = starTypes[new Random(seed+index).Next(starTypes.Length)], radius = new Random(seed+index).Next(100000, 1000000), luminosity = new Random(seed+index).NextDouble() * 100, mass = new Random(seed+index).Next(1, 100) };
        }
        else if (type == "Pulsar")
        {
            star = new Star() { name = GenerateSystemName(seed) + " " + letters[index], type = "Pulsar", radius = new Random(seed+index).Next(10000, 50000), luminosity = new Random(seed+index).NextDouble() * 10, mass = new Random(seed+index).Next(1, 10) };
        }
        else if (type == "Black Hole")
        {
            star = new Star() { name = GenerateSystemName(seed) + " " + letters[index], type = "Black Hole", radius = new Random(seed+index).Next(5000, 20000), luminosity = 0, mass = new Random(seed+index).Next(10, 50) };
        }
        else if (type == "Dead System")
        {
            star = new Star() { name = GenerateSystemName(seed) + " " + letters[index], type = deadSystemTypes[new Random(seed+index).Next(deadSystemTypes.Length)], radius = new Random(seed+index).Next(50000, 500000), luminosity = 0, mass = new Random(seed+index).Next(1, 50) };
        }
        else
        {
            star = new Star() { name = GenerateSystemName(seed) + " " + letters[index], type = starTypes[new Random(seed+index).Next(starTypes.Length)], radius = new Random(seed+index).Next(100000, 1000000), luminosity = new Random(seed+index).NextDouble() * 100, mass = new Random(seed+index).Next(1, 100) };
        }
        if (star.type == "Black Hole")
        {
            star.mass = new Random(seed+index).Next(10, 50);
            star.radius = double.Parse((new Random(seed+index).Next(5000, 20000) * 0.0000021110377).ToString());
            star.luminosity = 0.05 * star.mass;

        }
        else if (star.type == "Neutron Star")
        {
            star.mass = new Random(seed+index).Next(1, 10)*0.1;
            star.radius = double.Parse((new Random(seed+index).Next(10000, 50000) * 0.0001).ToString());
            star.luminosity = 0.1 * star.mass;
        }
        else if (star.type == "White Dwarf")
        {
            star.mass = new Random(seed+index).Next(1, 50)*0.005;
            star.radius = double.Parse((new Random(seed+index).Next(5000, 50000) * 0.00001).ToString());
            star.luminosity = 0.01 * star.mass;
        }
        else if (star.type == "Red Giant")
        {
            star.mass = new Random(seed+index).Next(1, 100);
            star.radius = new Random(seed+index).Next(100, 1000);
            star.luminosity = 100 * star.mass;
        }
        else if (star.type == "Blue Giant")
        {
            star.mass = new Random(seed+index).Next(10, 300);
            star.radius = new Random(seed+index).Next(100, 1000);
            star.luminosity = 1000 * star.mass;
        }
        else if (star.type == "Yellow Dwarf")
        {
            star.mass = new Random(seed+index).Next(10, 50)*0.05;
            star.radius = new Random(seed+index).Next(10, 50)*0.05;
            star.luminosity = 1 * star.mass;
        }
        else if (star.type == "Red Dwarf")
        {
            star.mass = new Random(seed+index).Next(1, 10)*0.1;
            star.radius = new Random(seed+index).Next(1, 10)*0.1;
            star.luminosity = 0.5 * star.mass;
        }
        else if (star.type == "Brown Dwarf")
        {
            star.mass = new Random(seed+index).Next(1, 10)*0.005;
            star.radius = new Random(seed+index).Next(50000, 500000)*0.0000001;
            star.luminosity = 0.005 * star.mass;
        }
        else if (star.type == "Rogue")
        {
            star.mass = new Random(seed+index).Next(1, 10)*0.00005;
            star.radius = new Random(seed+index).Next(1, 10)*0.00001;
            star.luminosity = 0;
        }
        else if (star.type == "Class B")
        {
            star.mass = new Random(seed+index).Next(10, 50)*0.075;
            star.radius = new Random(seed+index).Next(10, 50)*0.075;
            star.luminosity = 5 * star.mass;
        }
        else if (star.type == "Pulsar")
        {
            star.mass = new Random(seed+index).Next(1, 10)*0.1;
            star.radius = double.Parse((new Random(seed+index).Next(10000, 50000) * 0.0001).ToString());
            star.luminosity = 1 * star.mass;
        }
        else
        {
            star.mass = new Random(seed+index).Next(1, 100);
            star.radius = new Random(seed+index).Next(100, 500); 
            star.luminosity = 1 * star.mass;
        }
        return star;
    }
    public Planet GeneratePlanet(String type, String parentType, Star parent, int seed, int index = 0)
    {
        var planet = new Planet() { name = "", type = "", radius = 0, mass = 0, terrain = (0, 0), apoapsis = 0, periapsis = 0, inclination = 0, eccentricity = 0, ascendingNode = 0, parent = parent };
        var Random = new Random(seed);
        planet.name =  GenerateSystemName(seed) + " " + lowerCasedLetters[index];
        planet.type = planetTypes[new Random(seed+index).Next(planetTypes.Length)];
        planet.radius = new Random(seed+index).Next(2000, 10000);
        planet.mass = new Random(seed+index).Next(1, 1000);
        planet.terrain = (new Random(seed+index).NextDouble()*-0.005*planet.radius, new Random(seed+index).NextDouble()*0.01*planet.radius);
        planet.apoapsis = new Random(seed+index).Next(int.Parse(Math.Round(parent.radius*1.5+(parent.radius*Math.Sqrt(index))).ToString()), int.Parse(Math.Round(parent.radius*1.5+(parent.radius*Math.Sqrt(index))).ToString())*3);
        planet.periapsis = new Random(seed^2+index).Next(int.Parse(Math.Round(parent.radius*1.5+(parent.radius*Math.Sqrt(index))).ToString()), int.Parse(Math.Round(parent.radius*1.5+(parent.radius*Math.Sqrt(index))).ToString())*3);
        planet.inclination = new Random(seed+index).NextDouble() * Math.Abs(Math.Log2(planet.mass)) + new Random(seed+index).NextDouble() * Math.Log10(planet.apoapsis);
        planet.eccentricity = Math.Abs((planet.apoapsis - planet.periapsis) / (planet.apoapsis + planet.periapsis));
        planet.ascendingNode = new Random(seed+index).NextDouble() * 360;
        return planet;
    }
}
