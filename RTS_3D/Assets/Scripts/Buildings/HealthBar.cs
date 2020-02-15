using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public bool Init = false;
    [Space]
    public Text TName = null;
    public Image ProgressBar = null;
    public Color32 colorHealthBar = Color.green;
    public Color32 colorConstr = Color.blue;

    [Header("prop")]
    public Properties m_prop = null;
    public Construction m_constr = null;

    private bool _status = true;
    private void Start()
    {
        ProgressBar.color = colorConstr;
        TName.text = m_prop.Name;
    }

    private void Update()
    {
        if (Init)
        {
            if (_status)
            {
                ProgressBar.color = colorHealthBar;
                _status = false;
            }
            ProgressBar.fillAmount=(m_prop.curHealth/m_prop.maxHealth)*1f;
        }
        else
        {
            ProgressBar.fillAmount = (m_constr.curTime / m_constr.TimeCreated) * 1f;
            Init = m_constr.Init;
        }
    }

}
