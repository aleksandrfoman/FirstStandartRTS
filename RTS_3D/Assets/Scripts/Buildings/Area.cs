using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area : MonoBehaviour
{
    public bool status = false;
    public bool Enable = false;

    public GameObject GObject = null;

    private GMode _GMode = null;

    private void Start()
    {
        _GMode = GameObject.FindGameObjectWithTag("GameWorld").GetComponent<GMode>();
        _GMode.Areas.Add(this);
        
    }
}
