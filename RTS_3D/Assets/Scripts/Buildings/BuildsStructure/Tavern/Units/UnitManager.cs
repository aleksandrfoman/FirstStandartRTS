using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    private PController p_controller = null;

    private Camera p_camera = null;
    private Ray p_ray;
    private RaycastHit p_hit;

    private void Start()
    {
        p_camera = Camera.main;
        p_controller = GetComponent<PController>();

    }

    private void Update()
    {
        if (Input.GetMouseButton(1) && p_controller.selectGroup.Count > 0)
        {
            p_ray = p_camera.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(p_ray, out p_hit))
            {
               
                if (p_hit.collider.CompareTag("Terrain"))
                {
                    //p_controller.selectGroup.MoveToPoint(p_hit.point);
                }
            }
        }
    }

   
}
