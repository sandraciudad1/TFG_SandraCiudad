using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cb_killer : MonoBehaviour
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
                    player._haskiller = true;
                    UI_Manager ui_manager = GameObject.Find("Inventry").GetComponent<UI_Manager>();
                    if (ui_manager != null)
                    {
                        ui_manager.killerCollected();
                    }
                    Destroy(this.gameObject);
                }
            }

        }
    }
}
