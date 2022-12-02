namespace GuyAndCash;

class Guy {

    public string Name;
    public int Cash;

    /// <summary>
    /// Выводит значение моих полей Name и Cash на консоль.
    /// </summary>
    public void WriteMyInfo() {
        Console.WriteLine(Name + " has " + Cash );
    }

    /// <summary>
    /// Выдает часть моих денег, удаляя их иэ кармана (или выводит на консоль сообщение о том,
    /// что денег недостаточно).
    /// </summary>
    /// <param name="amount">Выдаваемая сумма.</param>
    /// <returns>
    /// Сумма денег, взятая из кармана, или 0, если денег не хватает
    /// (или если сумма недействительна)</returns>
    public int GiveCash(int amount) {
        if (amount <= 0) {
            Console.WriteLine(Name + " says:" + amount + "isn't a valid amount");
            return 0;
        }
        if (amount > Cash) {
            Console.WriteLine(Name + " says: " + "I don't have enough cash to give you " + amount);
            return 0;
        }
        Cash -= amount;
        return amount;
    }

    /// <summary>
    /// Получает деньги, добавляя их в мой карман
    /// (или выводит сообщение на консоль, что сумма недействительна).
    /// </summary>
    /// <param name="amount">Получаемая сумма.</param>
    public void ReceiveCash(int amount) {
        if (amount <= 0)
            Console.WriteLine(Name + " says: " + amount + "isn't an amount I'll take");
        else
            Cash += amount;
    }

}
