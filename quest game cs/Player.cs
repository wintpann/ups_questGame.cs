using System;
using System.Collections.Generic;

namespace quest_game_cs
{
    static class Player
    {
        static Player()
        {
            x = 1;
            y = Map.GetYFloor();

            surfaceStop.Add(" o ");
            surfaceStop.Add("/|\\");
            surfaceStop.Add(" | ");
            surfaceStop.Add("/ \\");

            surface.Add(surfaceStop[0]);
            surface.Add(surfaceStop[1]);
            surface.Add(surfaceStop[2]);
            surface.Add(surfaceStop[3]);

            surfaceToRight1.Add(" o ");
            surfaceToRight1.Add("/|\\");
            surfaceToRight1.Add(" ) ");
            surfaceToRight1.Add("/ \\");

            surfaceToRight2.Add(" o ");
            surfaceToRight2.Add("/|\\");
            surfaceToRight2.Add(" ) ");
            surfaceToRight2.Add("/| ");

            surfaceToRight3.Add(" o ");
            surfaceToRight3.Add("/|\\");
            surfaceToRight3.Add(" ) ");
            surfaceToRight3.Add(" / ");

            surfaceToLeft1.Add(" o ");
            surfaceToLeft1.Add("/|\\");
            surfaceToLeft1.Add(" ( ");
            surfaceToLeft1.Add("/ \\");

            surfaceToLeft2.Add(" o ");
            surfaceToLeft2.Add("/|\\");
            surfaceToLeft2.Add(" ( ");
            surfaceToLeft2.Add(" |\\");

            surfaceToLeft3.Add(" o ");
            surfaceToLeft3.Add("/|\\");
            surfaceToLeft3.Add(" ( ");
            surfaceToLeft3.Add(" \\ ");

            surfaceInclineToRight.Add("   ");
            surfaceInclineToRight.Add("  o");
            surfaceInclineToRight.Add(" /\\");
            surfaceInclineToRight.Add("/\\ ");

            surfaceInclineToLeft.Add("   ");
            surfaceInclineToLeft.Add("o  ");
            surfaceInclineToLeft.Add("/\\ ");
            surfaceInclineToLeft.Add(" /\\");

            surfaceIncline.Add("   ");
            surfaceIncline.Add(" o ");
            surfaceIncline.Add("/|\\");
            surfaceIncline.Add("/ |");
        }

        private static int step;
        private static int x, y;
        private static int height = 4;
        private static int width = 3;
        private static int health = 5;
        private static int energy = 100;
        private static int money = 100;
        private static List<string> items = new List<string>();
        private static bool wantToInteract;
        private static int visibilityRange = 60;
        private static int halfOfVisibility = visibilityRange / 2;
        private static List<string> surface = new List<string>();
        private static List<string> surfaceToRight1 = new List<string>();
        private static List<string> surfaceToRight2 = new List<string>();
        private static List<string> surfaceToRight3 = new List<string>();
        private static List<string> surfaceToLeft1 = new List<string>();
        private static List<string> surfaceToLeft2 = new List<string>();
        private static List<string> surfaceToLeft3 = new List<string>();
        private static List<string> surfaceInclineToRight = new List<string>();
        private static List<string> surfaceInclineToLeft = new List<string>();
        private static List<string> surfaceIncline = new List<string>();
        private static List<string> surfaceStop = new List<string>();
        public enum CreatingAction
        {
            CREATE,
            NONE,
            EXIT
        };

