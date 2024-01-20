using UnityEngine;
public class trigger{
    public GameObject Door;
    void Trigger()
    {
        BroadcastSystem.ObjectPickedUp(Door);
    }
}