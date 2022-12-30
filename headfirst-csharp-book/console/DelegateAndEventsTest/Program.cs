namespace DelegateAndEventsTest;

public class Program
{
	public static void Main(string[] args)
	{
		Account account = new Account(200);

		account.RegisterHandler(PrintSimpleMessage);
		account.RegisterHandler(PrintColorMessage);

		account.Take(100);
		account.Take(100);

		account.UnregisterHandler(PrintColorMessage);

		account.Take(50);
	}

	void  PrintSimpleMessage(string message) => Console.WriteLine(message);
	void PrintColorMessage(string message)
	{
		Console.ForegroundColor = ConsoleColor.Red;
		Console.WriteLine(message);
		Console.ResetColor();
	}
}