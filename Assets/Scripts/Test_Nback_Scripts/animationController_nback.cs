using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using System;

public class animationController_nback : MonoBehaviour
{

    Animator animator;

    [SerializeField]
    private GameObject _particles;

    //player in sofa position
    Vector3 player_cardDeck_pos = new Vector3(7f, 0f, -24f);
    Quaternion player_cardDeck_rot = Quaternion.Euler(0f, 270f, 0f);

    Quaternion initial_rot = Quaternion.Euler(0f, 270f, 0f);

    public bool clicked;
    public bool cardDeck_pos;
    public bool start_moving;
    public bool arrivedpos;

    public bool showTest;

    public bool init_anim;
    public bool finish;
    public bool next;

    public bool cardFan_init;
    public bool finish_nback_test;
    public bool next_test;

    public int counter;

    void Start()
    {
        animator = GetComponent<Animator>();
        //_particles.SetActive(true);
        counter = 0;

        clicked = false;
        cardDeck_pos = false;
        start_moving = false;
        arrivedpos = false;

        init_anim = false;
        finish = false;
        next = false;

        cardFan_init = false;
        finish_nback_test = false;
        next_test = false;
    }


    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = (Camera.main.ScreenPointToRay(Input.mousePosition));
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                if (hitInfo.transform.name == "CardFan_Hearts_" && clicked == false && _particles.activeInHierarchy == true)
                {
                    if (counter == 0)
                    {
                        _particles.SetActive(false);
                        clicked = true;
                    }
                    else
                    {
                        clicked = false;
                    }
                    counter += 1;
                }
            }
        }

        float step = Time.deltaTime;
        Player player = GameObject.Find("Player").GetComponent<Player>();
        if (player != null && clicked == true && cardDeck_pos == false)
        {
            player._doingTest = true;
            player.transform.position = Vector3.MoveTowards(player.transform.position, player_cardDeck_pos, step * 2);
            player.transform.rotation = Quaternion.RotateTowards(player.transform.rotation, player_cardDeck_rot, step * 20);
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

        card_deck cd = GameObject.Find("card_deck").GetComponent<card_deck>();
        if (cd != null)
        {
            //player moves to the left
            if (start_moving == true && arrivedpos == false)
            {
                if (cd != null)
                {
                    cd.startIntroduction();
                }
                arrivedpos = true;
            }


            if (init_anim == true && animator.GetBool("card_back") == false && finish==false)
            {
                animator.SetBool("card_back", true);
                StartCoroutine(wait_back());
            }

            if (finish == true && next == false)
            {
                cd.finish = true;
                next = true;
            }
        }


        if (cardFan_init == true && animator.GetBool("cardFan_init") == false && finish_nback_test == false)
        {
            player.transform.rotation = Quaternion.RotateTowards(player.transform.rotation, initial_rot, step * 10);
            if (player.transform.localRotation == initial_rot)
            {
                animator.SetBool("cardFan_init", true);
                StartCoroutine(wait_initial_pos());
            }
            
        }

        


    }


    IEnumerator wait_animation_nback()
    {
        yield return new WaitForSeconds(11f);
        start_moving = true;
    }


    IEnumerator wait_back()
    {
        yield return new WaitForSeconds(3f);
        finish = true;
    }

    IEnumerator wait_initial_pos()
    {
        yield return new WaitForSeconds(2.8f);
        finish_nback_test = true;
    }
}
