using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using System;

public class animationController_nback : MonoBehaviour
{
    [SerializeField]
    private GameObject _introduction_bg;

    Animator animator;

    //player in sofa position
    Vector3 player_cardDeck_pos = new Vector3(7f, 0.7f, -24f);
    Quaternion player_cardDeck_rot = Quaternion.Euler(0, 270, 0);


    Vector3 bg_pos = new Vector3(0f, 0f, 0f);
    Vector3 bg_scaled = new Vector3(1.5f, 2f, 1.5f);


    //player arriving to tv position
    Vector3 player_left_caras_pos = new Vector3(-8.43f, 0.7f, -0.12f);
    Vector3 player_straight_caras_pos = new Vector3(-8.43f, 0.7f, -3.74f);
    Vector3 player_right_caras_pos = new Vector3(-11.44f, 0.7f, -8.3f);
    Quaternion player_final_pos_rotation = Quaternion.Euler(-10, 180, 0);

    public bool clicked;
    public bool cardDeck_pos;
    public bool start_moving;
    public bool arrivedpos;

    public bool showTest;

    


    void Start()
    {
        animator = GetComponent<Animator>();
        clicked = false;
        cardDeck_pos = false;
        start_moving = false;
        arrivedpos = false;
    }


    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = (Camera.main.ScreenPointToRay(Input.mousePosition));
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                if (hitInfo.transform.name == "CardFan_Hearts" && clicked == false)
                {

                    clicked = true;
                }
            }
        }

        float step = Time.deltaTime;
        Player player = GameObject.Find("Player").GetComponent<Player>();
        if (player != null && clicked == true && cardDeck_pos == false)
        {
            player._doingTest = true;
            player.transform.position = Vector3.MoveTowards(player.transform.position, player_cardDeck_pos, step * 2);
            player.transform.localRotation = Quaternion.Slerp(player.transform.rotation, player_cardDeck_rot, step * 3);            
            if (player.transform.position == player_cardDeck_pos && player.transform.localRotation == player_cardDeck_rot)
            {
                cardDeck_pos = true;
            }
        }


        if (animator.GetBool("cards_clicked") == false && cardDeck_pos == true)
        {
            animator.SetBool("cards_clicked", true);
            StartCoroutine(wait_animation_nback());

        }


        if (player != null)
        {
            //player moves to the left
            if (start_moving == true && arrivedpos == false)
            {
                
                card_deck cd = GameObject.Find("card_deck").GetComponent<card_deck>();
                if (cd != null)
                {
                    Debug.Log("llamando al start de card_deck");
                    cd.startIntroduction();
                }
                arrivedpos = true;
            }

        }

    }

    IEnumerator wait_animation_nback()
    {
        yield return new WaitForSeconds(10.7f);
        start_moving = true;
    }

}
