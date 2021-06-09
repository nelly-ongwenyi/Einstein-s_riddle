//Group members: 106221 Nelly Ongwenyi
//               110486 Patrick Wachira
//               111878 Lilian Thairu
//               110201 Angela Mate
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace riddle_einstein_Cshap
{
    enum Houses {Blue = 1, Green,Red,White,Yellow};
    enum Nationalities {Brit = 1, Dane, German,Norwegian, Swede};
    enum Drinks {Beer = 1, Coffee, Milk, Tea, Water };
    enum Cigars {Blends = 1, Blue_Master, Dunhill, Pall_Mall, Prince };
    enum Pets { Birds = 1, Cats, Dogs, Fish, Horses };
    class Program
    {
        static void Main(string[] args)
        {
            DateTime begin = DateTime.Now;
            String positions = "12345";// There are five houses
            String[] combs = Combinations(positions);
            int solutions = 0;

            for(int nationality = 0; nationality< combs.Length; nationality++)
            {
                if (Check_Requirement(10, combs[nationality]))
                {
                    for (int hou = 0; hou < combs.Length; hou++)
                    {
                        if ((Check_Requirement(2, combs[nationality], combs[hou]) == true) &&
                            (Check_Requirement(6, combs[nationality], combs[hou]) == true) &&
                            (Check_Requirement(15, combs[nationality], combs[hou]) == true))
                        {

                            for (int dri = 0; dri < combs.Length; dri++)
                            {
                                if ((Check_Requirement(4, combs[nationality], combs[hou], combs[dri]) == true) &&
                                    (Check_Requirement(5, combs[nationality], combs[hou], combs[dri]) == true) &&
                                    (Check_Requirement(9, combs[nationality], combs[hou], combs[dri]) == true) &&
                                    (Check_Requirement(16, combs[nationality], combs[hou], combs[dri]) == true))

                                {
                                    for (int cigars = 0; cigars < combs.Length; cigars++)
                                    {
                                        if ((Check_Requirement(8, combs[nationality], combs[hou], combs[dri], combs[cigars]) == true)&&
                                            (Check_Requirement(13, combs[nationality], combs[hou], combs[dri], combs[cigars]) == true) &&
                                            (Check_Requirement(14, combs[nationality], combs[hou], combs[dri], combs[cigars]) == true))
                                        {
                                            for (int pet = 0; pet < combs.Length; pet++)
                                            {
                                                if ((Check_Requirement(3, combs[nationality], combs[hou], combs[dri], combs[cigars], combs[pet]) == true) &&
                                                    (Check_Requirement(7, combs[nationality], combs[hou], combs[dri], combs[cigars], combs[pet]) == true) &&
                                                    (Check_Requirement(11, combs[nationality], combs[hou], combs[dri], combs[cigars], combs[pet]) == true) &&
                                                    (Check_Requirement(12, combs[nationality], combs[hou], combs[dri], combs[cigars], combs[pet]) == true))
                                                {
                                                    solutions = solutions + 1;
                                                    Display_Results(solutions, combs[nationality], combs[hou], combs[dri], combs[cigars], combs[pet]);
                                                }
                                            }
                                        }
                                    }

                                }
                            }
                        }
                    }
                }
            }

            DateTime end = DateTime.Now;
            double diff = (end - begin).TotalMilliseconds;
            Console.WriteLine("Solved in" + diff.ToString() + "milliseconds");
            Console.ReadKey();

        }
        public static bool Check_Requirement( int number, string nationality, string hou = "", string dri = "", string cigars = "", string pet= "")
        {
            switch (number)
            {
                case 2:// The Brit Lives in the red house
                    if(nationality.Substring(hou.IndexOf(((int)Houses.Red).ToString()), 1 ) == ((int)Nationalities.Brit).ToString())
                    {
                        return true;
                    }
                    break;
                case 3:// The Swede Owns Dogs as Pets
                    if (nationality.Substring(pet.IndexOf(((int)Pets.Dogs).ToString()), 1) == ((int)Nationalities.Swede).ToString())
                    {
                        return true;
                    }
                    break;
                case 4:// The Dane drinks tea
                    if (dri.Substring(nationality.IndexOf(((int)Nationalities.Dane).ToString()), 1) == ((int)Drinks.Tea).ToString())
                    {
                        return true;
                    }
                    break;
                case 5:// Coffee is drunk in the green house
                    if (dri.Substring(hou.IndexOf(((int)Houses.Green).ToString()), 1) == ((int)Drinks.Coffee).ToString())
                    {
                        return true;
                    }
                    break;
                case 6: // The Green house is exactly to the left of the White house.
                    if (hou.IndexOf(((int)Houses.White).ToString()) - hou.IndexOf(((int)Houses.Green).ToString()) == 1)
                    {
                        return true;
                    }
                    break;
                case 7:// The person who smokes Pall Mall rears Birds.
                    if (cigars.Substring(pet.IndexOf(((int)Pets.Birds).ToString()), 1) == ((int)Cigars.Pall_Mall).ToString())
                    {
                        return true;
                    }
                    break;
                case 8:// The owner of the Yellow house cigarskes Dunhill.
                    if (cigars.Substring(hou.IndexOf(((int)Houses.Yellow).ToString()), 1) == ((int)Cigars.Dunhill).ToString())
                    {
                        return true;
                    }
                    break;
                case 9:// The man living in the centre house drinks Milk.
                    if(dri.Substring(2, 1) == ((int)Drinks.Milk).ToString())
                    {
                        return true;
                    }
                    break;
                case 10:// The Norwegian lives in the first house.
                    if (nationality.Substring(0, 1) == ((int)Nationalities.Norwegian).ToString()) 
                    {
                        return true;
                    }
                    break;
                case 11:// The man who smokes Blends lives next to the one who keeps Cats.
                    if(Math.Abs(cigars.IndexOf(((int)Cigars.Blends).ToString())-pet.IndexOf(((int)Pets.Cats).ToString())) == 1)
                    {
                        return true;
                    }
                    break;
                case 12://The man who keeps Horses lives next to the man who smokes Dunhill.
                    if (Math.Abs(pet.IndexOf(((int)Pets.Horses).ToString()) - cigars.IndexOf(((int)Cigars.Dunhill).ToString())) == 1)
                    {
                        return true;
                    }
                    break;
                case 13://The man who smokes Blue Master drinks Beer.
                    if (cigars.Substring(dri.IndexOf(((int)Drinks.Beer).ToString()), 1) == ((int)Cigars.Blue_Master).ToString())
                    {
                        return true;
                    }
                    break;
                case 14://The German smokes Prince.
                    if (cigars.Substring(nationality.IndexOf(((int)Nationalities.German).ToString()), 1) == ((int)Cigars.Prince).ToString())
                    {
                        return true;
                    }
                    break;
                case 15://The Norwegian lives next to the Blue house.
                    if (Math.Abs(hou.IndexOf(((int)Houses.Blue).ToString()) - nationality.IndexOf(((int)Nationalities.Norwegian).ToString())) == 1)
                    {
                        return true;
                    }
                    break;
                case 16://The man who smokes Blends has a neighbour who drinks Water.
                    if (Math.Abs(pet.IndexOf(((int)Cigars.Blends).ToString()) - dri.IndexOf(((int)Drinks.Water).ToString())) == 1)
                    {
                        return true;
                    }
                    break;                   
                default:
                    break;
            }

            return false;
        }

        public static void Display_Results(int solution, string nationalities, string houses, string drinks, string Cigars, string pets)
        {
            Console.WriteLine("RESULTS");
            Console.WriteLine();
            Console.WriteLine(string.Format("{0, -1} ", "NUMBER"));
            Console.WriteLine(string.Format("{0, -12} ","HOUSE"));
            Console.WriteLine(string.Format("{0, -12} ", "NATIONALITY"));
            Console.WriteLine(string.Format("{0, -12} ", "DRINK"));
            Console.WriteLine(string.Format("{0, -12} ", "CIGARS"));
            Console.WriteLine(string.Format("{0, -12} ", "PET"));
            Console.WriteLine();

            for(int c = 0; c < houses.Length; c++)
            {
                Console.WriteLine(String.Format("{0,-1} ",(c+1)));
                Console.WriteLine(string.Format("{0, -12} ", ((Houses)Convert.ToInt32(houses.Substring(c, 1))).ToString()));
                Console.WriteLine(string.Format("{0, -12} ", ((Nationalities)Convert.ToInt32(nationalities.Substring(c, 1))).ToString()));
                Console.WriteLine(string.Format("{0, -12} ", ((Drinks)Convert.ToInt32(drinks.Substring(c, 1))).ToString()));
                Console.WriteLine(string.Format("{0, -12} ", ((Cigars)Convert.ToInt32(Cigars.Substring(c, 1))).ToString()));
                Console.WriteLine(string.Format("{0, -12} ", ((Pets)Convert.ToInt32(pets.Substring(c, 1))).ToString()));

            }
        }
        public static string[] Combinations(string positions)
        {
            List<String> combs = new List<string>();
            for(int c =0; c<positions.Length; c++)
            {
                string single = positions.Substring(c, 1);
                if (combs.Count == 0)
                {
                    combs.Add(single);
                }
                else
                {
                    List<string> newcombs = new List<String>();
                    for (int current = 0; current < combs.Count; current++)
                    {
                        for (int pos = 0; pos < combs[current].Length; pos++)
                        {
                            newcombs.Add(combs[current].Substring(0, pos) + single + combs[current].Substring(pos));
                        }

                        newcombs.Add(combs[current] + single);
                    }

                    combs = newcombs;
                }
            }
            return combs.ToArray();
        }
    }
}
