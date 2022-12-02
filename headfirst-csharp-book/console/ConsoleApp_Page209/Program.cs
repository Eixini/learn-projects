class Program
{
    static void Main(string[] args)
    {
        int myInt = 10;
        byte myByte = (byte)myInt;
        double myDouble = (double)myByte;
        bool myBool = (bool)myDouble;
        string myString = "false";
        myBool = (bool)myString;
        myString = myInt.ToString();
        myBool = (bool)myByte;
        myByte = (byte)myBool;
        short myShort = (short)myInt;
        char myChar = 'x';
        myString = (string)myChar;
        long myLong = (long)myInt;
        decimal myDecimal = (decimal)myLong;
        myString = myString + myInt + myByte + myDouble + myChar;
    }
}
