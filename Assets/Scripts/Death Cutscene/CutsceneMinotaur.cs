using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class CutsceneMinotaur : MonoBehaviour
{
    
    public AudioClip roar;

    public Transform player;
    public float speed;
    public Logic logic;
    public Animator animator;
    public float dist;

   

    void Start() {
        GameObject.Find("Player").GetComponent<Transform>();
        SoundFXManager.instance.PlaySoundFX(roar, transform, 1f); 
    }
    void Update()
    {
        Vector3 target = new Vector3(player.position.x, transform.position.y, player.position.z);
        transform.position = Vector3.Lerp(transform.position, target, speed * Time.deltaTime);
        if(target.z  - transform.position.z < dist){
            animator.SetTrigger("FadeOut");
        }
    }
}