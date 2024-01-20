using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CombinationLock : Puzzle
{
    [SerializeField]
    private List<int> _combination;

    private List<int> _userInput;

    [SerializeField]
    private List<CombinationLockLight> _lights;
    [SerializeField]
    private Material _passMaterial, _failMaterial;

    void OnEnable()
    {
        BroadcastSystem.KeyPressed += AcceptKey;
    }

    void OnDisable()
    {
        BroadcastSystem.KeyPressed -= AcceptKey;
    }

    void Start()
    {
        _userInput = new List<int>();
    }

    private void AcceptKey(int _keyValue)
    {
        if(_solved)
            return;

        Debug.Log("Key pressed: " + _keyValue);

        _userInput.Add(_keyValue);
        _lights[_userInput.Count - 1].TurnOn();
        
        if(_userInput.SequenceEqual(_combination))
        {
            BroadcastSystem.LockUnlocked?.Invoke(this);
            Solved();
            Debug.Log("Lock Unlocked");
            foreach (var light in _lights)
            {
                light.gameObject.GetComponent<Renderer>().material = _passMaterial;
            }
        }
        else if(_userInput.Count == _lights.Count)
        {
            Debug.Log("Wrong combination!");
            foreach (var light in _lights)
            {
                light.gameObject.GetComponent<Renderer>().material = _failMaterial;
            }
            _userInput.Clear();
        }
    }
}
