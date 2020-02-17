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
                    var pos = setFirstPosition(p_hit.point);
                    var temp = (p_hit.point - pos).normalized;
                    p_controller.selectGroup[0].GetComponent<Unit>().AddPath(pos);
                    if (p_controller.selectGroup.Count > 1)
                    {
                        for (int i = 1;i<p_controller.selectGroup.Count;i++)
                        {
                            pos += temp * 2f;
                            p_controller.selectGroup[i].GetComponent<Unit>().AddPath(pos);
                        }
                    }
                }
            }
        }
    }

    private Vector3 setFirstPosition(Vector3 _point)
    {

        return _point + Vector3.Cross(Vector3.up, p_controller.selectGroup[0].transform.position - _point).normalized * (p_controller.selectGroup.Count / 2);
    }
}
