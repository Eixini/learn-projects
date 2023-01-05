namespace CreateServices;

public class ShortTimeServices : ITimeService
{
	public string GetTime() => DateTime.Now.ToShortTimeString();
}
