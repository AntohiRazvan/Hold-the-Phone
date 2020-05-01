using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scarab : MonoBehaviour
{
    public float damage;
    public float damageFrequency;
    Transform goal;
    
    UnityEngine.AI.NavMeshAgent agent;
    Animator anim;
    float lastDamage;

    void Awake()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
    }

    void Start() 
    {
        goal = GameObject.FindGameObjectsWithTag("Player")[0].transform;
        lastDamage = Time.time;
    }

	public GameObject dest; 
    void Update()
    {
        if(agent.enabled)
        {
            Vector2 movementDirection = Vector2.zero;
            agent.SetDestination(goal.position);
            movementDirection = (goal.position - gameObject.transform.position).normalized;
			anim.SetFloat("Speed", movementDirection.sqrMagnitude);
			Vector3 rotation = transform.localEulerAngles;
			if (Mathf.Abs(movementDirection.y) - 0.01f >= 0f) {
				rotation.z = Mathf.Sign(movementDirection.y) * 90;
			} else if (Mathf.Abs(movementDirection.x) - 0.01f >= 0f) {
				rotation.z = Mathf.Sign(movementDirection.x) * 180;
			}
			/* transform.localEulerAngles = rotation; */

        } else {
			/* transform.position = Vector3.MoveTowards(transform.position, dest.transform.position, Time.deltaTime); */
		}
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            if(Time.time > lastDamage + damageFrequency)
            {
                lastDamage = Time.time;
                GameEventManager.TriggerTookDamage(damage);
            }

        }
    }
}
