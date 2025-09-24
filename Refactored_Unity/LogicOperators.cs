using System.Collections.Generic;

public static class LogicOperators
{
    public static bool AND(List<bool> values)
    {
        foreach (var v in values)
        {
            if (!v) return false;
        }
        return true;
    }

    public static bool OR(List<bool> values)
    {
        foreach (var v in values)
        {
            if (v) return true;
        }
        return false;
    }

    public static bool NOT(bool value)
    {
        return !value;
    }
}