        public static int X
        {
            get
            {
                return x;
            }
            set
            {
                if (value > 0 && value < Map.MapWidth - Width)
                {
                    x = value;
                }
            }
        }
        public static int Y
        {
            get
            {
                return y;
            }
        }
        public static int Height
        {
            get
            {
                return height;
            }
        }
        public static int Width
        {
            get
            {
                return width;
            }
        }
        public static List<string> Surface
        {
            get
            {
                return surface;
            }
        }
        public static int VisibilityRange
        {
            get
            {
                return visibilityRange;
            }
        }
        public static int BeginOfVisibility
        {
            get
            {
                if (X < halfOfVisibility)
                {
                    return 0;
                }
                else if ((Map.MapWidth - X) < halfOfVisibility)
                {
                    return Map.MapWidth - VisibilityRange;
                }
                else
                {
                    return X - halfOfVisibility;
                }
            }
        }
        public static int EndOfVisibility
        {
            get
            {
                if (X < halfOfVisibility)
                {
                    return VisibilityRange;
                }
                else if ((Map.MapWidth - X) < halfOfVisibility)
                {
                    return Map.MapWidth;
                }
                else
                {
                    return X + halfOfVisibility;
                }
            }
        }
        public static int Health
        {
            get
            {
                return health;
            }
            set
            {
                health = value;
            }
        }
        public static int Energy
        {
            get
            {
                return energy;
            }
            set
            {
                energy = value;
            }
        }
        public static int Money
        {
            get
            {
                return money;
            }
            set
            {
                money = value;
            }
        }
        public static List<string> Items
        {
            get
            {
                return items;
            }
            set
            {
                items = value;
            }
        }
        public static bool WantToInteract
        {
            get
            {
                return wantToInteract;
            }
            set
            {
                wantToInteract = value;
            }
        }
        private static int GetStep()
        {
            step++;
            if (step == 4)
                step = 1;
            return step;
        }
        private static void ToRigth()
        {
            if (Program.currentElement == null)
            {
                X++;
            }
            else
            {
                if (Program.currentElement.Name != "Wall")
                {
                    X++;
                }
                else
                {
                    if (X > Program.currentElement.X)
                    {
                        X++;
                    }
                }
            }

            switch (GetStep())
            {
                case 1:
                    surface[0] = surfaceToRight1[0];
                    surface[1] = surfaceToRight1[1];
                    surface[2] = surfaceToRight1[2];
                    surface[3] = surfaceToRight1[3];
                    break;
                case 2:
                    surface[0] = surfaceToRight2[0];
                    surface[1] = surfaceToRight2[1];
                    surface[2] = surfaceToRight2[2];
                    surface[3] = surfaceToRight2[3];
                    break;
                case 3:
                    surface[0] = surfaceToRight3[0];
                    surface[1] = surfaceToRight3[1];
                    surface[2] = surfaceToRight3[2];
                    surface[3] = surfaceToRight3[3];
                    break;
            }
        }
        private static void ToLeft()
        {
            if (Program.currentElement == null)
            {
                X--;
            }
            else
            {
                if (Program.currentElement.Name != "Wall")
                {
                    X--;
                }
                else
                {
                    if (X < Program.currentElement.X)
                    {
                        X--;
                    }
                }
            }

            switch (GetStep())
            {
                case 1:
                    surface[0] = surfaceToLeft1[0];
                    surface[1] = surfaceToLeft1[1];
                    surface[2] = surfaceToLeft1[2];
                    surface[3] = surfaceToLeft1[3];
                    break;
                case 2:
                    surface[0] = surfaceToLeft2[0];
                    surface[1] = surfaceToLeft2[1];
                    surface[2] = surfaceToLeft2[2];
                    surface[3] = surfaceToLeft2[3];
                    break;
                case 3:
                    surface[0] = surfaceToLeft3[0];
                    surface[1] = surfaceToLeft3[1];
                    surface[2] = surfaceToLeft3[2];
                    surface[3] = surfaceToLeft3[3];
                    break;
            }
        }
        public static void MoveOrInteract()
        {
            ConsoleKeyInfo key = Console.ReadKey();
            switch (key.Key.ToString())
            {
                case "RightArrow":
                    ToRigth();
                    WantToInteract = false;
                    break;
                case "LeftArrow":
                    ToLeft();
                    WantToInteract = false;
                    break;
                case "F":
                    WantToInteract = true;
                    if (Program.currentElement != null)
                    {
                        if (Program.currentElement.InteractionText.Substring(3, 9) == "ПОДОБРАТЬ" || Program.currentElement.InteractionText.Substring(3, 6) == "СЪЕСТЬ")
                        {
                            if (Player.X < Program.currentElement.X)
                            {
                                surface[0] = surfaceInclineToRight[0];
                                surface[1] = surfaceInclineToRight[1];
                                surface[2] = surfaceInclineToRight[2];
                                surface[3] = surfaceInclineToRight[3];
                            }
                            else if (Player.X > Program.currentElement.X)
                            {
                                surface[0] = surfaceInclineToLeft[0];
                                surface[1] = surfaceInclineToLeft[1];
                                surface[2] = surfaceInclineToLeft[2];
                                surface[3] = surfaceInclineToLeft[3];
                            }
                            else
                            {
                                surface[0] = surfaceIncline[0];
                                surface[1] = surfaceIncline[1];
                                surface[2] = surfaceIncline[2];
                                surface[3] = surfaceIncline[3];
                            }
                        }
                    }
                    
                    break;
                case "G":
                    WantToInteract = false;
                    ShowInventory();
                    break;
                default:
                    WantToInteract = false;
                    break;
            }
        }

        public static CreatingAction MoveToCreate()
        {
            ConsoleKeyInfo key = Console.ReadKey();
            switch (key.Key.ToString())
            {
                case "RightArrow":
                    X++;
                    return CreatingAction.NONE;
                case "LeftArrow":
                    X--;
                    return CreatingAction.NONE;
                case "F":
                    return CreatingAction.CREATE;
                case "X":
                    return CreatingAction.EXIT;
                default:
                    return CreatingAction.NONE;
            }
        }

