using UnityEngine;

public class CController : MonoBehaviour
{
    public float speed = 0f;

    private Vector3 _pos = Vector3.zero;
    void Update()
    {
        if (Input.mousePosition.x >= (Screen.width - 2.25f))
        {
            _pos.x = speed * Time.deltaTime;
        }
        else if (Input.mousePosition.x <= 2.25f)
        {
            _pos.x = -(speed * Time.deltaTime);
        }
        else
        {
            _pos.x = 0f;
        }
        if (Input.mousePosition.y >= (Screen.height - 2.25f))
        {
            _pos.z = speed * Time.deltaTime;
        }
        else if (Input.mousePosition.y <= 2.25f)
        {
            _pos.z = -(speed * Time.deltaTime);
        }
        else
        {
            _pos.z = 0f;
        }
        transform.position += _pos;
    }
}
