using System;
class Change
{
    public static int Intify(float number)
    {
        return (Convert.ToInt32(Convert.ToString(number).Substring(0, 1)));
    }
    public static int Intify(int number)
    {
        return (number);
    }
}