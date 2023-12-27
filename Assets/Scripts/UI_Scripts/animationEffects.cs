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
    [SerializeField]
    private GameObject _door_rot;

    //[SerializeField]
    //private Image _pb_original;


    public bool finish_stroop_movement;
    public bool init_player_movement;
    public bool continue_moving_player;
    public bool exit_init_player_mov;
    public bool finish_door_rotation;
    public bool finish_introduction;

    //positions and rotations for stroop animation
    Vector3 target_pos_stroop = new Vector3(13.37f, 0f, -9.29f);
    Quaternion target_rot_stroop = Quaternion.Euler(0f, 0f, 0f);
    Vector3 final_pos_stroop = new Vector3(13.358f, 1.31f, -8.092f);

    //positions and rotations for init animation
    Vector3 target_pos_init = new Vector3(-2.59f, 0f, 23.088f);
    Vector3 target_pos2_init = new Vector3(-1.423f, 0f, 27.7f);
    Quaternion target_rot_init = Quaternion.Euler(0f, 10f, 0f);

    //rotations for door
    Quaternion target_door_rot = Quaternion.Euler(-90, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        finish_stroop_movement = false;
        init_player_movement = false;
        continue_moving_player = false;
        exit_init_player_mov = false;
        finish_door_rotation = false;
        finish_introduction = false;
    }

    // Update is called once per frame
    public void Update()
    {
        
        float step = Time.deltaTime;
        Player player = GameObject.Find("Player").GetComponent<Player>();

        Start_Screen start = GameObject.Find("Start_Screen").GetComponent<Start_Screen>();
        if (start != null)
        {
            if (player != null && init_player_movement == true && continue_moving_player == false)
            {
                player.transform.position = Vector3.MoveTowards(player.transform.position, target_pos2_init, step*3);
                if (player.transform.position == target_pos2_init)
                {
                    continue_moving_player = true;  
                }
            }

            if (continue_moving_player == true && exit_init_player_mov == false)
            {
                player.transform.position = Vector3.MoveTowards(player.transform.position, target_pos_init, step * 2);
                player.transform.rotation = Quaternion.RotateTowards(player.transform.rotation, target_rot_init, step * 23);
                if (player.transform.position == target_pos_init && player.transform.rotation == target_rot_init)
                {
                    exit_init_player_mov = true;
                }
            }

            if(exit_init_player_mov == true && finish_door_rotation == false)
            {
                _door_rot.transform.localRotation = Quaternion.Slerp(_door_rot.transform.rotation, target_door_rot, step);
                if(_door_rot.transform.localRotation == target_door_rot)
                {
                    finish_door_rotation = true;
                   
                }
                    
            }

            if (finish_door_rotation == true && finish_introduction==false)
            {
                start._info_btn.SetActive(true);
                start._killer.SetActive(true);
                start._bgKiller.SetActive(true);
            }
        }


          
        Raycast raycast = GameObject.Find("pinboard").GetComponent<Raycast>();
        if (raycast != null)
        {
            if (player != null && raycast.canMove == true)
            {
                player.transform.position = Vector3.MoveTowards(player.transform.position, target_pos_stroop, step/2);
                player.transform.rotation = Quaternion.RotateTowards(player.transform.rotation, target_rot_stroop, step * 10);
                if (player.transform.position == target_pos_stroop && player.transform.rotation == target_rot_stroop)
                {
                    PinBoard pinboard = GameObject.Find("pinboard").GetComponent<PinBoard>();
                    if (pinboard != null)
                    {
                        _pinBoard.transform.position = Vector3.MoveTowards(_pinBoard.transform.position, final_pos_stroop, step/2);
                        if (_pinBoard.transform.position == final_pos_stroop && finish_stroop_movement == false)
                        {
                            _pinBoard.SetActive(false);
                            player._doingTest = true;
                            pinboard.startIntroduction();
                            finish_stroop_movement = true;
                        }
                    }
                }
            }
        }
        
            
    }
}
