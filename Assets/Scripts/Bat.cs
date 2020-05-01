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
    GameObject player;
    bool acquiredTarget;

    void Awake()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
    }

    void Start() 
    {
        player = GameObject.FindGameObjectsWithTag("Player")[0];
        lastDamage = Time.time;
        acquiredTarget = false;
    }

    void Update()
    {
        Vector3 playerPosition = player.transform.position;
        
        if(!agent.enabled)
        {
            return;
        }

        if(acquiredTarget)
        {
            MoveTo(playerPosition);
        }
        else
        {
            CheckForTarget(playerPosition); 
        }
        
    }

    void CheckForTarget(Vector3 position)
    {
        if(Vector2.Distance(position, gameObject.transform.position) < 15f)
        {
            acquiredTarget = true;
        }

    }

    void MoveTo(Vector3 position)
    {
        Vector2 movementDirection = Vector2.zero;
        agent.SetDestination(position);
        movementDirection = (position - gameObject.transform.position).normalized;
        
        if(movementDirection.sqrMagnitude - 0.01f >= 0f)
        {
            anim.SetFloat("Horizontal", movementDirection.x);
            anim.SetFloat("Vertical", movementDirection.y);
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
