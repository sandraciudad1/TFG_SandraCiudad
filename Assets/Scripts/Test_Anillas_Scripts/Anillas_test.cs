using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anillas_test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void init_test()
    {
        //definir las 3 pilas con los valores iniciales
        //pila izq: rojo, naranja, amarillo, verde, azul
        //pila centro:
        //pila derecha: 
        Update();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = (Camera.main.ScreenPointToRay(Input.mousePosition));
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                Debug.Log(hitInfo.transform.name);
                /*if (hitInfo.transform.name == "CardFan_Hearts_" && clicked == false)
                {

                    clicked = true;
                }*/
            }
        }
        //comprobar si se ha pulsado algun eje
        //si pulsado, comprobar si tiene discos
        //si tiene, mover al segundo pulsado
        //si no tiene, mensaje de error

        //comprobar continueamente si la posicion de los 3 ejes es la correcta

    }
}
