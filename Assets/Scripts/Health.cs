using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float health;

    CircleCollider2D collider;
    Animator anim;

    void Awake()
    {
        collider = this.gameObject.GetComponent<CircleCollider2D>();
        anim = GetComponentInChildren<Animator>();
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Object.Destroy(this.gameObject, 3.0f);
        collider.enabled = false;
        UnityEngine.AI.NavMeshAgent navMeshAgent = this.gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
        if(navMeshAgent)
        {
            navMeshAgent.enabled = false;
        }
        if(anim)
        {
            anim.SetBool("IsDead", true);
        }

    }
}
