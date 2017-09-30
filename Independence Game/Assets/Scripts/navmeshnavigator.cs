using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class navmeshnavigator : MonoBehaviour {

    public Transform target;
    NavMeshAgent agent;



	// Use this for initialization
	void Start () {
        agent = this.GetComponent<NavMeshAgent>();

        if(agent == null)
        {
            Debug.LogError("CACA");
        }

        else
        {
            SetDestination();
        }
 
	}

    private void SetDestination()
    {

        agent.SetDestination(target.position);

    }

}
