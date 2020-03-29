using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quest_game_cs
{
    static class MapCreator
    {
        public struct ElS
        {
            public ElS(string objC, string xC, string interactionC, string interactionActionC, string descriptionC)
            {
                obj = objC;
                x = xC;
                interaction = interactionC;
                interactionAction = interactionActionC;
                description = descriptionC;
            }

            public string obj;
            public string x;
            public string interaction;
            public string interactionAction;
            public string description;
        }
        public static string MapName { get; set; }
        private static List<string> existingElements = new List<string>();
        public static List<ElS> elS = new List<ElS>();

        static MapCreator()
        {
            MapName = "";
            existingElements.Add("Person");
            existingElements.Add("Tree");
            existingElements.Add("SmallBush");
            existingElements.Add("NormalBush");
            existingElements.Add("BigBush");
            existingElements.Add("House");
            existingElements.Add("Pass");
            existingElements.Add("Teleport");
            existingElements.Add("Bottle");
            existingElements.Add("Wall");
            existingElements.Add("Fruit");
            existingElements.Add("Axe");
            existingElements.Add("PickAxe");
            
        }
        public static void Initialize()
        {
            Console.Clear();
            Console.WriteLine("Стрелки ВЛЕВО ВПРАВО - перемещаться по карте");
            Console.WriteLine("F - создать объект");
            Console.WriteLine("X - завершить создание карты");
            Console.WriteLine("");
            Console.WriteLine(">> Понятно");
            Console.ReadLine();
            Console.Clear();
            Console.Write("Введите имя карты на латинице для дальнейшего встраивания в код\n>>");
            MapName = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("НЕ указывайте невалидные значения для избежания ошибок!!!!\nМне лень обрабатывать эти глупые исключения здесь\nВарианты валидных ответов будут указаны в скобках через пробел\n>>ОК");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("ОК ПОГНАЛИ");
            System.Threading.Thread.Sleep(800);

        }

        public static void CreateNewObject()
        {
            string obj;
            int x = Player.X;
            bool isInteraction = false;
            string interactionAction = "";
            string description = "";

            Console.Clear();
            foreach (string element in existingElements)
            {
                Console.Write(element+" ");
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Введите название объекта из списка выше");
            obj = Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Возможность взаимодействия с объектом (true false)");
            isInteraction = Convert.ToBoolean(Console.ReadLine());
            if (isInteraction)
            {
                Console.WriteLine("Действие с объектом (К примеру: ПОДОБРАТЬ, ТОЛКНУТЬ, ЗАЙТИ)\nВведите пустую строку для установки дефолтного значения");
                interactionAction = Console.ReadLine();
            }
            Console.WriteLine("Описание объекта\nВведите пустую строку для установки дефолтного значения");
            description = Console.ReadLine();

            List<Element> add = Element.CreateElements(obj, x.ToString(), isInteraction.ToString(), interactionAction, description);
            Program.creatingMap.Add(add);

            elS.Add(new ElS(obj, x.ToString(), isInteraction.ToString(), interactionAction, description));
        }
    }
}
