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
    public bool init;
    public bool continue_moving;
    public bool exit;

    //positions and rotations for stroop animation
    Vector3 target_pos_stroop = new Vector3(13.37f, 0.7f, -9.29f);
    Quaternion target_rot_stroop = Quaternion.Euler(0, 0, 0);
    Vector3 final_pos_stroop = new Vector3(13.358f, 1.31f, -8.092f);

    //positions and rotations for init animation
    Vector3 target_pos_init = new Vector3(-2.59f, 0.7f, 23.088f);
    Vector3 target_pos2_init = new Vector3(-1.423f, 0.7f, 27.7f);
    Quaternion target_rot_init = Quaternion.Euler(0, 10, 0);


    // Start is called before the first frame update
    void Start()
    {
        finish = false;
        init = false;
        continue_moving = false;
        exit = false;
    }

    // Update is called once per frame
    public void Update()
    {
        float step = Time.deltaTime;
        Player player = GameObject.Find("Player").GetComponent<Player>();

        Start_Screen start = GameObject.Find("Start_Screen").GetComponent<Start_Screen>();
        if (start != null)
        {
            if (player != null && init == true && continue_moving == false)
            {
                player.transform.position = Vector3.MoveTowards(player.transform.position, target_pos2_init, step*3);
                if (player.transform.position == target_pos2_init)
                {
                    continue_moving = true;  
                }
            }

            if (continue_moving == true && exit == false)
            {
                player.transform.position = Vector3.MoveTowards(player.transform.position, target_pos_init, step * 2);
                player.transform.localRotation = Quaternion.Slerp(player.transform.rotation, target_rot_init, step);
                if (player.transform.position == target_pos_init  && player.transform.localRotation == target_rot_init)
                {
                    //---------------------------------------------------------
                    //antes de esto meter animacion de la puerta que se cierra
                    //---------------------------------------------------------
                    start._killer.SetActive(true);
                    start._bgKiller.SetActive(true);
                    start._textDialog.SetActive(true);
                    exit = true;
                }
            }
        }


          
        Raycast raycast = GameObject.Find("pinboard").GetComponent<Raycast>();
        if (raycast != null)
        {
            if (player != null && raycast.canMove == true)
            {
                player.transform.position = Vector3.MoveTowards(player.transform.position, target_pos_stroop, step);
                player.transform.localRotation = Quaternion.Slerp(player.transform.rotation, target_rot_stroop, step);
                if (player.transform.position == target_pos_stroop && player.transform.localRotation == target_rot_stroop)
                {
                    PinBoard pinboard = GameObject.Find("pinboard").GetComponent<PinBoard>();
                    if (pinboard != null)
                    {
                        _pinBoard.transform.position = Vector3.MoveTowards(_pinBoard.transform.position, final_pos_stroop, step);
                        if (_pinBoard.transform.position == final_pos_stroop && finish==false)
                        {
                            _pinBoard.SetActive(false);
                            player._doingTest = true;
                            pinboard.startIntroduction();
                            finish = true;
                        }
                    }
                }
            }
        }
        
            
    }
}
