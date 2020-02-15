using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Construction : MonoBehaviour
{
    public float TimeCreated = 0f;          //Время строительства
    public bool Init = false;

    private float _tempTime = 0f;
    private Vector3 _pos = new Vector3();
    private Camera _camera = null;
    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        if (!Init)
        {
            _pos = _camera.WorldToScreenPoint(gameObject.transform.position);
            if (_tempTime >= TimeCreated)
            {
                Init = true;
            }
            else
            {
                _tempTime += Time.deltaTime;
            }
            
        }
    }
}
