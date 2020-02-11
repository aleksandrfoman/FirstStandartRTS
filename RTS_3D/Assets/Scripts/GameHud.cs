using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameHud : MonoBehaviour
{
    public bool updateStart = false;

    public GameObject DescriptionPanel = null;
    public GameObject FarmPanel = null;
    public GameObject TavernPanel = null;

    public Text TName = null;
    public Text THealth = null;
    public Image Avatar = null;




    private Properties _prop = null;

    private GMode _GMode = null;

    private void Start()
    {
        _GMode = GetComponent<GMode>();
    }

    private void Update()
    {
        if (_GMode.Selected)
        {
            if (updateStart)
            {

                TName.text = _GMode.Selected.GetComponent<Properties>().Name;
                THealth.text = _GMode.Selected.GetComponent<Properties>().curHealth + "/" + _GMode.Selected.GetComponent<Properties>().maxHealth;

                switch (_GMode.Selected.GetComponent<Properties>().Type)
                {
                    case TypeBuildings.Farm:
                        FarmPanel.SetActive(true);
                        TavernPanel.SetActive(false);
                        break;
                    case TypeBuildings.Tavern:
                        TavernPanel.SetActive(true);
                        FarmPanel.SetActive(false);
                        break;
                    case TypeBuildings.Stronghold:
                        break;
                    default:
                        break;
                }
            }
            else
            {
                _prop = _GMode.Selected.GetComponent<Properties>();
                DescriptionPanel.SetActive(true);
                updateStart = true;
            }

        }
        else
        {
            updateStart = false;
            DescriptionPanel.SetActive(false);
        }
    }
}
