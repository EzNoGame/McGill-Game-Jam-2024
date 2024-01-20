using System;
using UnityEngine;

public static class BroadcastSystem
{
    public static Action<string> BroadcastMessage;
    public static Action<GameObject> ObjectPickedUp;
    public static Action<GameObject> ObjectDropped;

    //combination lock
    public static Action<int, GameObject> KeyPressed;
    public static Action<CombinationLock> LockUnlocked;

    public static Action<GearSize, GameObject> GearInstalled;

    public static Action<Puzzle> PuzzleSolved;
}