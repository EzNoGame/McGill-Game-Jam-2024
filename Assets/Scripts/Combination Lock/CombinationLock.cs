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

    void Start()
    {
        _userInput = new List<int>();
    }


    private void AcceptKey(int _keyValue)
    {
        Debug.Log("Key pressed: " + _keyValue);

        _userInput.Add(_keyValue);
        
        if(_userInput.SequenceEqual(_combination))
        {
            BroadcastSystem.LockUnlocked?.Invoke(this);
            Debug.Log("Lock Unlocked");
        }
    }
}
