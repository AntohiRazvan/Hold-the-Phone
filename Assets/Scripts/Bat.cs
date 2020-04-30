using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : MonoBehaviour
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

    void Update()
    {
        if(agent.enabled)
        {
            Vector2 movementDirection = Vector2.zero;
            agent.SetDestination(goal.position);
            movementDirection = (goal.position - gameObject.transform.position).normalized;
            if(movementDirection.sqrMagnitude - 0.01f >= 0f)
            {
                anim.SetFloat("Horizontal", movementDirection.x);
                anim.SetFloat("Vertical", movementDirection.y);
            }
        }
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            if(Time.time > lastDamage + damageFrequency)
            {
                Debug.Log("HIT!");
                lastDamage = Time.time;
                GameEventManager.TriggerTookDamage(damage);
            }

        }
    }
}
