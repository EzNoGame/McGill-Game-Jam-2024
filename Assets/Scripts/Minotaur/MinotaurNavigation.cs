using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class MinotaurNavigation : MonoBehaviour
{
    public GameObject player;
    public Logic logic;
    public float chasingSpeed;
    public float patrollingSpeed;
    public bool isPatroling;
    public List<Transform> patrolCheckPoints;
    private NavMeshAgent agent;
    private bool gotJucked;
    private int patrolInteger;
    private Vector3 previousDestination;

    public AudioClip roar;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        patrolInteger = 0;
        gotJucked = false;
        SoundFXManager.instance.PlaySoundFX(roar, transform, 1f); 
    }

    // Update is called once per frame
    void Update()
    {
        //Check if has caught player (less than 1 meter away and not hiding)
        if(DistanceFromPlayer() < 3 && !FPSController.Instance.IsHiding){
            // Debug.Log("Dead");
            logic.die();
        }
    
        //Update destination
        if(isPatroling){
            if(DistanceFromPlayer() < 20 && Vector3.Dot(transform.forward.normalized, (player.transform.position-transform.position).normalized)>0.8){
                if(!Physics.Raycast(transform.position, player.transform.position-transform.position, 20)){
                    isPatroling = false;
                }
            }
            agent.speed = patrollingSpeed;
            if(agent.remainingDistance<0.2){
                patrolInteger++;
                agent.destination = patrolCheckPoints[patrolInteger].transform.position;
            }
        }
        else{
            //If hiding move to despawn
            if(FPSController.Instance.IsHiding){
                if(agent.remainingDistance<0.4){
                    Debug.Log("Jucked");
                    //should pass infront of the player's hiding spot
                    previousDestination = agent.destination;
                    agent.destination = transform.position + transform.forward*100;
                    gotJucked = true;
                }
                if(Vector3.Distance(transform.position,previousDestination) > 10 && gotJucked){
                    Destroy(gameObject);
                }
            }
            else{
                ChasePlayer();
            }
        }
    }

    private void ChasePlayer()
    {
        agent.speed = chasingSpeed;
        agent.destination = player.transform.position;
    }
    public void StartPatrolling()
    {
        isPatroling = true;
        agent.destination = patrolCheckPoints[patrolInteger].transform.position;
    }
    private float DistanceFromPlayer(){
        return Vector3.Distance(transform.position,player.transform.position);
    }
}
