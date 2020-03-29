using System;
using System.Collections.Generic;

namespace quest_game_cs
{
    abstract class Element
    {
        public Element(int x, bool interaction)
        {
            if (x > 0 && x < Map.MapWidth - width)
            {
                this.x = x;
            }
            else
            {
                this.x = 1;
            }
            this.y = Map.GetYFloor();
            this.interaction = interaction;
        }
        private int x, y;
        private int height;
        private int width;
        private string name;
        private List<string> surface = new List<string>();
        private bool interaction;
        private string interactionText;
        private string descriptionText;

        public string Name
        {
            get
            {
                return name;
            }
            protected set
            {
                name = value;
            }
        }
        public string DescriptionText
        {
            get
            {
                return descriptionText;
            }
            protected set
            {
                descriptionText = value;
            }
        }
        public bool Interaction
        {
            get
            {
                return interaction;
            }
            set
            {
                interaction = value;
            }
        }
        public string InteractionText
        {
            get
            {
                return interactionText;
            }
            set
            {
                interactionText = value;
            }
        }
        public int X
        {
            get
            {
                return this.x;
            }
            set
            {
                if (value > 0 && value < Map.MapWidth - Width)
                {
                    this.x = value;
                }
            }
        }
        public int Y
        {
            get
            {
                return this.y;
            }
        }

        public int Height
        {
            get
            {
                return height;
            }
            protected set
            {
                height = value;
            }
        }
        public int Width
        {
            get
            {
                return width;
            }
            protected set
            {
                width = value;
            }
        }

        public List<string> Surface
        {
            get
            {
                return surface;
            }
            protected set
            {
                surface = value;
            }
        }
        public static List<Element> CreateElements(params string[] args)
        {
            int len = args.Length;

                List<Element> elements = new List<Element>();

                for (int i = 0; i < len;)
                {
                    switch (args[i])
                    {
                        case "Teleport":
                            Teleport teleport = new Teleport(Convert.ToInt32(args[i + 1]), Convert.ToBoolean(args[i + 2]), args[i + 3], args[i + 4]);
                            elements.Add(teleport);
                            i += 5;
                            break;
                        case "Bottle":
                            Bottle bottle = new Bottle(Convert.ToInt32(args[i + 1]), Convert.ToBoolean(args[i + 2]), args[i + 3], args[i + 4]);
                            elements.Add(bottle);
                            i += 5;
                            break;
                        case "House":
                            House house = new House(Convert.ToInt32(args[i + 1]), Convert.ToBoolean(args[i + 2]), args[i + 3], args[i + 4]);
                            elements.Add(house);
                            i += 5;
                            break;
                        case "Tree":
                            Tree tree = new Tree(Convert.ToInt32(args[i + 1]), Convert.ToBoolean(args[i + 2]), args[i + 3], args[i + 4]);
                            elements.Add(tree);
                            i += 5;
                            break;
                        case "Person":
                            Person person = new Person(Convert.ToInt32(args[i + 1]), Convert.ToBoolean(args[i + 2]), args[i + 3], args[i + 4]);
                            elements.Add(person);
                            i += 5;
                            break;
                        case "NormalBush":
                            NormalBush normalBush = new NormalBush(Convert.ToInt32(args[i + 1]), Convert.ToBoolean(args[i + 2]), args[i + 3], args[i + 4]);
                            elements.Add(normalBush);
                            i += 5;
                            break;
                        case "SmallBush":
                            SmallBush smallBush = new SmallBush(Convert.ToInt32(args[i + 1]), Convert.ToBoolean(args[i + 2]), args[i + 3], args[i + 4]);
                            elements.Add(smallBush);
                            i += 5;
                            break;
                        case "BigBush":
                            BigBush bigBush = new BigBush(Convert.ToInt32(args[i + 1]), Convert.ToBoolean(args[i + 2]), args[i + 3], args[i + 4]);
                            elements.Add(bigBush);
                            i += 5;
                            break;
                        case "Pass":
                            Pass pass = new Pass(Convert.ToInt32(args[i + 1]), Convert.ToBoolean(args[i + 2]), args[i + 3], args[i + 4]);
                            elements.Add(pass);
                            i += 5;
                            break;
                        case "Wall":
                            Wall wall = new Wall(Convert.ToInt32(args[i + 1]), Convert.ToBoolean(args[i + 2]), args[i + 3], args[i + 4]);
                            elements.Add(wall);
                            i += 5;
                            break;
                        case "Fruit":
                            Fruit fruit = new Fruit(Convert.ToInt32(args[i + 1]), Convert.ToBoolean(args[i + 2]), args[i + 3], args[i + 4]);
                            elements.Add(fruit);
                            i += 5;
                            break;
                        case "Axe":
                            Axe axe = new Axe(Convert.ToInt32(args[i + 1]), Convert.ToBoolean(args[i + 2]), args[i + 3], args[i + 4]);
                            elements.Add(axe);
                            i += 5;
                            break;
                        case "PickAxe":
                            PickAxe pickAxe = new PickAxe(Convert.ToInt32(args[i + 1]), Convert.ToBoolean(args[i + 2]), args[i + 3], args[i + 4]);
                            elements.Add(pickAxe);
                            i += 5;
                            break;
                        default:
                            string message = "Pattern is invalid";
                            throw new Exception(message);
                    }
                }
                return elements;
        }
    }
}
