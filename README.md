# 🎯 Coherence Filter Engine v2.1

**Validate your game logic before your players break it.**

The **Coherence Filter Engine** is a lightweight, platform-agnostic system for verifying game state consistency. It helps Unity and Unreal developers detect **contradictions, impossible logic states, broken quest chains, or invalid narrative branches** — *before* they reach production.

---

## 🧠 What It Does

- ✅ Accepts rules in simple JSON or Blueprint-friendly format
- ✅ Evaluates current game state against logic rules
- ✅ Outputs `PASS` or `FAIL` messages with custom descriptions
- ✅ Modular: Drop into Unity or Unreal in minutes
- ✅ Completely offline – no network, no tracking

> Think of it like **unit tests for game logic and narrative flow.**

---

## 🎮 Use Cases

| Scenario | Example |
|----------|---------|
| 🚫 Broken Quest Flow | "Quest 5 triggered before Quest 2 was completed" |
| 🤖 AI Logic Gaps | "Enemy isDead = true but still attacking" |
| 🧩 Dialogue Conflicts | "NPC says player has key when they don't" |
| 🔐 Progression Bugs | "Door opens without required event" |

---

## 🔧 Unity Setup

1. Copy `Refactored_Unity/` into `Assets/`
2. Add `CoherenceManager` to any GameObject
3. Create `StreamingAssets/CoherenceRuleSet.json`
4. Press play – violations will log to Console

---

## 🛠️ Unreal Setup

1. Copy `UCoherenceFilterComponent/` into your plugin or game code
2. Include the component in any Blueprint Actor
3. Add `CoherenceRuleSet.json` to `/Content/`
4. Call `RunCoherenceCheck()` in Blueprint or `BeginPlay`

---

## 🧪 Example Rule (`CoherenceRuleSet.json`)

```json
{
  "rules": [
    {
      "id": "npc_logic_conflict",
      "description": "An NPC cannot be both dead and conscious.",
      "if": {
        "AND": [
          { "eq": ["isDead", true] },
          { "eq": ["isConscious", true] }
        ]
      },
      "message": "NPC is marked isDead=true but also isConscious=true"
    }
  ]
}
