using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombinationKey : MonoBehaviour, IInteractable
{

    [SerializeField, Range(0,9)]
    private int _keyValue;

    [SerializeField]
    private AudioClip _keyPressedSound;

    private int _bruteForceCounter = 0;

    public string GetDisplayText()
    {
        return "Press E to Input";
    }

    public void Interact()
    {
        BroadcastSystem.KeyPressed(_keyValue, transform.parent.gameObject);
        AudioSystem.Instance.PlaySFX(_keyPressedSound);
        if(GetComponent<Animation>() != null && !GetComponent<Animation>().isPlaying)
            GetComponent<Animation>().Play();
        
        Item item = InventoryManager.Instance.GetSelectedItem();

        if(item == null)
        {
            return;
        }

        if(item.type == ItemType.Brick)
        {
            _bruteForceCounter++;
            if(_bruteForceCounter >= 10)
            {
                transform.parent.GetComponent<Puzzle>().Solved();
            }
        }
    }
}
