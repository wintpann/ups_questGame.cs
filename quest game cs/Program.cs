using System;
using System.Collections.Generic;
using System.Text;

namespace quest_game_cs
{
    class Program
    {
        public static bool InteractWithElement(Element element)
        {
            if (Player.WantToInteract && element == currentInteractionElement && element != null)
            {
                return true;
            }
            return false;
        }

        static void Setup()
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            Console.SetWindowSize(Player.VisibilityRange+1, Map.MapHeight + 3);
            Console.Title = "ОСНОВНЫЕ ПОНЯТИЯ ЯЗЫКА С#";

            creatingElements = Element.CreateElements();
            creatingMap.Add(creatingElements);

            trainingElements = Element.CreateElements();
            trainingMap.Add(trainingElements);

            anotherLocationElements = Element.CreateElements("Bottle", "20", "false", "", "", "Person", "30", "false", "", "", "Tree", "40", "false", "", "", "Pass", "10", "false", "", "");
            anotherLocationMap.Add(anotherLocationElements);

            mainElements = Element.CreateElements("House", "15", "False", "", "ЧЕЙ-ТО ДОМ", "Fruit", "67", "False", "", "", "Tree", "81", "False", "", "ДУБ", "Person", "91", "True", "ДАТЬ ПОЛТОС", "БОМЖ ВАЛЕРИЙ");
            mainMap.Add(mainElements);
        }

        public static Element currentInteractionElement = null;
        public static Element currentElement = null;

        public static List<Element> creatingElements;
        public static Map creatingMap = new Map();

        public static List<Element> trainingElements;
        public static Map trainingMap = new Map();

        public static List<Element> anotherLocationElements;
        public static Map anotherLocationMap = new Map();

        public static List<Element> mainElements;
        public static Map mainMap = new Map();

        static void Main(string[] args)
        {
            Setup();
            Scenes.Menu();
        }
    }
}
