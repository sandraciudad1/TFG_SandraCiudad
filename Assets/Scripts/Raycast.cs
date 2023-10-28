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
    private Image _pb_original;
    [SerializeField]
    private Image _pb_clean;

    public bool canMove;

    void Start()
    {
        canMove = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = (Camera.main.ScreenPointToRay(Input.mousePosition));
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                //Debug.Log("Hit: " + hitInfo.transform.name);
                if(hitInfo.transform.name == "Pin_Board")
                {
                    Debug.Log("pulsado");
                    Player player = GameObject.Find("Player").GetComponent<Player>();
                    if (player != null)
                    {
                        player._doingTest = true;
                        canMove = true;
                        animationEffects animation = GameObject.Find("Player").GetComponent<animationEffects>();
                        if (animation != null)
                        {
                            animation.Update();
                        }

                        
                        
                    }
                    /*float x = _pb_original.transform.position.x;
                    float y = _pb_original.transform.position.y;
                    float z = _pb_original.transform.position.z;
                    Debug.Log("x: " + x + " y: " + y + " z: " + z);
                    Vector3 finalpos = new Vector3(-1.11f, 0.47f, 7.2f);
                    _pinBoard.transform.position = Vector3.MoveTowards(transform.position, finalpos, Time.deltaTime * 5);*/
                    //Vector3 finalsize = new Vector3(1.3f, 1.3f, 1.3f);
                    //_pinBoard.transform.localScale = Vector3.MoveTowards(transform.position, finalsize, Time.deltaTime * 5);
                    //_pinBoard.transform.localScale = new Vector3(2, 2, 2);
                }
            }
        }
        

    }
    private void OnMouseDown()
    {
        
    }
}
