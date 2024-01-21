using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class CutsceneMinotaur : MonoBehaviour
{
    
    public GameObject player;
    public float speed;
    public Logic logic;
    public Animator animator;
    public float dist;

    // Update is called once per frame
    void Update()
    {
        Vector3 target = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
        transform.position = Vector3.Lerp(transform.position, target, speed * Time.deltaTime);
        Debug.Log(target.z  - transform.position.z);


        if(target.z  - transform.position.z > dist){
            
            animator.SetTrigger("FadeOut");
            
        }
    }
}