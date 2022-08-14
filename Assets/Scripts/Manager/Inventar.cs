using System.Collections.Generic;
public static class Inventar
{
    private static List<string> inventar = new List<string>();

    public static bool AddToInventar(string element) 
    {
        if (!inventar.Contains(element) && element != null)
        {
            inventar.Add(element);
            return true;
        }
        else return false;
    }

    public static bool DelFromInventar(string element)
    {
        if (inventar.Contains(element))
        {
            inventar.Remove(element);
            return true;
        }
        else return false;
    }

    public static bool CheckInventar(string element) 
    {
        if (inventar.Contains(element)) return true;
        else return false;
    }

    public static string GetInventar()
    {
        string all = default;
        foreach (string el in inventar) 
        {
            all += (el+" ");
        }
        return all;
    }

}
