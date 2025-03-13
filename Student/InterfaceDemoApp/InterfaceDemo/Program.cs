using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceDemoApp
{
	public class Program
	{
		public static Main()
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


	public interface() : IRun
	{
		int Run();
	}

	public class Person : IRun
	{
		int Run()
		{
			Console.WriteLine("I can run the 40 yd dash in 4.3 seconds.");
		}
	}

	public class Animal : IRun
	{
		int Run()
		{
			Console.WriteLine("Depends on which kind of animal.");
		}
	}

	public class Tortoise : Animal
	{
		int Run()
		{
			Console.WriteLine("I can run the 40 yd dash in 1 hour 35 minutes and 2.1 seconds.");
		}
	}

	public class Hare : Animal
	{
		int Run()
		{
			Console.WriteLine("I can run the 40 yd dash in 7.0 seconds.");
		}
	}

}