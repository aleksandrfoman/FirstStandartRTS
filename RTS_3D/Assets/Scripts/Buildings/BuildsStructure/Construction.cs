using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Construction : MonoBehaviour
{
    public float TimeCreated = 0f;          //Время строительства
    public bool Init = false;

    public float curTime = 0f;

    private void Update()
    {
        if (!Init)
        {
            if (curTime >= TimeCreated)
            {
                Init = true;
            }
            else
            {
                curTime += Time.deltaTime;
            }
            
        }
    }
}
