using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CombinationLock : MonoBehaviour
{
    [SerializeField]
    private List<int> _combination;

    private List<int> _userInput;

    void OnEnable()
    {
        BroadcastSystem.KeyPressed += AcceptKey;
    }

    void OnDisable()
    {
        BroadcastSystem.KeyPressed -= AcceptKey;
    }


    private void AcceptKey(int _keyValue)
    {
        _userInput.Add(_keyValue);
        
        if(_userInput.SequenceEqual(_combination))
        {
            BroadcastSystem.LockUnlocked?.Invoke(this);
        }
    }
}
