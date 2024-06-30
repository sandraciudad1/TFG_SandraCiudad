using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Giovanni : MonoBehaviour
{

    public bool _start;

    private void Start()
    {
        _start = false;        
    }


    public void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && _start == true)
        {
            Solve solve = GameObject.Find("Solve").GetComponent<Solve>();
            if (solve != null)
            {
                solve._isColliding = true;
            }
        }
    }
}
