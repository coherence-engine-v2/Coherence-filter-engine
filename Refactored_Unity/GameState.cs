using UnityEngine;

public class GameState
{
    public static GameState Instance => instance ??= new GameState();
    private static GameState instance;

    public bool isDead = false;
    public bool isConscious = true;
    public bool hasKey = true;
    public bool isNearDoor = false;

    // You can expand this with actual game data bindings later.
}
