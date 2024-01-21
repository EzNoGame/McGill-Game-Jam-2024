using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMinotaur : MonoBehaviour
{
    public GameObject minotaurPrefab;
    public Transform spawnTransform;
    public bool isPatroling;
    public List<Transform> patrolCheckpoints;
    public Logic logic;
    public AudioClip roar;

    public float chasingSpeed;
    public float patrollingSpeed;

    private GameObject minotaur;
    private bool hasSpawned;

    void Start(){
        hasSpawned = false;
    }
    
    private void OnTriggerEnter(Collider other){
        if(!hasSpawned){
            hasSpawned = true;
            minotaur = Instantiate(minotaurPrefab,spawnTransform);
            MinotaurNavigation minoNav = minotaur.GetComponent<MinotaurNavigation>();
            
            minoNav.player = other.gameObject;
            minoNav.logic = logic;
            minoNav.chasingSpeed = chasingSpeed;
            minoNav.patrollingSpeed = patrollingSpeed;
            minoNav.isPatroling = isPatroling;
            minoNav.roar = roar;
            if(isPatroling){
                minoNav.patrolCheckPoints = patrolCheckpoints;
            }
        }
        
    }
}
