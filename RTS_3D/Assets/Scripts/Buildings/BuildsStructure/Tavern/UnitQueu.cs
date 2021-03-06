﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitQueu : MonoBehaviour
{
    public bool updateUI = false;
    [Header("UI")]
    public Image ProgressBar = null;
    public List<Image> Icons = new List<Image>();

    [Header("Reference")]
    public Tavern curTavern = null;


    private GMode _GMode = null;

    private Ray p_ray;
    private RaycastHit p_hit;
    private Camera p_camera;


    private void Start()
    {
        _GMode = GetComponent<GMode>();
        p_camera = Camera.main;
    }
    private void Update()
    {
        if (updateUI)
        {
            if (curTavern._unityQueue.Count>0)
            {
                ProgressBar.gameObject.SetActive(true);
                ProgressBar.fillAmount = (curTavern.curTime / curTavern.maxTime) * 1f;
                for (int i = 0; i < Icons.Count; i++)
                {
                    if (i < curTavern._unityQueue.Count)
                    {
                        Icons[i].sprite = curTavern.Units[curTavern._unityQueue[i]].Avatar;
                        Icons[i].gameObject.SetActive(true);
                    }
                    else
                    {
                        Icons[i].gameObject.SetActive(false);
                    }
                }
            }
            else
            {
                ProgressBar.gameObject.SetActive(false);
                foreach (Image _tmp in Icons)
                {
                    _tmp.gameObject.SetActive(false);
                }
            }
            if (Input.GetKey(KeyCode.Y))
            {
                curTavern.setTargetPoint = true;
            }
            if (curTavern.setTargetPoint)
            {
                if (Input.GetMouseButton(1))
                {
                    p_ray = p_camera.ScreenPointToRay(Input.mousePosition);
                    if(Physics.Raycast(p_ray,out p_hit))
                    {
                        if(p_hit.collider.tag == "Terrain")
                        {
                            curTavern.targetPoint.position = p_hit.point;
                            curTavern.setTargetPoint = false;
                        }
                    }
                }
            }
        }
    }
    public void BuyUnit(int _index)
    {
        if (_GMode.Gold >= curTavern.Units[_index].Cost)
        {
            if(curTavern._unityQueue.Count < curTavern.maxQueue)
            {
                _GMode.Gold -= curTavern.Units[_index].Cost;
                curTavern._unityQueue.Add(_index);
                curTavern.Status = true;
                updateUI = true;
            }
        }
    }
}
