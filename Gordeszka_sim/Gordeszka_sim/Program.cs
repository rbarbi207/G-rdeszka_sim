using System.ComponentModel.Design;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Transactions;

namespace Gordeszka_sim
{
    internal class Program
    {
        static List<Skater> skaters = new List<Skater>()
        {
            new Skater("Axel Strom", 85),
            new Skater("Blaze Ryder", 70),
            new Skater("Dash Cruz", 90),
            new Skater("Jett Skye", 50),
            new Skater("Ollie Kings", 40)
        };

        static List<Trick> tricks = new List<Trick>()
        {
            new Trick("Ollie", 15, 3, 1),
            new Trick("Tailgrab", 30, 4, 2),
            new Trick("Kickflip", 35, 5, 3),
            new Trick("Pop Shuvit", 40, 5, 2),
            new Trick("Advanced Flip", 45, 7, 4),
            new Trick("Grind", 45, 7, 4),
            new Trick("Heelflip", 50, 6, 3),
            new Trick("Bertleflip", 50, 6, 4),
            new Trick("Smith Grind", 55, 7, 4),
            new Trick("Bigspin", 60, 8, 5),
            new Trick("Fakie Bigspin", 60, 7, 5),
            new Trick("Feeble Grind", 65, 8, 5),
            new Trick("Kickflip McTwist", 70, 10, 6),
            new Trick("Airwalk", 75, 8, 7),
            new Trick("Caballerial", 75, 9, 6),
            new Trick("Hardflip", 80, 9, 7),
            new Trick("360 Flip", 85, 10, 7),
            new Trick("Double Kickflip", 95, 9, 9),
            new Trick("Laser Flip", 90, 10, 8),
            new Trick("Double Kickflip", 95, 9, 9),
            new Trick("Nollie Inward Heelflip", 100, 10, 9)
        };

        static List<Record> records = new List<Record>();

        static List<Judge> judges = new List<Judge>()
        {
            new Judge("Chris Cole", 3, ConsoleColor.Yellow),
            new Judge("Paul Rodriguez", 2, ConsoleColor.Blue),
            new Judge("Ryan Schekler", 4, ConsoleColor.Green)
        };

        static Skater selectedSkater = null!;
        static Trick selectedTrick = null!;
        static void Main()
        {
            Console.CursorVisible = false;

            foreach (var skater in skaters)
            {
                foreach (var trick in tricks)
                {
                    if (trick.Difficulty <= skater.Skill)
                    {
                        if (!skater.tricks.Contains(trick))
                        {
                            skater.tricks.Add(trick);
                        }
                    }
                }
            }


            while (true)
            {
                Console.Clear();
                Console.WriteLine("Gördeszka Verseny Szimulátor");
                char v;
                do
                {
                    v = Menu();
                    switch (v)
                    {
                        case '1':
                            if (selectedSkater == null)
                            {
                                Versenyzővalasztás();
                            }
                            else
                            {

                                int choice = 0;
                                List<string> newItems = new List<string>
                                {
                                    "Igen",
                                    "Nem"
                                };

                                while (true)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Már választottál versenyzőt!");
                                    Console.WriteLine("Szeretnél újra választani?\n");

                                    for (int i = 0; i < newItems.Count; i++)
                                    {
                                        if (i == choice)
                                        {
                                            Console.BackgroundColor = ConsoleColor.White;
                                            Console.ForegroundColor = ConsoleColor.Black;
                                            Console.Write("> ");
                                        }
                                        else
                                        {
                                            Console.ResetColor();
                                        }
                                        Console.WriteLine(newItems[i]);
                                    }
                                    Console.ResetColor();

                                    var key = Console.ReadKey(true).Key;

                                    if (key == ConsoleKey.UpArrow)
                                    {
                                        choice--;
                                        if (choice < 0)
                                            choice = newItems.Count - 1;
                                    }
                                    else if (key == ConsoleKey.DownArrow)
                                    {
                                        choice++;
                                        if (choice >= newItems.Count)
                                            choice = 0;
                                    }
                                    else if (key == ConsoleKey.Enter)
                                    {
                                        if (choice == 0)
                                        {
                                            selectedSkater = null!;
                                            Versenyzővalasztás();
                                            break;
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }
                                    else if (key == ConsoleKey.Escape)
                                    {
                                        return;
                                    }
                                }
                            }
                            break;
                        case '2':
                            if (selectedSkater != null)
                            {
                                Trukkok();
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Először válassz versenyzőt!");
                            }
                            break;
                        case '3':
                            Rekordok();
                            break;
                        case '4':
                            if (selectedSkater != null)
                            {
                                Simindítás();
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Először válassz versenyzőt!");
                            }
                            break;
                        case '5':
                            Environment.Exit(0);
                            break;
                        default:
                            break;
                    }
                    Console.ReadKey();
                }
                while (v != '5');
            }
        }
        static char Menu()
        {
            int choice = 0;
            List<string> menuItems = new List<string>
            {
                "Versenyző kiválasztása",
                "Trükkök",
                "Rekordok",
                "Szimulátor indítása",
                "Kilépés"
            };

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Gördeszka Verseny Szimulátor\n");

                for (int i = 0; i < menuItems.Count; i++)
                {
                    if (i == choice)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("> ");
                    }
                    else
                    {
                        Console.ResetColor();
                    }
                    Console.WriteLine(menuItems[i]);
                }
                Console.ResetColor();

