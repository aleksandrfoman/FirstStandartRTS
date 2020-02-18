using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UnitSquad
{
    private struct p_line
    {
        public int maxCount;
        public List<GameObject> Units;

        public p_line(GameObject _unit)
        {
            Units = new List<GameObject>();
            Units.Add(_unit);
            maxCount = 5;
        }
    }

    private List<p_line> Lines = new List<p_line>();

    private int p_count;
    public int count { get { return p_count; } }

    public void AddUnit(GameObject _unit)
    {
        if (Lines.Count > 0)
        {
            for (int i = 0; i < Lines.Count; i++)
            {
                if (Lines[i].Units.Count < Lines[i].maxCount)
                {
                    Lines[i].Units.Add(_unit);
                    p_count++;
                    break;
                }else if ((i+1)>=Lines.Count)
                {
                    Lines.Add(new p_line(_unit));
                    p_count++;
                    break;
                }
            }
        }
        else
        {
            Lines.Add(new p_line(_unit));
            p_count++;
        }
    }
    public void Clear()
    {
        Lines.Clear();
        p_count = 0;
    }

    public void MoveToPoint(Vector3 _point)
    {
        var pos = setFirstPosition(_point);
        var temp = (_point - pos).normalized;
        Lines[0].Units[0].GetComponent<Unit>().AddPath(pos);
        if (Lines[0].Units.Count > 1)
        {
            for (int i = 1; i < Lines[0].Units.Count; i++)
            {
                pos += temp * 2f;
                Lines[0].Units[i].GetComponent<Unit>().AddPath(pos);
            }
        }
    }

    private Vector3 setFirstPosition(Vector3 _point)
    {

        return _point + Vector3.Cross(Vector3.up, Lines[0].Units[0].transform.position - _point).normalized * (Lines[0].Units.Count / 2);
    }
}
