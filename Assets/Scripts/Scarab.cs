using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scarab : MonoBehaviour
{
    public float damage;
    public float damageFrequency;
	public bool baby;
	public bool hasBabies;
    bool acquiredTarget;
	public GameObject babyPrefab;
	public GameObject[] spawns = new GameObject[3];
	
    Transform sprite;
    Transform goal;
    
    UnityEngine.AI.NavMeshAgent agent;
    Animator anim;
	Health health;

    float lastDamage;

    void Awake()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
		health = GetComponent<Health>();
		sprite = transform.Find("Sprite");
    }

    void Start() 
    {
        goal = GameObject.FindGameObjectsWithTag("Player")[0].transform;
        lastDamage = Time.time;
        acquiredTarget = false;
    }
   
    void Update()
    {
        Vector3 playerPosition = goal.transform.position;
        
		Debug.Log("Health" +health.health+ "Baby" + baby + " hasBabies" + hasBabies );
        if (health.health <=0 && !baby && !hasBabies) 
        {
			hasBabies = true;
			spawnBabies();
		} 

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

	void spawnBabies() 
    {
		foreach ( GameObject spawn in spawns) 
        {
            if(spawn)
            {
			    GameObject baby = Instantiate(babyPrefab, spawn.transform.position, Quaternion.identity) as GameObject;
            }
		} 
	}

    void MoveTo(Vector3 position)
    {
        if(!baby)
        {
            Vector3 movementDirection = Vector2.zero;
            agent.SetDestination(position);
            movementDirection = (position - gameObject.transform.position).normalized;
			anim.SetFloat("Speed", movementDirection.sqrMagnitude);
			
            Vector3 vectorToTarget = position - transform.position;
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
            Quaternion q = Quaternion.AngleAxis(angle-90, Vector3.forward);
            sprite.transform.rotation = Quaternion.Slerp(sprite.transform.rotation, q, Time.deltaTime*5f); 
        }
    }

    void CheckForTarget(Vector3 position)
    {
        if(Vector2.Distance(position, gameObject.transform.position) < 12f)
        {
            acquiredTarget = true;
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
