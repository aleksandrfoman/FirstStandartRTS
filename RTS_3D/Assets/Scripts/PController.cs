using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PController : MonoBehaviour
{
    public bool startBay = false;
    public int indexShop = -1;

    private GMode GMode = null;
    private GameHud GHUD = null;

    private Camera _camera = null;

    private Ray _ray;
    private RaycastHit _hit;

    public List<GameObject> gameUnits = new List<GameObject>();
    public UnitSquad selectGroup = new UnitSquad();

    private void Start()
    {
        GMode = GetComponent<GMode>();
        _camera = Camera.main;
        GHUD = GetComponent<GameHud>();
    }
    private void Update()
    {
        if (startBay)
        {
            if (Input.GetMouseButton(0))
            {
                if (GMode.Gold >= GMode.Shop[indexShop].Cost)
                {
                    _ray = _camera.ScreenPointToRay(Input.mousePosition);
                    if (Physics.Raycast(_ray, out _hit))
                    {

                        if (_hit.collider.tag == "Area")
                        {
                            GMode.Gold -= GMode.Shop[indexShop].Cost;
                            _hit.collider.GetComponent<Area>().Status = true;
                            _hit.collider.GetComponent<Area>().Enable = false;
                            _hit.collider.GetComponent<Area>().GObject = Instantiate(GMode.Shop[indexShop].GObject, new Vector3(_hit.transform.position.x, 1f, _hit.transform.position.z), Quaternion.identity);
                            indexShop = -1;
                            foreach (Area _tmp in GMode.Areas)
                            {
                                if (!_tmp.Status)
                                {
                                    _tmp.Enable = false;
                                }
                                startBay = false;
                            }
                        }
                    }
                }
            }
        }
        else
        {
            if (Input.GetMouseButton(0))//Выбор зданий
            {
                _ray = _camera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(_ray, out _hit))
                {
                    if (_hit.collider.tag == "Building")
                    {
                        GMode.Selected = _hit.collider.gameObject;
                        GHUD.updateStart = false;
                    }
                }
            }
        }
    }

    public void StartBuy(int _index)
    {
        if (GMode.Gold >= GMode.Shop[_index].Cost)
        {
            indexShop = _index;
            foreach (Area _tmp in GMode.Areas)
            {
                if (!_tmp.Status)
                    _tmp.enabled = true;
            }
            startBay = true;
        }
    }
}