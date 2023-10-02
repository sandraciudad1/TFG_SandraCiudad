using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Start_Screen : MonoBehaviour
{

    public GameObject canvasInicial;
    

    public void startGame()
    {
        canvasInicial.SetActive(false);

        Player player = GameObject.Find("Player").GetComponent<Player>();
        if (player != null)
        {
            player.isPressed = true;
        }
        
    }

}