        public static Element ReturnCurrentlement(ref List<Element> elements)
        {
            for (int i = 0; i < elements.Count; i++)
            {
                if (elements[i] != null)
                {
                    int elementBegin = elements[i].X - 2;
                    int elementEnd = elements[i].X + elements[i].Width - 1;
                    if ((X >= elementBegin) && (X <= elementEnd))
                    {
                        return elements[i];
                    }
                }

            }
            return null;
        }
        public static Element ReturnCurrentInteractElement(ref Element element)
        {
            if (element != null)
            {
                if (element.Interaction)
                {
                    if (!WantToInteract)
                    {
                        Map.OutputInteraction.Append(element.InteractionText);
                    }

                    return element;
                }
                else
                {
                    Map.OutputInteraction.Append(element.DescriptionText);
                }
            }
            return null;
        }
        public static int Choose(params string[] args)
        {

            int len = args.Length;
            int chosen = 0;

            while (true)
            {
                for (int i = 0; i < len; i++)
                {
                    if (i == chosen)
                    {
                        Console.WriteLine(">>" + args[i] + "");
                    }
                    else
                    {
                        Console.WriteLine(args[i]);
                    }

                }
                ConsoleKeyInfo key = Console.ReadKey();

                switch (key.Key.ToString())
                {
                    case "Enter":
                        return chosen;
                    case "UpArrow":
                        if (chosen == 0)
                            chosen = len - 1;
                        else
                            chosen--;
                        break;
                    case "DownArrow":
                        if (chosen == len - 1)
                            chosen = 0;
                        else
                            chosen++;
                        break;
                    default:
                        break;
                }
                Console.Clear();
            }

        }
        public static void Dialog(string[] questionsPattern, string[] answersPattern)
        {
            bool exit = false;
            Console.Clear();
            while (!exit)
            {
                int choise = Player.Choose(questionsPattern);

                int len = questionsPattern.Length;
                for (int i = 0; i < len; i++)
                {
                    if (choise == i && answersPattern[i] != "ExitDialog" && answersPattern[i] != "Trade")
                    {
                        int textLen = answersPattern[i].Length;
                        Console.Clear();
                        for (int j = 0; j< textLen; j++)
                        {
                            if (answersPattern[i][j] != '&')
                            {
                                Console.Write(answersPattern[i][j]);
                            }
                            else
                            {
                                Console.WriteLine();
                            }
                            
                        }
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine(">>ЯСНО");
                        Console.ReadLine();
                        Console.Clear();
                    }
                    else if (choise == i && answersPattern[i] == "ExitDialog")
                    {
                        exit = true;
                    }
                    else if (choise == i && answersPattern[i] == "Trade")
                    {
                        Trade();
                    }
                }
            }
        }
        static void Trade()
        {
            Person person = (Person)Program.currentElement;

            List<string> goods = new List<string>();
            List<string> prices = new List<string>();
            List<string> allIn = new List<string>();

            int len = person.Items.Count;

            for (int i = 0; i < len; i += 2)
            {
                goods.Add(person.Items[i]);
                prices.Add(person.Items[i + 1]);
                allIn.Add(person.Items[i] + ": " + person.Items[i + 1] + "$");
            }
            allIn.Add("ВЫЙТИ");
            
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                int choise = Player.Choose(allIn.ToArray());
                if (choise != allIn.Count - 1)
                {
                    if (Convert.ToInt32(prices[choise]) > Player.Money)
                    {
                        Console.WriteLine("");
                        Console.WriteLine("НЕ ХВАТАЕТ ДЕНЕГ. У ТЕБЯ ЕСТЬ " + Player.Money + "$");
                        System.Threading.Thread.Sleep(700);
                    }
                    else
                    {
                        Items.Add(goods[choise]);
                        Money -= Convert.ToInt32(prices[choise]);
                        allIn.Remove(allIn[choise]);
                        prices.Remove(prices[choise]);
                        goods.Remove(goods[choise]);
                        person.Items.RemoveRange(choise * 2, 2);
                        Console.WriteLine("");
                        Console.WriteLine("КУПЛЕНО. ОСТАЛОСЬ " + Player.Money + "$");
                        System.Threading.Thread.Sleep(700);
                    }
                }
                else
                {
                    exit = true;
                    Console.Clear();
                }
            }
            
        }
        public static void ShowInventory()
        {
            Console.Clear();
            if (Items.Count > 0)
            {
                Console.WriteLine("У ТЕБЯ ЕСТЬ: ");
                Console.WriteLine("");
                foreach (string item in Items)
                {
                    Console.WriteLine("-" + item);
                }
                Console.WriteLine();
                Console.WriteLine(">>OK");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("У ТЕБЯ В РЮКЗАКЕ ПУСТО");
                Console.WriteLine();
                Console.WriteLine(">>OK");
                Console.ReadLine();
            }
        }

        public static bool DoIHaveTheItem(string wantedItem)
        {
            if (Items.Count > 0)
            {
                foreach (string item in Items)
                {
                    if (wantedItem == item)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static void MakeTurn(Map map, List<Element> elements)
        {
            map.Draw();
            MoveOrInteract();
            Program.currentElement = Player.ReturnCurrentlement(ref elements);
            Program.currentInteractionElement = Player.ReturnCurrentInteractElement(ref Program.currentElement);
        }
    }
}
