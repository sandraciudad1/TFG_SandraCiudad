using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using System;

public class Raycast : MonoBehaviour
{
    [SerializeField]
    private GameObject _pinBoard;
    [SerializeField]
    private GameObject _remoteControl;


    [SerializeField]
    private Image _pb_original;
    [SerializeField]
    private Image _pb_clean;

    public bool canMove;
    public int count;

    void Start()
    {
        canMove = false;
        count = 0;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = (Camera.main.ScreenPointToRay(Input.mousePosition));
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                if (hitInfo.transform.name == "Pin_Board")
                {
                    count = 1;
                    Player player = GameObject.Find("Player").GetComponent<Player>();
                    if (player != null)
                    {
                        player._doingTest = true;
                        canMove = true;
                        animationEffects animation = GameObject.Find("Player").GetComponent<animationEffects>();
                        if (animation != null && count == 1)
                        {
                            animation.Update();
                        }



                    }
                }


            }
        }


    }
}