                var key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.UpArrow)
                {
                    choice--;
                    if (choice < 0)
                        choice = menuItems.Count - 1;
                }
                else if (key == ConsoleKey.DownArrow)
                {
                    choice++;
                    if (choice >= menuItems.Count)
                        choice = 0;
                }
                else if (key == ConsoleKey.Enter)
                {
                    return (char)(choice + '1');
                }
            }
        }
        static void Versenyzővalasztás()
        {
            int choice = 0;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Válassz egy skatert!\n");

                for (int i = 0; i < skaters.Count; i++)
                {
                    if (i == choice)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("> ");
                    }
                    else
                    {
                        Console.ResetColor();
                    }
                    Console.WriteLine($"{i + 1}. {skaters[i].Name} - Skill: {skaters[i].Skill}");
                    Console.ResetColor();
                }

                var key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.UpArrow)
                {
                    choice--;
                    if (choice < 0)
                        choice = skaters.Count - 1;
                }
                else if (key == ConsoleKey.DownArrow)
                {
                    choice++;
                    if (choice >= skaters.Count)
                        choice = 0;
                }
                else if (key == ConsoleKey.Enter)
                {
                    selectedSkater = skaters[choice];
                    Console.WriteLine($"\nA kiválasztott versenyző: {selectedSkater.Name}");
                    Console.WriteLine("-->Enter<--");
                    break;
                }
                else if (key == ConsoleKey.Escape)
                {
                    return;
                }
            }
        }
        static void Trukkok()
        {
            int choice = 0;
            List<string> trickItems = new List<string>
            {
                "Új trükk tanulása",
                "Tanult trükkök listája",
                "Kilépés"
            };

            while (true)
            {

                Console.Clear();
                for (int i = 0; i < trickItems.Count; i++)
                {
                    if (i == choice)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("> ");
                    }
                    else
                    {
                        Console.ResetColor();
                    }
                    Console.WriteLine($"{trickItems[i]}");
                    Console.ResetColor();
                }

                var key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.UpArrow)
                {
                    choice--;
                    if (choice < 0)
                        choice = trickItems.Count - 1;
                }
                else if (key == ConsoleKey.DownArrow)
                {
                    choice++;
                    if (choice >= trickItems.Count)
                        choice = 0;
                }
                else if (key == ConsoleKey.Enter)
                {
                    if (choice == 0)
                    {
                        ujTrukk();
                    }
                    else if (choice == 1)
                    {
                        trukkLista();
                    }
                    else if (choice == 2)
                    {
                        break;
                    }
                }
                else if (key == ConsoleKey.Escape)
                {
                    return;
                }
            }
        }
        static void ujTrukk()
        {
            int choice = 0;
            List<Trick> learnableTricks = new List<Trick>();

            foreach (var trick in tricks)
            {
                if (trick.Difficulty > selectedSkater.Skill && !selectedSkater.tricks.Contains(trick))
                {
                    learnableTricks.Add(trick);
                }
            }

            if (learnableTricks.Count == 0)
            {
                Console.WriteLine("Nincsenek tanulható trükkök.");
                Console.WriteLine("--> Enter <--");
                Console.ReadLine();
                return;
            }

            learnableTricks.Add(null!);

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Válassz egy trükköt, amit megszeretnél tanulni?\n");

                for (int i = 0; i < learnableTricks.Count; i++)
                {
                    if (i == choice)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("> ");
                    }
                    else
                    {
                        Console.ResetColor();
                    }
                    if (learnableTricks[i] == null)
                    {
                        Console.WriteLine("Vissza");
                    }
                    else
                    {
                        Console.WriteLine($"{i + 1}. {learnableTricks[i].Name}, Nehézség: {learnableTricks[i].Difficulty}");
                    }
                    Console.ResetColor();
                }


                var key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.UpArrow)
                {
                    choice--;
                    if (choice < 0)
                        choice = learnableTricks.Count - 1;
                }
                else if (key == ConsoleKey.DownArrow)
                {
                    choice++;
                    if (choice >= learnableTricks.Count)
                        choice = 0;
                }
                else if (key == ConsoleKey.Enter)
                {
                    if (learnableTricks[choice] == null)
                    {
                        break;
                    }
                    else
                    {
                        selectedTrick = learnableTricks[choice];
                        Console.WriteLine($"\nA kiválasztott trükk: {selectedTrick.Name}");
                        Console.WriteLine("-->Enter<--");
                        Random random = new Random();
                        if (random.Next(0, 30) > (selectedTrick.Difficulty - selectedSkater.Skill))
                        {
                            selectedSkater.tricks.Add(selectedTrick);
                            Console.WriteLine($"Sikerült megtanulni a {selectedTrick.Name} trükköt!");
                        }
                        else
                        {
                            Console.WriteLine("Nem sikerült megtanulni a trükköt.");
                        }
                        Console.ReadKey();
                        break;
                    }
                }
                else if (key == ConsoleKey.Escape)
                {
                    return;
                }
            }
 

        }
        static void trukkLista()
        {
            int i = 1;
            Console.Clear();

            foreach (var trick in selectedSkater.tricks)
            {
                Console.WriteLine($"{i}. {trick.Name}, Nehézség: {trick.Difficulty}");
                i++;
            }
            Console.WriteLine("\n-->Enter<--");
            Console.ReadKey();
        }
        static void Rekordok()
        {
            Console.Clear();
            Console.WriteLine("Verseny Rekordok\n");

            if (records.Count == 0)
            {
                Console.WriteLine("Még nincs elmentett rekord.");
            }
            else
            {
                for (int i = 0; i < records.Count - 1; i++)
                {
                    for (int j = 0; j < records.Count - 1; j++)
                    {
                        if (records[j].Points < records[j + 1].Points)
                        {
                            var temp = records[j];
                            records[j] = records[j + 1];
                            records[j + 1] = temp;
                        }
                    }
                }
                foreach (var record in records)
                {
                    Console.WriteLine(record);
                }
            }

            Console.WriteLine("\n-->Enter<--");
            Console.ReadKey();
        }
        static void Simindítás()
        {
            Console.Clear();
            if (selectedSkater.tricks.Count < 8)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("A versenyző nem tud elég trükköt az indításhoz.");
                Console.WriteLine("\n--> Enter <---");
                Console.ReadKey();
                Console.ResetColor();
                return;
            }

            Random random = new Random();
            List<string> selectedTricks = new List<string>();
            int injuryCount = 0;

            while (selectedTricks.Count < 8)
            {
                int score = 0;
                int selected = random.Next(selectedSkater.tricks.Count);
                if (!selectedTricks.Contains(selectedSkater.tricks[selected].Name))
                {
                    TypeLine($"Most próbálkozol a {selectedSkater.tricks[selected].Name} trükköt végrehajtani!");
                    if (random.Next(1, 81) < ((selectedSkater.tricks[selected].Injury * 10) - (selectedSkater.Skill / 2)))
                    {
                        injuryCount++;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"{selectedSkater.tricks[selected].Name} trükk végrehajtása közben sérülés történt!\n");
                        Console.ResetColor();
                        selectedTricks.Add(selectedSkater.tricks[selected].Name);

                        if (injuryCount >= 2)
                        {
                            selectedSkater.Score = 0;
                            Console.WriteLine("A versenyző kétszer is megsérült! Sajnos kiesett a versenyből.");
                            return;
                        }
                    }
                    else
                    {
                        Console.WriteLine($"A(z) {selectedSkater.tricks[selected].Name} trükk sikerült!");
                        foreach (var judge in judges)
                        {

                            int judgeScore = judge.Rating(selectedSkater.tricks[selected]);
                            score += judgeScore;
                            Console.ForegroundColor = judge.Color;
                            Console.Write($"{judge.Name} adott rá {judgeScore} pontot.\t");
                        }
                        Console.ResetColor();
                        Console.WriteLine($"Összesen: {score} pont\n");
                        selectedSkater.Score += score;
                        selectedTricks.Add(selectedSkater.tricks[selected].Name);
                    }
                }
            } 
            if (selectedSkater.Score < 100)
            {
                Console.WriteLine($"{selectedSkater.Name} összesen {selectedSkater.Score} pontot szerzett");
            }
            if (selectedSkater.Score >= 100 && selectedSkater.Score < 150)
            {
                selectedSkater.Skill += 1;
                if (selectedSkater.Skill >= 100)
                {
                    selectedSkater.Skill = 100;
                }
                Console.WriteLine($"{selectedSkater.Name} összesen {selectedSkater.Score} pontot szerzett. Skill: {selectedSkater.Skill} (1-el nőt).");
            }
            else if (selectedSkater.Score >= 150 && selectedSkater.Score < 200)
            {
                selectedSkater.Skill += 3;
                if (selectedSkater.Skill >= 100)
                {
                    selectedSkater.Skill = 100;
                }
                Console.WriteLine($"{selectedSkater.Name} összesen {selectedSkater.Score} pontot szerzett. Skill: {selectedSkater.Skill} (3-mal nőt).");
            }
            else if (selectedSkater.Score >= 200)
            {
                selectedSkater.Skill += 5;
                if (selectedSkater.Skill >= 100)
                {
                    selectedSkater.Skill = 100;
                }
                Console.WriteLine($"{selectedSkater.Name} összesen {selectedSkater.Score} pontot szerzett. Skill: {selectedSkater.Skill} (5-tel nőt).");
            }

            records.Add(new Record(selectedSkater.Name, selectedSkater.Score));
            Console.WriteLine("--> Enter <---");
        }
        static void TypeLine(string value)
        {
            Thread.Sleep(100);
            foreach (var letter in value)
            {
                Console.Write(letter);
                Thread.Sleep(15);
            }
            Console.WriteLine();
        }
    }
}
