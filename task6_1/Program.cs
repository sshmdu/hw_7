using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creating fabrics array
            Creator[] creators = new Creator[3];
            creators[0] = new ConcreteCreatorA();
            creators[1] = new ConcreteCreatorB();
            creators[2] = new AudiCreator(); // Add factory for audi
            foreach (Creator creator in creators)
            {
                IProduct product = creator.FactoryMethod();
                product.Info();
            }
            Console.Read();
        }
    }

    // "Product"
    interface IProduct
    {
        void Info();
    }
    // "ConcreteProductA"
    class ConcreteProductA : IProduct
    {
        public void Info()
        {
            Console.WriteLine("Product A (Ford)");
        }
    }
    // "ConcreteProductB"
    class ConcreteProductB : IProduct
    {
        public void Info()
        {
            Console.WriteLine("Product B (Toyota)");
        }
    }

    // "ConcreteProductC"
    class AudiProduct : IProduct
    {
        public void Info()
        {
            Console.WriteLine("Product C (Audi)");
        }
    }

    // "Creator"
    abstract class Creator
    {
        public abstract IProduct FactoryMethod();
    }

    // "ConcreteCreatorA"
    class ConcreteCreatorA : Creator
    {
        public override IProduct FactoryMethod()
        {
            return new ConcreteProductA();
        }
    }

    // "ConcreteCreatorB"
    class ConcreteCreatorB : Creator
    {
        public override IProduct FactoryMethod()
        {
            return new ConcreteProductB();
        }
    }

    // "AudiCreator"
    class AudiCreator : Creator
    {
        public override IProduct FactoryMethod()
        {
            return new AudiProduct();
        }
    }
}