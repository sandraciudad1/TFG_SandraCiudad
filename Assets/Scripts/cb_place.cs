using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cb_place : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                Player player = other.GetComponent<Player>();
                if (player != null)
                {
                    player._hasplace = true;
                    UI_Manager ui_manager = GameObject.Find("Inventry").GetComponent<UI_Manager>();
                    if (ui_manager != null)
                    {
                        ui_manager.placeCollected();
                    }
                    Destroy(this.gameObject);
                }
            }

        }
    }
}
