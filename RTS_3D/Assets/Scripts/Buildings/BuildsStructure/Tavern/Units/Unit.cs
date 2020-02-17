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

   


    private void Start()
    {
       
        p_agent = GetComponent<NavMeshAgent>();
        p_agent.speed = Speed;
    }

    private void Update()
    {

    }

    public void AddPath(Vector3 _point)
    {
        p_agent.SetDestination(_point);
    }

}
