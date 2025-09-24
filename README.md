# 🧠 Coherence Filter Engine (LoC-F)

A logic validation layer powered by the Logic of Coherence (LoC) framework.

This module detects broken or illogical game-world states using rule-based logic evaluation. Designed for runtime and editor-time validation across game engines.

---

## ⚙️ Rule Format (`LogicRuleSet.json`)

```json
{
  "id": "is-dead-but-has-health",
  "description": "Dead characters should not have health above 0.",
  "ifCondition": {
    "parameter": "isDead",
    "comparator": "eq",
    "value": "true"
  },
  "thenRequirements": [
    {
      "property": "health",
      "comparator": "eq",
      "expectedValue": "0"
    }
  ],
  "message": "Character is marked dead but has non-zero health."
}
```

---

## 🧩 Supported Logic Properties

| Property     | What It Means                                |
|--------------|-----------------------------------------------|
| `isDead`     | Whether the character is marked as dead       |
| `health`     | Current health value                          |
| `isVisible`  | Whether the object is being rendered          |
| `ammoCount`  | Ammo remaining in a weapon                    |

You can expand this by adding your own properties in `GetLogicProperty()`.

---

## ✨ Features

- Runtime logic validation  
- JSON rule system (readable, editable, expandable)  
- Supports: `isDead`, `health`, `ammoCount`, etc.  
- Comparators: `eq`, `ne`, `gt`, `lt`, `gte`, `lte`  
- Integrates with in-editor or runtime debugging  

**Extendable to:**

- Behavior trees and state machines  
- Inventory, combat, and quest systems  
- Multiplayer state sync validation  

---

## 🧠 Based on the LoC Framework

This is a core logic module for the broader Coherence Engine Stack, which includes:

- ✅ [Coherence Visual Validator (LoC-V)](https://github.com/coherence-engine-v2/Coherence-Visual-Validator)  
- 🧠 Coherence Filter Engine (Logic Layer)  
- 🧪 Coherence-Physics (future physical consistency layer)  
- 🤖 Coherence-AI (logic-driven NPC validation)

---

## 📝 License

Free for non-commercial evaluation.  
See `LICENSE-EVAL.txt` and `COMMERCIAL.md` for terms.

---

## 🛠️ Coming Soon

- Behavior tree + FSM validation  
- Live in-editor overlays  
- Unreal Engine integration  
- Multiplayer prediction mismatch detection  

---

## ✋ Contact

Built by **@NailerCole**  
Powered by 🧠 **Logic of Coherence (LoC)**  
📧 [nailercole@gmail.com](mailto:nailercole@gmail.com)

---

## 📚 Foundational Research

This project builds on the Logic of Coherence (LoC) framework:

- [https://doi.org/10.5281/zenodo.17193463](https://doi.org/10.5281/zenodo.17193463)  
- [https://doi.org/10.5281/zenodo.17194960](https://doi.org/10.5281/zenodo.17194960)  
- [https://doi.org/10.5281/zenodo.17194978](https://doi.org/10.5281/zenodo.17194978)
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


https://doi.org/10.5281/zenodo.17194978
