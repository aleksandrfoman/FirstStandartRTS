using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Unit : MonoBehaviour
{
    [Header("Descriptio")]
    public string Name = "None";

    public float maxHealth = 0f;
    public float curHealth = 0f;
    public float Speed = 0f;

    private NavMeshAgent p_agent = null;
    private Animator p_animator;


    private void Awake()
    {
        p_agent = GetComponent<NavMeshAgent>();
        p_animator = GetComponent<Animator>();
      
    }
    private void Start()
    {
        p_agent.speed = Speed;
    }
    private void Update()
    {
        if (Vector3.Distance(transform.position, p_agent.destination) < 0.2f)
        {
            p_animator.SetBool("RUN", false);
            p_animator.SetBool("IDLE", true);
        }
        else
        {
            p_animator.SetBool("RUN", true);
            p_animator.SetBool("IDLE", false);
        }
    }

    public void AddPath(Vector3 _point)
    {
        p_agent.SetDestination(_point);
        p_animator.SetBool("RUN", true);
        p_animator.SetBool("IDLE", false);
    }

}
