using System;
using System.Collections.Generic;
using System.Text;

namespace quest_game_cs
{
    static class Scenes
    {
        static int shortSleep = 1000;
        static int longSleep = 4000;

        public static void Menu()
        {
            Console.Clear();
            int choise = Player.Choose("ПРОЙТИ ОБУЧЕНИЕ", "НАЧАТЬ ИГРУ", "СОЗДАТЬ КАРТУ");
            if (choise == 0)
            {
                TrainingScene();
            }
            else if (choise == 1)
            {
                MainScene();
            }
            else
            {
                CreateNewMap();
            }
        }

        public static void CreateNewMap()
        {
            Console.WindowWidth = Map.MapWidth + 1;
            MapCreator.Initialize();

            bool exit = false;
            while (!exit)
            {
                Program.creatingMap.DrawToCreate();

                Player.CreatingAction action = Player.MoveToCreate();
                if (action == Player.CreatingAction.CREATE)
                {
                    MapCreator.CreateNewObject();
                }
                else if (action == Player.CreatingAction.EXIT)
                {
                    exit = true;
                    Console.Clear();
                    ShowCode();
                    Console.ReadLine();
                }
            }
            Environment.Exit(0);
        }

        public static void ShowCode()
        {
            string objs = "";

            for (int i = 0; i < MapCreator.elS.Count; i++)
            {
                MapCreator.ElS el = MapCreator.elS[i];

                objs += $"\"{el.obj}\", \"{el.x}\", \"{el.interaction}\", \"{el.interactionAction}\", \"{el.description}\"";

                if (i != MapCreator.elS.Count - 1)
                {
                    objs += ", ";
                }

            }
            Console.WindowWidth = Console.LargestWindowWidth-30;
            Console.WindowHeight = Console.LargestWindowHeight;
            Console.WriteLine("Добавьте эти поля в класс Program");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"public static List<Element> {MapCreator.MapName}Elements;");
            Console.WriteLine($"public static Map {MapCreator.MapName}Map = new Map();");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Присвойте значения этим полям в методе Setup класса Program");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{MapCreator.MapName}Elements = Element.CreateElements({objs});");
            Console.WriteLine($"{MapCreator.MapName}Map.Add({MapCreator.MapName}Elements);");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Добавьте этот метод в класс Scenes");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"public static void {MapCreator.MapName}Scene()");
            Console.WriteLine("{");
            Console.WriteLine("}");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"В этом методе можно писать код к уровню. Все элементы будут находиться в поле ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"Program.{MapCreator.MapName}Elements");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"Карта для работы с этим уровнем - ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"Program.{MapCreator.MapName}Map");
            Console.WriteLine("");
        }

        public static void MainScene()
        {
            while (true)
            {
                Player.MakeTurn(Program.mainMap, Program.mainElements);

                if (Program.InteractWithElement(Program.mainElements[3]))
                {
                    Player.Money -= 50;
                    Map.OutputInteraction.Append("Миссия выполнена. Конец игры");
                    Program.mainMap.Draw();
                    System.Threading.Thread.Sleep(800);
                    GameOver();
                }
            }
        }

        public static void TrainingScene()
        {
            Console.Clear();
            Console.WriteLine("Пояснения внизу карты");
            System.Threading.Thread.Sleep(shortSleep);
            Console.Clear();

            Map.OutputInteraction.Append("Это игровая карта, а на ней ты");
            Program.trainingMap.Draw();
            System.Threading.Thread.Sleep(longSleep);
            Map.OutputInteraction.Append("Нажми стрелку влево или вправо, чтобы двигаться");
            System.Threading.Thread.Sleep(shortSleep);

            for (int i = 0; i < 2; i++)
            {
                Program.trainingMap.Draw();
                Player.MoveOrInteract();
            }

            Program.trainingElements.Add(new House(15, false, "", ""));
            Program.trainingMap.Add(Program.trainingElements);
            Map.OutputInteraction.Append("На карте есть объекты, к примеру вот этот дом");
            Program.trainingMap.Draw();
            System.Threading.Thread.Sleep(longSleep);
            Map.OutputInteraction.Append("Ты видишь его описание, когда проходишь мимо. Подойди к дому");
            Program.trainingMap.Draw();
            System.Threading.Thread.Sleep(longSleep);
            bool goal1 = false;

            while (!goal1)
            {
                Player.MoveOrInteract();
                Program.currentElement = Player.ReturnCurrentlement(ref Program.trainingElements);
                Program.currentInteractionElement = Player.ReturnCurrentInteractElement(ref Program.currentElement);
                if (Program.currentElement == Program.trainingElements[0])
                {
                    goal1 = true;
                }
                Program.trainingMap.Draw();
            }
            System.Threading.Thread.Sleep(shortSleep);
            Map.OutputInteraction.Append("Отлично! С некоторыми из них ты можешь взаимодействовать");
            Program.trainingMap.Draw();
            System.Threading.Thread.Sleep(longSleep);
            Program.trainingElements[0] = new Teleport(20, true, "", "");
            Program.trainingElements.Add(new Wall(30, false, "", ""));
            Program.trainingElements.Add(new Teleport(40, true, "", ""));
            Program.trainingMap.ClearAdd(Program.trainingElements);
            Map.OutputInteraction.Append("Используй портал, чтобы попасть на другую сторону");
            Program.trainingMap.Draw();
            System.Threading.Thread.Sleep(longSleep);

            bool goal2 = false;
            while (!goal2)
            {
                Player.MoveOrInteract();
                Program.currentElement = Player.ReturnCurrentlement(ref Program.trainingElements);
                Program.currentInteractionElement = Player.ReturnCurrentInteractElement(ref Program.currentElement);

                if (Program.InteractWithElement(Program.trainingElements[0]))
                {
                    Player.X += 23;
                }
                if (Player.X > Program.trainingElements[1].X)
                {
                    goal2 = true;
                }

                Program.trainingMap.Draw();
            }
            Map.OutputInteraction.Append("Отлично! Ты также можешь ломать стены чтобы пройти");
            Program.trainingMap.Draw();
            System.Threading.Thread.Sleep(longSleep);
            Map.OutputInteraction.Append("Но обрати внимание, как расходуется энергия");
            Program.trainingMap.Draw();
            System.Threading.Thread.Sleep(longSleep);
            Program.trainingElements[0] = null;
            Program.trainingElements[2] = null;
            Program.trainingElements[1].Interaction = true;
            Program.trainingMap.ClearAdd(Program.trainingElements);
            Map.OutputInteraction.Append("Сломай стену");
            Program.trainingMap.Draw();
            System.Threading.Thread.Sleep(shortSleep);

            bool goal3 = false;

            while (!goal3)
            {
                Player.MoveOrInteract();
                Program.currentElement = Player.ReturnCurrentlement(ref Program.trainingElements);
                Program.currentInteractionElement = Player.ReturnCurrentInteractElement(ref Program.currentElement);

                if (Program.InteractWithElement(Program.trainingElements[1]))
                {
                    Program.trainingElements[2] = new PickAxe(150, true, "", "");
                    Program.trainingElements[0] = new House(100, false, "", "");
                    Program.trainingElements[1] = new Wall(30, false, "", "Нужна кирка чтобы сломать. Исследуй карту");
                    Program.trainingMap.ClearAdd(Program.trainingElements);
                    goal3 = true;
                }

                Program.trainingMap.Draw();
            }

            bool goal31 = false;

            while (!goal31)
            {
                Player.MoveOrInteract();
                Program.currentElement = Player.ReturnCurrentlement(ref Program.trainingElements);
                Program.currentInteractionElement = Player.ReturnCurrentInteractElement(ref Program.currentElement);

                if (Program.InteractWithElement(Program.trainingElements[2]))
                {
                    Program.trainingElements[2] = null;
                    Program.trainingMap.ClearAdd(Program.trainingElements);
                    Player.Items.Add("КИРКА");
                    Program.trainingElements[1] = new Wall(30, true, "", "");
                    goal31 = true;
                }

                Program.trainingMap.Draw();
            }

            bool goal32 = false;

            while (!goal32)
            {
                Player.MoveOrInteract();
                Program.currentElement = Player.ReturnCurrentlement(ref Program.trainingElements);
                Program.currentInteractionElement = Player.ReturnCurrentInteractElement(ref Program.currentElement);

                if (Program.InteractWithElement(Program.trainingElements[1]) && Player.DoIHaveTheItem("КИРКА"))
                {
                    Program.trainingElements[1] = null;
                    Program.trainingMap.ClearAdd(Program.trainingElements);
                    Player.Energy -= 10;
                    goal32 = true;
                }

                Program.trainingMap.Draw();
            }

            Map.OutputInteraction.Append("Слева от тебя что-то лежит...");
            Program.trainingElements[0] = new Fruit(23, true, "", "");
            Program.trainingMap.ClearAdd(Program.trainingElements);
            Program.trainingMap.Draw();
            System.Threading.Thread.Sleep(shortSleep);
            bool goal4 = false;

            while (!goal4)
            {
                Player.MoveOrInteract();
                Program.currentElement = Player.ReturnCurrentlement(ref Program.trainingElements);
                Program.currentInteractionElement = Player.ReturnCurrentInteractElement(ref Program.currentElement);

                if (Program.InteractWithElement(Program.trainingElements[0]))
                {
                    Program.trainingElements[0] = null;
                    Program.trainingMap.ClearAdd(Program.trainingElements);
                    Player.Energy += 20;
                    Player.Health += 1;
                    goal4 = true;
                }

                Program.trainingMap.Draw();
            }

            Map.OutputInteraction.Append("Но оно не всегда полезно");
            Program.trainingElements[0] = new SmallBush(38, true, "съесть", " куст ягод неизвестного происхождения");
            Program.trainingMap.ClearAdd(Program.trainingElements);
            Program.trainingMap.Draw();
            System.Threading.Thread.Sleep(shortSleep);

            bool goal5 = false;

            while (!goal5)
            {
                Player.MoveOrInteract();
                Program.currentElement = Player.ReturnCurrentlement(ref Program.trainingElements);
                Program.currentInteractionElement = Player.ReturnCurrentInteractElement(ref Program.currentElement);

                if (Program.InteractWithElement(Program.trainingElements[0]))
                {
                    Program.trainingElements[0] = null;
                    Program.trainingMap.ClearAdd(Program.trainingElements);
                    Player.Energy -= 20;
                    Player.Health -= 1;
                    goal5 = true;
                }

                Program.trainingMap.Draw();
            }

            Player.X = 21;

            Map.OutputInteraction.Append("Разговаривая с мобами можно получить важную информацию");
            Program.trainingElements[0] = new Person(26, true, "", "");

            Program.trainingMap.ClearAdd(Program.trainingElements);
            Program.trainingMap.Draw();
            System.Threading.Thread.Sleep(longSleep);

            bool goal6 = false;

            while (!goal6)
            {
                Player.MoveOrInteract();
                Program.currentElement = Player.ReturnCurrentlement(ref Program.trainingElements);
                Program.currentInteractionElement = Player.ReturnCurrentInteractElement(ref Program.currentElement);

                if (Program.InteractWithElement(Program.trainingElements[0]))
                {
                    string[] questionsPattern = new string[] { "Что ты здесь делаешь?", "Что есть человек?", "Пока" };
                    string[] answersPattern = new string[] { "Я иду как глубокий старец, узревший вечное, &прикоснувшийся к божественному, сам стал богоподобен &и устремлён в это бесконечное. Я, бл***, в своём &познании настолько преисполнился, что я как будто &бы уже 100 триллионов миллиардов лет, бл***, проживаю &на триллионах и триллионах таких же планет, &понимаешь? Как эта Земля. Мне уже этот мир абсолютно &понятен, и я здесь ищу только одного: &покоя, умиротворения и вот этой гармонии от слияния с &бесконечно вечным.", "Двуногое без перьев - сказал Платон,&за что был послан Диогеном", "ExitDialog" };
                    Player.Dialog(questionsPattern, answersPattern);
                    goal6 = true;
                }

                Program.trainingMap.Draw();
            }

            Person person = (Person)Program.trainingElements[0];
            person.Items.AddRange(new string[] { "ФЛЯГА СПИРТА", "10", "НОЖ", "20", "КАРТА МЕСТНОСТИ", "5", "АВТОМАТ ПО ДЕГТЯРЁВУ", "200" });

            Map.OutputInteraction.Append("Или купить что-нибудь ценное");
            Program.trainingMap.Draw();
            System.Threading.Thread.Sleep(longSleep);
            Map.OutputInteraction.Append("Купи у него карту местности");
            Program.trainingMap.Draw();
            System.Threading.Thread.Sleep(shortSleep);

            bool goal7 = false;

            while (!goal7)
            {
                Player.MoveOrInteract();
                Program.currentElement = Player.ReturnCurrentlement(ref Program.trainingElements);
                Program.currentInteractionElement = Player.ReturnCurrentInteractElement(ref Program.currentElement);

                if (Program.InteractWithElement(Program.trainingElements[0]))
                {
                    string[] questionsPattern = new string[] { "Торговать", "Пока" };
                    string[] answersPattern = new string[] { "Trade", "ExitDialog" };
                    Player.Dialog(questionsPattern, answersPattern);
                }

                if (Player.DoIHaveTheItem("КАРТА МЕСТНОСТИ"))
                {
                    goal7 = true;
                }
                Program.trainingMap.Draw();
            }

            Map.OutputInteraction.Append("Отлично! Теперь нажми G, чтобы посмотреть свой инвентарь");
            Program.trainingMap.Draw();
            System.Threading.Thread.Sleep(shortSleep);

            bool goal8 = false;

            while (!goal8)
            {
                ConsoleKeyInfo key = Console.ReadKey();
                switch (key.Key.ToString())
                {
                    case "G":
                        Player.WantToInteract = false;
                        Player.ShowInventory();
                        goal8 = true;
                        break;
                    default:
                        Player.WantToInteract = false;
                        break;
                }

                Program.currentElement = Player.ReturnCurrentlement(ref Program.trainingElements);
                Program.currentInteractionElement = Player.ReturnCurrentInteractElement(ref Program.currentElement);



                Program.trainingMap.Draw();
            }

            Map.OutputInteraction.Append("Теперь попробуй пройти в другую локацию");
            Program.trainingElements[0] = new Person(26, false, "", "НОУНЕЙМ ЧЕЛИК");
            Program.trainingElements.Add(new Pass(10, true, "", "ДРУГАЯ ЛОКАЦИЯ"));
            Program.trainingMap.ClearAdd(Program.trainingElements);
            Program.trainingMap.Draw();
            System.Threading.Thread.Sleep(shortSleep);

            bool goal9 = false;



            while (!goal9)
            {
                Player.MoveOrInteract();
                Program.currentElement = Player.ReturnCurrentlement(ref Program.trainingElements);
                Program.currentInteractionElement = Player.ReturnCurrentInteractElement(ref Program.currentElement);

                if (Program.InteractWithElement(Program.trainingElements[3]))
                {
                    goal9 = true;
                    AnotherScene();
                }

                Program.trainingMap.Draw();
            }
        }

        public static void GameOver()
        {
            Console.ReadLine();
            Environment.Exit(0);
        }

        public static void AnotherScene()
        {
            Program.anotherLocationMap.Draw();
            System.Threading.Thread.Sleep(longSleep);

            Console.Clear();
            Console.WriteLine("Поздравляю! Теперь ты готов исследовать этот мир");
            Console.WriteLine("");
            Console.WriteLine(">>OK");
            Console.ReadLine();
            Menu();
        }
    }
}
