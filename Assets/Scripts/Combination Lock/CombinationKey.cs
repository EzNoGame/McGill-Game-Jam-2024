using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombinationKey : Interactable
{

    [SerializeField, Range(1,9)]
    private int _keyValue;

    public override void BeenIteracted(GameObject obj)
    {
        BroadcastSystem.KeyPressed(_keyValue);
    }

    public override void BeenSeen()
    {
        BroadcastSystem.BroadcastMessage("Press E to Input");
    }

    public override void BeenUndone()
    {
        throw new System.NotImplementedException();
    }

    public override void BeenUnSeen()
    {
        BroadcastSystem.BroadcastMessage("");
    }
}
