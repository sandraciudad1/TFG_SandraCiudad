using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using System;

public class animationController_anillas : MonoBehaviour
{
    Animator animator;

    //player movements
    Vector3 player_anillas_pos = new Vector3(4.093f, 0f, 2.79f);
    Quaternion player_anillas_rot = Quaternion.Euler(0f, 176.3f, 0f);

    Vector3 player_final_pos = new Vector3(4.119f, 0f, 1.931f);
    Vector3 player_return_pos = new Vector3(3.773f, 0f, 3.294f);

    [SerializeField]
    private GameObject _particles;
    [SerializeField]
    private Light _light;

    public bool clicked;
    public bool anillas_pos;
    public bool start_moving;
    public bool arrivedpos;

    public bool init_anim;
    public bool finish;
    public bool next;

    public int counter;
    public bool turnOn;
    public bool turnOff;

    public bool return_pos;
    public bool arrive_return_pos;


    void Start()
    {
        animator = GetComponent<Animator>();
        _particles.SetActive(true);
        clicked = false;
        anillas_pos = false;
        start_moving = false;
        arrivedpos = false;
        
        init_anim = false;
        finish = false;
        next = false;

        counter = 0;
        turnOn = false;
        turnOff = false;

        return_pos = false;
        arrive_return_pos = false;
    }


    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = (Camera.main.ScreenPointToRay(Input.mousePosition));
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                if ((hitInfo.transform.name == "Cube" || hitInfo.transform.name == "Cylinder_mid" || hitInfo.transform.name == "Cylinder_left" || hitInfo.transform.name == "Cylinder_right") && _particles.activeInHierarchy == true)
                {
                    if (counter == 0)
                    {
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
        if (player != null && clicked == true && anillas_pos == false)
        {
            player._doingTest = true;
            player.transform.position = Vector3.MoveTowards(player.transform.position, player_anillas_pos, step * 2);
            player.transform.rotation = Quaternion.RotateTowards(player.transform.rotation, player_anillas_rot, step * 10);
            if (player.transform.position == player_anillas_pos && player.transform.localRotation == player_anillas_rot)
            {
                anillas_pos = true;
            }
        }


        if (anillas_pos == true && turnOn == false)
        {
            _particles.SetActive(false);
            _light.range += 0.1f;
            if (_light.range >= 1.5f)
            {
                _light.range = 1.5f;
                turnOn = true;
            }
        }


        anillas anillas = GameObject.Find("Anillas").GetComponent<anillas>();
        if (anillas != null)
        {
            if (turnOn == true && arrivedpos == false)
            {
                if (anillas != null)
                {
                    anillas.startIntroduction();
                }
                arrivedpos = true;
            }

            if (player != null && init_anim == true && turnOff == false)
            {
                _light.range -= 0.1f;
                if (_light.range <= 0f)
                {
                    _light.range = 0f;
                    turnOff = true;
                }
            }

            if (turnOff == true && finish == false)
            {
                player.transform.position = Vector3.MoveTowards(player.transform.position, player_final_pos, step);
                if (player.transform.position == player_final_pos)
                {
                    anillas.finish = true;
                    finish = true;
                }
            }


        }

        if (return_pos == true && arrive_return_pos == false)
        {
            player.transform.position = Vector3.MoveTowards(player.transform.position, player_return_pos, step);
            if (player.transform.position == player_return_pos)
            {
                arrive_return_pos = true;
            }
        }

    }

   
}
