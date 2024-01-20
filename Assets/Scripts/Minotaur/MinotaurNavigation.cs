using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class MinotaurNavigation : MonoBehaviour
{
    public GameObject player;
    public float chasingSpeed;
    public float patrollingSpeed;
    public bool isPatroling;
    public List<Transform> patrolCheckPoints;
    private NavMeshAgent agent;
    private bool isHiding;
    private int patrolInteger;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        patrolInteger = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Check if has caught player (less than 1 meter away and not hiding)
        if(Vector3.Distance(transform.position,player.transform.position) < 3 && !isHiding){
            Debug.Log("Dead");
        }
        //Update destination
        if(isPatroling){
            agent.speed = patrollingSpeed;
            if(agent.remainingDistance<0.2){
                patrolInteger++;
                agent.destination = patrolCheckPoints[patrolInteger].transform.position;
            }
        }
        else{
            //If hiding move to despawn
            if(isHiding){
                if(agent.remainingDistance<0.4){
                    //should pass infront of the player's hiding spot
                    agent.destination = transform.position + transform.forward*100;
                    Destroy(gameObject,3);
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
}
