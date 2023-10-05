using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cb_weapon : MonoBehaviour
{

    [SerializeField]
    private GameObject _stroop_test;
    [SerializeField]
    private GameObject _weapon;


    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                Player player = other.GetComponent<Player>();
                if (player != null)
                {
                    _weapon.SetActive(false);
                    player._doingTest = true;
                    _stroop_test.SetActive(true);
                }
            }

        }
    }
}
