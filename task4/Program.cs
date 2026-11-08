using System;
using System.Collections.Generic;

namespace ChristmasTreeDecorator
{
    //Component
    public interface ITree
    {
        string GetDescription();
        void Display();
    }

    //ConcreteComponent
    public class ChristmasTree : ITree
    {
        public string GetDescription()
        {
            return "Regular green Christmas tree";
        }

        public void Display()
        {
            Console.WriteLine(GetDescription());
        }
    }

    //Decorator
    public abstract class TreeDecorator : ITree
    {
        protected ITree tree_;

        public TreeDecorator(ITree tree)
        {
            tree_ = tree;
        }

        public virtual string GetDescription()
        {
            return tree_.GetDescription();
        }

        public virtual void Display()
        {
            tree_.Display();
        }
    }

    // Decorator for ornaments (adds characteristics)
    public class OrnamentDecorator : TreeDecorator
    {
        private readonly List<string> ornaments_;

        public OrnamentDecorator(ITree tree, List<string> ornaments) : base(tree)
        {
            ornaments_ = ornaments;
        }

        public override string GetDescription()
        {
            return base.GetDescription() + ", decorated with: [" + string.Join(", ", ornaments_) + "]";
        }

        public override void Display()
        {
            base.Display();
            Console.WriteLine($"Added decorations on Christmas tree: {string.Join(", ", ornaments_)}");
        }
    }

    // Decorator for garland (adds glow)
    public class GarlandDecorator : TreeDecorator
    {
        private readonly string garland_color_;

        public GarlandDecorator(ITree tree, string garland_color) : base(tree)
        {
            garland_color_ = garland_color;
        }

        public override string GetDescription()
        {
            return base.GetDescription() + $", with garland color: {garland_color_}";
        }

        public override void Display()
        {
            base.Display();
            LightUp();
        }

        // Method that is responsible for tree's lighting
        public void LightUp()
        {
            Console.WriteLine($"Christmas tree lights with {garland_color_} garland!");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ITree myTree = new ChristmasTree();
            Console.WriteLine("--- Initial state ---");
            myTree.Display();
            Console.WriteLine();
            myTree = new OrnamentDecorator(myTree, new List<string> { "balls", "icicles", "star for the top" });
            Console.WriteLine("--- After adding ornaments ---");
            myTree.Display();
            Console.WriteLine();
            myTree = new GarlandDecorator(myTree, "yellow and red");
            Console.WriteLine("--- After adding garland ---");
            myTree.Display();
            Console.ReadKey();
        }
    }
}