using System;
using System.Collections.Generic;

[System.Serializable]
public class RuleCondition
{
    public string eq;
    public string neq;
    public Dictionary<string, RuleCondition[]> AND;
    public Dictionary<string, RuleCondition[]> OR;
    public RuleCondition NOT;

    public bool Evaluate(GameState game)
    {
        if (eq != null)
            return GetGameStateValue(game, eq.Split(',')[0].Trim()) == ParseBool(eq.Split(',')[1].Trim());

        if (neq != null)
            return GetGameStateValue(game, neq.Split(',')[0].Trim()) != ParseBool(neq.Split(',')[1].Trim());

        if (AND != null)
        {
            foreach (var pair in AND)
            {
                var results = new List<bool>();
                foreach (var cond in pair.Value)
                    results.Add(cond.Evaluate(game));
                return LogicOperators.AND(results);
            }
        }

        if (OR != null)
        {
            foreach (var pair in OR)
            {
                var results = new List<bool>();
                foreach (var cond in pair.Value)
                    results.Add(cond.Evaluate(game));
                return LogicOperators.OR(results);
            }
        }

        if (NOT != null)
            return LogicOperators.NOT(NOT.Evaluate(game));

        return false;
    }

    private bool GetGameStateValue(GameState game, string field)
    {
        var fieldInfo = typeof(GameState).GetField(field);
        if (fieldInfo == null)
        {
            UnityEngine.Debug.LogError($"[Coherence] Field '{field}' not found on GameState.");
            return false;
        }
        return (bool)fieldInfo.GetValue(game);
    }

    private bool ParseBool(string input)
    {
        return input.ToLower() switch
        {
            "true" => true,
            "false" => false,
            _ => throw new Exception("Invalid boolean string")
        };
    }
}
