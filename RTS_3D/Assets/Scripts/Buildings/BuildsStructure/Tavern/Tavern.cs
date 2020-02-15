using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tavern : MonoBehaviour
{
    public bool Status = false;

    public int maxQueue = 0;

    public float maxTime = 0f;
    public float curTime = 0f;


    public List<UnitData> Units = new List<UnitData>();

    public List<int> _unityQueue = new List<int>();

    private void Update()
    {
        if (Status)
        {
            if (_unityQueue.Count>0)
            {
                maxTime = Units[_unityQueue[0]].createTime;
                if (curTime >= maxTime)
                {
                    curTime = 0f;
                    Debug.Log("Spawn Unit" + Units[_unityQueue[0]]);
                    _unityQueue.RemoveAt(0);
                  
                }
                else
                {
                    curTime += Time.deltaTime;
                }
            }
            else
            {
                Status = false;
            }
        }
    }
}
