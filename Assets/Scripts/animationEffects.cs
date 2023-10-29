using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using System;

public class animationEffects : MonoBehaviour
{
    [SerializeField]
    private GameObject _player;
    [SerializeField]
    private GameObject _pinBoard;
    [SerializeField]
    private Image _pb_clean;

    //[SerializeField]
    //private Image _pb_original;


    public bool finish;
    
    Vector3 target_pos = new Vector3(13.37f, 0.7f, -9.29f);
    Quaternion target_rot = Quaternion.Euler(0, 0, 0);
    Vector3 final_pos = new Vector3(13.358f, 1.31f, -8.092f);
    Quaternion final_rot = Quaternion.Euler(8, 180, 0);




    // Start is called before the first frame update
    void Start()
    {
        finish = false;
    }

    // Update is called once per frame
    public void Update()
    {
        float step = Time.deltaTime;    
        Raycast raycast = GameObject.Find("Pin_Board").GetComponent<Raycast>();
        if (raycast != null)
        {
            Player player = GameObject.Find("Player").GetComponent<Player>();
            Debug.Log("en animation effects canMove = " + raycast.canMove);
            if (player != null && raycast.canMove == true)
            {
                player.transform.position = Vector3.MoveTowards(player.transform.position, target_pos, step);
                player.transform.localRotation = Quaternion.Slerp(player.transform.rotation, target_rot, step);
                if (player.transform.position == target_pos && player.transform.localRotation == target_rot)
                {
                    PinBoard pinboard = GameObject.Find("Pin_Board").GetComponent<PinBoard>();
                    if (pinboard != null)
                    {
                        _pinBoard.transform.position = Vector3.MoveTowards(_pinBoard.transform.position, final_pos, step);
                        //pinboard.transform.Rotate(new Vector3(1f, 0f, 0f) * step);
                        if (_pinBoard.transform.position == final_pos)
                        {
                            //_pinBoard.SetActive(false);
                            _pb_clean.transform.position = Vector3.MoveTowards(_pb_clean.transform.position, final_pos, step);
                            _pb_clean.gameObject.SetActive(true);
                            pinboard.selecText();
                        }
                    }
                }
            }
        }
        
            
    }
}
