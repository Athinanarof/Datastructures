using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter
{
    class Program
    {
        static void Main(string[] args)
        {
            AnimalQueue queue = new AnimalQueue();
            queue.Enqueue(new Cat("Peludito"));
            queue.Enqueue(new Dog("Solovino"));
            queue.Enqueue(new Dog("Tequila"));

            Animal animal = queue.DequeueAny();
        }
    }

    class AnimalQueue
    {
        LinkedList<Dog> dogs = new LinkedList<Dog>();
        LinkedList<Cat> cats = new LinkedList<Cat>();
        private int order = 0;

        public void Enqueue(Animal a)
        {
            a.SetOrder(order);
            order++;

            if (typeof(Dog).IsInstanceOfType(a))
            {
                dogs.AddLast((Dog)a);
            }
            else if (typeof(Cat).IsInstanceOfType(a))
            {
                cats.AddLast((Cat)a);
            }
        }

        public Animal DequeueAny()
        {
            if (dogs.Count == 0)
            {
                return DequeueCats();
            }
            else if (cats.Count == 0)
            {
                return DequeueDogs();
            }

            Dog dog = dogs.First();
            Cat cat = cats.First();
            if (dog.IsOlderThan(cat))
            {
                return DequeueDogs();
            }
            else
            {
                return DequeueCats();
            }
        }

        private Animal DequeueDogs()
        {
            Dog dog = dogs.First();
            dogs.RemoveFirst();
            return dog;
        }

        private Animal DequeueCats()
        {
            Cat cat = cats.First();
            cats.RemoveFirst();
            return cat;
        }
    }
    public abstract class Animal
    {
        private int Order; // This should be accessible only by the class, is not correct compare the order values in order class due to protection level and encapsulation
        protected string Name;
        public Animal(string name)
        {
            this.Name = name;
        }
        public void SetOrder(int order)
        {
            this.Order = order;
        }
        public int GetOrder()
        {
            return Order;
        }

        public bool IsOlderThan(Animal a)
        {
            return this.Order < a.GetOrder();
        }
    }
}
