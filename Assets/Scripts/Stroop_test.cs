using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stroop_test : MonoBehaviour
{   
    [SerializeField]
    public GameObject canvasStroop;

    [SerializeField]
    private GameObject imagen;


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


    public void imageChanging()
    {
        imagen.SetActive(true);
        StartCoroutine(change());
    }

    IEnumerator change()
    {
        yield return new WaitForSeconds(5.0f);
        imagen.SetActive(false);
    }
}
