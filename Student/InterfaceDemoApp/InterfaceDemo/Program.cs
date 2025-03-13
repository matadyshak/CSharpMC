using System.Collections.Generic;

namespace InterfaceDemoApp
{
    public class Program
    {
        public static void Main()
        {
            Person person = new Person();
            Animal animal = new Animal();
            Tortoise tortoise = new Tortoise();
            Hare hare = new Hare();

            List<IRun> runners = new List<IRun>();

            runners.Add(person);
            runners.Add(animal);
            runners.Add(tortoise);
            runners.Add(hare);

            foreach (IRun runner in runners)
            {
                if (runner is Person p)
                {
                    p.Run();
                }

                if (runner is Animal a)
                {
                    a.Run();
                }

                if (runner is Tortoise t)
                {
                    t.Run();
                }

                if (runner is Hare h)
                {
                    h.Run();
                }
            }
        }
    }
}