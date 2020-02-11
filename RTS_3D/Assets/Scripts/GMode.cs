using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GMode : MonoBehaviour
{
    public int Gold = 0;
    public int maxEats = 0;
    public int curEats = 0;

    public GameObject Selected = null;

    public List<Building> Shop = new List<Building>();      //Магазин зданий
    public List<Area> Areas = new List<Area>();             //Области для строительства
}
