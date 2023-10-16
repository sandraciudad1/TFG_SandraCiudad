using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class cb_weapon : MonoBehaviour
{
    [SerializeField]
    private GameObject _stroop_test;
    [SerializeField]
    private GameObject _weapon;
    [SerializeField]
    private GameObject _bg_explanation;

    //Check if cb_weapon us colliding with player
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

                    _bg_explanation.SetActive(true);
                    stroop_explanation stroop_Explanation = GameObject.Find("test_intros").GetComponent<stroop_explanation>();
                    if (stroop_Explanation != null)
                    {
                        stroop_Explanation.nextText();
                        if (stroop_Explanation._explanation == false)
                        {
                            _stroop_test.SetActive(true);

                            File.Delete("C:/Users/sandr.LAPTOP-GVVQRNIB/Documents/GitHub/TFG_SandraCiudad/Assets/Results/Stroop/Results.txt");
                            File.Delete("C:/Users/sandr.LAPTOP-GVVQRNIB/Documents/GitHub/TFG_SandraCiudad/Assets/Results/Stroop/Time.txt");

                            Stroop_test stroop_test = GameObject.Find("StroopTest").GetComponent<Stroop_test>();
                            if (stroop_test != null)
                            {
                                stroop_test.nextTest();
                            }
                        }
                    }

                    

                }
            }

        }
    }
}
