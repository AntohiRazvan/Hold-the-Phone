using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : MonoBehaviour
{
    Transform goal;

    UnityEngine.AI.NavMeshAgent agent;
    Animator anim;

    void Awake()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
    }

    void Start() 
    {
        goal = GameObject.FindGameObjectsWithTag("Player")[0].transform;
    }

    void Update()
    {
        Vector2 movementDirection = Vector2.zero;
        agent.SetDestination(goal.position);
        if(movementDirection.sqrMagnitude - 0.01f >= 0f)
		{
            movementDirection = (goal.position - gameObject.transform.position).normalized;
			anim.SetFloat("Horizontal", movementDirection.x);
			anim.SetFloat("Vertical", movementDirection.y);
		}
    }
}
