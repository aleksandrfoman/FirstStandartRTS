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

    private Camera p_camera;
    private Ray _ray;
    private RaycastHit _hit;


    private void Start()
    {
        p_camera = Camera.main;
        p_agent = GetComponent<NavMeshAgent>();
        p_agent.speed = Speed;
    }

    private void Update()
    {
        if (Input.GetMouseButton(1))
        {
            _ray = p_camera.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(_ray,out _hit))
            {
                p_agent.SetDestination(_hit.point);
            }
        }
    }

}
