using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GearPuzzle : Puzzle
{
    [SerializeField]
    private List<GearKnob> _gearKnobs;
    [SerializeField]
    private Material _passMaterial, _failMaterial;
    // [SerializeField]
    // private GameObject _light;

    public void OnEnable()
    {
        BroadcastSystem.GearInstalled += AddGear;
    }

    public void OnDisable()
    {
        BroadcastSystem.GearInstalled -= AddGear;
    }

    void AddGear(GearSize gearSize, GameObject g)
    {
        if(_solved || !object.ReferenceEquals(g,gameObject))
            return;

        Debug.Log("A " + gearSize.ToString() + " Gear is installed");

        for(int i = 0; i < _gearKnobs.Count; i++)
        {
            if(_gearKnobs[i].GetInputSize() == GearSize.NotAGear)
                return;
        }

        for(int i = 0; i < _gearKnobs.Count; i++)
        {
            if(!_gearKnobs[i].Match())
            {
                // _light.GetComponent<Renderer>().material = _failMaterial;
                foreach(GearKnob knob in _gearKnobs)
                {
                    knob.GetComponentInChildren<PickUp>().ToggleInteractability();
                }
                return;
            }
        }
        // _light.GetComponent<Renderer>().material = _passMaterial;
        Solved();
    }

}
