using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GearPuzzle : Puzzle
{
    [SerializeField]
    private List<GearKnob> _gearKnobs;
    private List<GearSize> _gearSizes;
    [SerializeField]
    private Material _passMaterial, _failMaterial;
    [SerializeField]
    private GameObject _light;

    public void OnEnable()
    {
        BroadcastSystem.GearInstalled += AddGear;
    }

    public void OnDisable()
    {
        BroadcastSystem.GearInstalled -= AddGear;
    }

    public void Start()
    {
        _gearSizes = new List<GearSize>();
    }

    void AddGear(GearSize gearSize, GameObject g)
    {
        if(_solved || !object.ReferenceEquals(g,gameObject))
            return;

        Debug.Log("A " + gearSize.ToString() + " Gear is installed");

        _gearSizes.Add(gearSize);

        if(_gearSizes.Count == _gearKnobs.Count)
        {
            for(int i = 0; i < _gearSizes.Count; i++)
            {
                if(!_gearKnobs[i].Match())
                {
                    _gearSizes.Clear();
                    _light.GetComponent<Renderer>().material = _failMaterial;
                    foreach(GearKnob knob in _gearKnobs)
                    {
                        knob.GetComponentInChildren<PickUp>().ToggleInteractability();
                    }
                    return;
                }
            }
            _light.GetComponent<Renderer>().material = _passMaterial;
            Solved();
        }
    }

}
