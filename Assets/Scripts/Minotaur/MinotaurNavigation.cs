using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MinotaurNavigation : MonoBehaviour
{
    public GameObject player;
    public bool isPatroling;
    public List<Transform> 
    private NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isPatroling){

        }
        else{
            ChasePlayer();
            if
        }
    }

    private void ChasePlayer()
    {
        agent.destination = player.transform.position;
    }
}
