using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stroop_test : MonoBehaviour
{
    public GameObject canvasStroop;


    public void finishStroop()
    {
        canvasStroop.SetActive(false);

        Player player = GameObject.Find("Player").GetComponent<Player>();
        if (player != null)
        {
            player._doingTest = false;
        }

        UI_Manager ui_manager = GameObject.Find("Inventry").GetComponent<UI_Manager>();
        if (ui_manager != null)
        {
            ui_manager.weaponCollected();
        }
        Destroy(this.gameObject);

    }
}
