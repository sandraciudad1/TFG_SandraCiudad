using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickControl : MonoBehaviour
{
    public int coches;
    public int lamparas;
    public int ordenadores;
    public int aire_acondicionado;
    public int reflectantes;
    public int otros;

    // Start is called before the first frame update
    public void Start()
    {
        coches = 0;
        lamparas = 0;
        ordenadores = 0;
        aire_acondicionado = 0;
        reflectantes = 0;
        otros = 0;
    }

    // Update is called once per frame
    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = (Camera.main.ScreenPointToRay(Input.mousePosition));
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                if(hitInfo.transform.parent.name == "Furniture")
                {
                    if (hitInfo.transform.name == "sedan-car-01" || hitInfo.transform.name == "sedan-car-02")
                    {
                        coches += 1;
                    }
                    else if (hitInfo.transform.name == "StandingLampS" || hitInfo.transform.name == "Lamp_Table_Apt_02_8" || hitInfo.transform.name == "Lamp_Table_Apt_02_7" || hitInfo.transform.name == "StandingLampS_1" || hitInfo.transform.name == "Lamp_Floor_Apt_02_1"
                        || hitInfo.transform.name == "Lamp_Table_Apt_02_1" || hitInfo.transform.name == "Lamp_Table_Apt_02_2" || hitInfo.transform.name == "LightTable06_1On_1" || hitInfo.transform.name == "Lamp_Table_Apt_02_4" ||
                        hitInfo.transform.name == "LightTable06_1On_2" || hitInfo.transform.name == "Lamp_Table_Apt_02_6" || hitInfo.transform.name == "Lamp_Table_Apt_02_5" || hitInfo.transform.name == "LightTable06_1On_3")
                    {
                        lamparas += 1;
                    }
                    else if (hitInfo.transform.name == "Monitor_1" || hitInfo.transform.name == "Imac" || hitInfo.transform.name == "Imac_2" || hitInfo.transform.name == "Laptop" || hitInfo.transform.name == "Monitor_Apt_01")
                    {
                        ordenadores += 1;
                    }
                    else if (hitInfo.transform.name == "AirConditioner_12" || hitInfo.transform.name == "AirConditioner_10" || hitInfo.transform.name == "AirConditioner_9" || hitInfo.transform.name == "AirConditioner_8" || hitInfo.transform.name == "AirConditioner_7"
                        || hitInfo.transform.name == "AirConditioner_6" || hitInfo.transform.name == "AirConditioner_11")
                    {
                        aire_acondicionado += 1;
                    }
                    else if (hitInfo.transform.name == "dressingRoom" || hitInfo.transform.name == "MirrorPlate_Filled_Variant" || hitInfo.transform.name == "bigBath" || hitInfo.transform.name == "Wall_Mirror_02_4" || hitInfo.transform.name == "bigBath_1" ||
                        hitInfo.transform.name == "BR_Cabinet_01" || hitInfo.transform.name == "Wall_Mirror_02_2" || hitInfo.transform.name == "Wall_Mirror_02" || hitInfo.transform.name == "Fridge_01" || hitInfo.transform.name == "MirrorPlate_Filled Variant")
                    {
                        reflectantes += 1;
                    }
                    else
                    {
                        otros += 1;
                    }
                }

               
            }
        }
    }
}
