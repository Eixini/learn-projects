using System.Threading;

namespace MultiThreading_Test;

internal class Program
{
	static void Main(string[] args)
	{

		Thread myThread_1 = new Thread(() => {
			for (int i = 0; i < 10; i++)
			{
				Console.WriteLine($"Второй поток: {i}");
				Thread.Sleep(500);
			}
		});
		myThread_1.Start();

		Thread myThread_2 = new Thread(() => {
			for (int i = 0; i < 10; i++)
			{
				Console.WriteLine($"Третий поток: {i}");
				Thread.Sleep(1500);
			}
		});
		myThread_2.Start();

		for (int i = 0; i < 10; i++)
		{
			Console.WriteLine($"Главный поток: {i}");
			Thread.Sleep(2000);
		}
	}

}