namespace DelegateAndEventsTest;

public delegate void AccountHandler(string message);
internal class Account
{
	public int sum;
	AccountHandler? taken;

	public Account(int sum) => this.sum = sum;

	public void RegisterHandler(AccountHandler del) => taken += del;
	public void UnregisterHandler(AccountHandler del) => taken -= del;

	public void Add(int sum) => this.sum += sum;
	public void Take(int sum)
	{
		if (this.sum >= sum)
		{
			this.sum -= sum;
			taken?.Invoke($"Со счета списано {sum} y.e");
		}
		else
			taken?.Invoke($"Недостаточно средств. Баланс: {this.sum} y.e");
	}
}
