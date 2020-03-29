using System;
using System.Collections.Generic;

namespace quest_game_cs
{
    class Person : Element
    {
        public Person(int x, bool interaction, string interactionText, string descriptionText) : base(x, interaction)
        {
            Width = 5;
            Height = 4;
            Name = "Person";
            Surface.Add("  o  ");
            Surface.Add(" /|\\ ");
            Surface.Add("  |  ");
            Surface.Add(" / \\ ");

            
            if (descriptionText == "")
            {
                this.DescriptionText = "ЧЕЛОВЕК";
            }
            else
            {
                this.DescriptionText = descriptionText.ToUpper();
            }
            if (interactionText == "")
            {
                this.InteractionText = "F: ПОГОВОРИТЬ" + " (" + this.DescriptionText + ")";
            }
            else
            {
                this.InteractionText = "F: " + interactionText.ToUpper() + " (" + this.DescriptionText + ")";
            }
        }
        private List<string> items = new List<string>();
        public List<string> Items
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
    }
    class Tree : Element
    {
        public Tree(int x, bool interaction, string interactionText, string descriptionText) : base(x, interaction)
        {
            Width = 9;
            Height = 5;
            Name = "Tree";
            Surface.Add("    _    ");
            Surface.Add("   /|\\   ");
            Surface.Add("  / | \\  ");
            Surface.Add(" /__|__\\ ");
            Surface.Add("    |    ");
            
            if (descriptionText == "")
            {
                this.DescriptionText = "ДЕРЕВО";
            }
            else
            {
                this.DescriptionText = descriptionText.ToUpper();
            }
            if (interactionText == "")
            {
                this.InteractionText = "F: СРУБИТЬ" + " (" + this.DescriptionText + ")";
            }
            else
            {
                this.InteractionText = "F: " + interactionText.ToUpper() + " (" + this.DescriptionText + ")";
            }
        }
    }
    class SmallBush:Element
    {
        public SmallBush(int x, bool interaction, string interactionText, string descriptionText) : base(x, interaction)
        {
            Width = 5;
            Height = 2;
            Name = "SmallBush";
            Surface.Add(" \\|/ ");
            Surface.Add("  |  ");

            if (descriptionText == "")
            {
                this.DescriptionText = "МАЛЕНЬКИЙ КУСТ";
            }
            else
            {
                this.DescriptionText = descriptionText.ToUpper();
            }
            if (interactionText == "")
            {
                this.InteractionText = "F: СРУБИТЬ" + " (" + this.DescriptionText + ")";
            }
            else
            {
                this.InteractionText = "F: " + interactionText.ToUpper() + " (" + this.DescriptionText + ")";
            }
        }
    }
    class NormalBush : Element
    {
        public NormalBush(int x, bool interaction, string interactionText, string descriptionText) : base(x, interaction)
        {
            Width = 5;
            Height = 3;
            Name = "NormalBush";
            Surface.Add(" \\|/ ");
            Surface.Add("  |  ");
            Surface.Add("  |  ");
 
            if (descriptionText == "")
            {
                this.DescriptionText = "КУСТ";
            }
            else
            {
                this.DescriptionText = descriptionText.ToUpper();
            }
            if (interactionText == "")
            {
                this.InteractionText = "F: СРУБИТЬ" + " (" + this.DescriptionText + ")";
            }
            else
            {
                this.InteractionText = "F: " + interactionText.ToUpper() + " (" + this.DescriptionText + ")";
            }

        }
    }
    class BigBush : Element
    {
        public BigBush(int x, bool interaction, string interactionText, string descriptionText) : base(x, interaction)
        {
            Width = 5;
            Height = 5;
            Name = "BigBush";
            Surface.Add(" \\|/ ");
            Surface.Add("  |  ");
            Surface.Add("  |  ");
            Surface.Add("  |  ");
            Surface.Add("  |  ");

            if (descriptionText == "")
            {
                this.DescriptionText = "БОЛЬШОЙ КУСТ";
            }
            else
            {
                this.DescriptionText = descriptionText.ToUpper();
            }
            if (interactionText == "")
            {
                this.InteractionText = "F: СРУБИТЬ" + " (" + this.DescriptionText + ")";
            }
            else
            {
                this.InteractionText = "F: " + interactionText.ToUpper() + " (" + this.DescriptionText + ")";
            }
        }
    }
    class House : Element
    {
        public House(int x, bool interaction, string interactionText, string descriptionText) : base(x, interaction)
        {
            Width = 26;
            Height = 9;
            Name = "House";
            Surface.Add("     ________________     ");
            Surface.Add("    /\\               \\    ");
            Surface.Add("   /  \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\   ");
            Surface.Add("  /    \\               \\  ");
            Surface.Add(" /______\\_______________\\ ");
            Surface.Add(" |  __   |              | ");
            Surface.Add(" | |__|  |              | ");
            Surface.Add(" | |__|  |              | ");
            Surface.Add(" |_______|______________| ");

            if (descriptionText == "")
            {
                this.DescriptionText = "ДОМ";
            }
            else
            {
                this.DescriptionText = descriptionText.ToUpper();
            }
            if (interactionText == "")
            {
                this.InteractionText = "F: ВОЙТИ" + " (" + this.DescriptionText + ")";
            }
            else
            {
                this.InteractionText = "F: " + interactionText.ToUpper() + " (" + this.DescriptionText + ")";
            }
        }
    }
    class Pass : Element
    {
        public Pass(int x, bool interaction, string interactionText, string descriptionText) : base(x, interaction)
        {
            Width = 9;
            Height = 5;
            Name = "Pass";
            Surface.Add("  _____  ");
            Surface.Add(" |     | ");
            Surface.Add(" |     | ");
            Surface.Add(" |     | ");
            Surface.Add(" |/___\\| ");

            if (descriptionText == "")
            {
                this.DescriptionText = "ВЫХОД";
            }
            else
            {
                this.DescriptionText = descriptionText.ToUpper();
            }

            if (interactionText == "")
            {
                this.InteractionText = "F: ПОЙТИ" + " (" + this.DescriptionText + ")";
            }
            else
            {
                this.InteractionText = "F: " + interactionText.ToUpper() + " (" + this.DescriptionText + ")";
            }
        }
    }
    class Teleport : Element
    {
        public Teleport(int x, bool interaction, string interactionText, string descriptionText) : base(x, interaction)
        {
            Width = 5;
            Height = 6;
            Name = "Teleport";
            Surface.Add("  _  ");
            Surface.Add(" | | ");
            Surface.Add("  `  ");
            Surface.Add("  `  ");
            Surface.Add("  `  ");
            Surface.Add(" |_| ");

            if (descriptionText == "")
            {
                this.DescriptionText = "ТЕЛЕПОРТ";
            }
            else
            {
                this.DescriptionText = descriptionText.ToUpper();
            }
            if (interactionText == "")
            {
                this.InteractionText = "F: ПРОЙТИ ВНУТРЬ" + " (" + this.DescriptionText + ")";
            }
            else
            {
                this.InteractionText = "F: " + interactionText.ToUpper() + " (" + this.DescriptionText + ")";
            }
        }
    }
    class Bottle : Element
    {
        public Bottle(int x, bool interaction, string interactionText, string descriptionText) : base(x, interaction)
        {
            Width = 8;
            Height = 6;
            Name = "Bottle";
            Surface.Add("   __   ");
            Surface.Add("   ||   ");
            Surface.Add("  /  \\  ");
            Surface.Add(" |    | ");
            Surface.Add(" |    | ");
            Surface.Add(" \\____/ ");


            if (descriptionText == "")
            {
                this.DescriptionText = "БУТЫЛКА";
            }
            else
            {
                this.DescriptionText = descriptionText.ToUpper();
            }
            if (interactionText == "")
            {
                this.InteractionText = "F: ВЫПИТЬ" + " (" + this.DescriptionText + ")";
            }
            else
            {
                this.InteractionText = "F: " + interactionText.ToUpper() + " (" + this.DescriptionText + ")";
            }
        }
    }
    class Wall : Element
    {
        public Wall(int x, bool interaction, string interactionText, string descriptionText) : base(x, interaction)
        {
            Width = 4;
            Height = 8;
            Name = "Wall";
            Surface.Add(" ## ");
            Surface.Add(" ## ");
            Surface.Add(" ## ");
            Surface.Add(" ## ");
            Surface.Add(" ## ");
            Surface.Add(" ## ");
            Surface.Add(" ## ");
            Surface.Add(" ## ");


            if (descriptionText == "")
            {
                this.DescriptionText = "СТЕНА";
            }
            else
            {
                this.DescriptionText = descriptionText.ToUpper();
            }
            if (interactionText == "")
            {
                this.InteractionText = "F: СЛОМАТЬ" + " (" + this.DescriptionText + ")";
            }
            else
            {
                this.InteractionText = "F: " + interactionText.ToUpper() + " (" + this.DescriptionText + ")";
            }
        }
    }
    class Fruit : Element
    {
        public Fruit(int x, bool interaction, string interactionText, string descriptionText) : base(x, interaction)
        {
            Width = 3;
            Height = 1;
            Name = "Fruit";
            Surface.Add(" @ ");


            if (descriptionText == "")
            {
                this.DescriptionText = "ЯБЛОКО";
            }
            else
            {
                this.DescriptionText = descriptionText.ToUpper();
            }
            if (interactionText == "")
            {
                this.InteractionText = "F: СЪЕСТЬ" + " (" + this.DescriptionText + ")";
            }
            else
            {
                this.InteractionText = "F: " + interactionText.ToUpper() + " (" + this.DescriptionText + ")";
            }
        }
    }
    class Axe : Element
    {
        public Axe(int x, bool interaction, string interactionText, string descriptionText) : base(x, interaction)
        {
            Width = 4;
            Height = 2;
            Name = "Axe";
            Surface.Add(" <| ");
            Surface.Add(" |  ");


            if (descriptionText == "")
            {
                this.DescriptionText = "ТОПОР";
            }
            else
            {
                this.DescriptionText = descriptionText.ToUpper();
            }
            if (interactionText == "")
            {
                this.InteractionText = "F: ПОДОБРАТЬ" + " (" + this.DescriptionText + ")";
            }
            else
            {
                this.InteractionText = "F: " + interactionText.ToUpper() + " (" + this.DescriptionText + ")";
            }
        }
    }
    class PickAxe : Element
    {
        public PickAxe(int x, bool interaction, string interactionText, string descriptionText) : base(x, interaction)
        {
            Width = 5;
            Height = 2;
            Name = "PickAxe";
            Surface.Add(" <|> ");
            Surface.Add("  |  ");


            if (descriptionText == "")
            {
                this.DescriptionText = "КИРКА";
            }
            else
            {
                this.DescriptionText = descriptionText.ToUpper();
            }
            if (interactionText == "")
            {
                this.InteractionText = "F: ПОДОБРАТЬ" + " (" + this.DescriptionText + ")";
            }
            else
            {
                this.InteractionText = "F: " + interactionText.ToUpper() + " (" + this.DescriptionText + ")";
            }
        }
    }
}
