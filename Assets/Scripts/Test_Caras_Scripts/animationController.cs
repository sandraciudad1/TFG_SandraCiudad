using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using System;

public class animationController : MonoBehaviour
{
    
    Animator animator;

    //player in sofa position
    Vector3 player_remoteControl_pos = new Vector3(-10.1f, 0.7f, -0.12f);
    Quaternion player_remoteControl_rot = Quaternion.Euler(0, 180, 0);

    //player arriving to tv position
    Vector3 player_left_caras_pos = new Vector3(-8.43f, 0.7f, -0.12f);
    Vector3 player_straight_caras_pos = new Vector3(-8.43f, 0.7f, -3.74f);
    Vector3 player_right_caras_pos = new Vector3(-11.44f, 0.7f, -8.3f);
    Quaternion player_final_pos_rotation = Quaternion.Euler(-10, 180, 0);

    public bool clicked;
    public bool remoteControl_pos;
    public bool start_moving;
    public bool arrived_left_caras;
    public bool arrived_straight_caras;
    public bool arrived_right_caras;
    public bool scaledTv;
    public bool showTest;

    


    void Start()
    {
        animator = GetComponent<Animator>();
        clicked = false;
        remoteControl_pos = false;
        start_moving = false;
        arrived_left_caras = false;
        arrived_straight_caras = false;
        arrived_right_caras = false;
        scaledTv = false;
        showTest = false;
    }


    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = (Camera.main.ScreenPointToRay(Input.mousePosition));
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                if (hitInfo.transform.name == "RemoteControl_" && clicked == false)
                {

                    clicked = true;
                }
            }
        }

        float step = Time.deltaTime;
        Player player = GameObject.Find("Player").GetComponent<Player>();
        if (player != null && clicked == true && remoteControl_pos == false)
        {
            player._doingTest = true;
            player.transform.position = Vector3.MoveTowards(player.transform.position, player_remoteControl_pos, step * 2);
            player.transform.localRotation = Quaternion.Slerp(player.transform.rotation, player_remoteControl_rot, step * 3);            
            if (player.transform.position == player_remoteControl_pos && player.transform.localRotation == player_remoteControl_rot)
            {
                remoteControl_pos = true;
            }
        }


        if (animator.GetBool("remoteControl_clicked") == false && remoteControl_pos == true)
        {
            animator.SetBool("remoteControl_clicked", true);

        }


        if (start_moving == false && animator.GetCurrentAnimatorStateInfo(0).IsName("start_television"))
        {
            StartCoroutine(wait_animation_caras());

        }


        if (player != null)
        {
            //player moves to the left
            if (start_moving == true && arrived_left_caras == false)
            {
                player.transform.position = Vector3.MoveTowards(player.transform.position, player_left_caras_pos, step * 2);
                if (player.transform.position == player_left_caras_pos)
                {
                    arrived_left_caras = true;
                }
            }
            

            //player moves straight
            if (arrived_left_caras == true && arrived_straight_caras == false)
            {
                player.transform.position = Vector3.MoveTowards(player.transform.position, player_straight_caras_pos, step * 2);
                if (player.transform.position == player_straight_caras_pos)
                {
                    arrived_straight_caras = true;
                }
            }

            //player moves right and straight
            if (arrived_straight_caras == true && arrived_right_caras == false)
            {
                player.transform.position = Vector3.MoveTowards(player.transform.position, player_right_caras_pos, step * 2);
                player.transform.localRotation = Quaternion.Slerp(player.transform.rotation, player_final_pos_rotation, step);
                if (player.transform.position == player_right_caras_pos && player.transform.localRotation == player_final_pos_rotation)
                {
                    arrived_right_caras = true;
                }
            }

            if(arrived_right_caras == true && scaledTv == false)
            {
                Television tv = GameObject.Find("remoteControl").GetComponent<Television>();
                if (tv != null)
                {
                    tv.startIntroduction();
                }
                scaledTv = true;
                
            }

            if(scaledTv == true && showTest == false)
            {
                
            }
        }

    }

    IEnumerator wait_animation_caras()
    {
        yield return new WaitForSeconds(4.5f);
        start_moving = true;
    }

}
