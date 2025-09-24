using UnityEngine;
using System.IO;

public class CoherenceManager : MonoBehaviour
{
    public string rulesetFilename = "CoherenceRuleSet.json";

    void Start()
    {
        RunCoherenceCheck();
    }

    public void RunCoherenceCheck()
    {
        string path = Path.Combine(Application.streamingAssetsPath, rulesetFilename);
        if (!File.Exists(path))
        {
            Debug.LogError($"[Coherence] Rule set file not found: {path}");
            return;
        }

        string json = File.ReadAllText(path);
        var rules = JsonUtility.FromJson<CoherenceRuleSet>(json);

        foreach (var rule in rules.rules)
        {
            if (rule.Evaluate(GameState.Instance))
            {
                Debug.Log($"[PASS] {rule.id}");
            }
            else
            {
                Debug.LogWarning($"[FAIL] {rule.message}");
            }
        }
    }
}

[System.Serializable]
public class CoherenceRuleSet
{
    public CoherenceRule[] rules;
}

[System.Serializable]
public class CoherenceRule
{
    public string id;
    public string message;

    public bool Evaluate(GameState game)
    {
        // Placeholder logic — replace with real rule evaluation
        return true;
    }
}
