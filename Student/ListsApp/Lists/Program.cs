

using System.Reflection.Metadata;

List <string> bowlers = new List<string>();
bowlers.Add("Squiggy");
bowlers.Add("Pal");
bowlers.Add("Fred");
bowlers.Add("Myra");
bowlers.Add("Michael");

List <int> scores = new List<int>();
scores.Add(100);
scores.Add(120);
scores.Add(150);
scores.Add(175);
scores.Add(200);

scores.Add(120);
scores.Add(140);
scores.Add(160);
scores.Add(180);
scores.Add(200);

scores.Add(150);
scores.Add(116);
scores.Add(170);
scores.Add(180);
scores.Add(200);

for (int game = 0; game < 3; game++)
{
    for (int player = 0; player < bowlers.Count; player++)
    {
        Console.WriteLine($"{bowlers[player]} scored {scores[game*bowlers.Count+player]}");
    }
    Console.WriteLine("\n");
}


string namesString = "Mike,Myra,Matt,Joe,Kris,Dan,Sarah";
List<string> names = namesString.Split(',').ToList();
names.Add("Eilif");
foreach(string name in names)
{
    Console.WriteLine(name);
}   