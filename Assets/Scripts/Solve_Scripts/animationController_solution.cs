using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using System;

public class animationController_solution : MonoBehaviour
{
    Animator animator;

    [SerializeField]
    private Image win;
    [SerializeField]
    private Image lose;
    public AudioSource audio;

    public bool _canStart;
    public bool drop;
    public bool correct_anim;
    public bool finish_correct;
    public bool incorrect_anim;
    public bool finish_incorrect;
    public bool solution;
    public bool finish_game;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        _canStart = false;
        drop = false;
        correct_anim = false;
        incorrect_anim = false;
        finish_correct = false;
        finish_incorrect = false;
        finish_game = false;
    }

    // Update is called once per frame
    public void Update()
    {

        if (_canStart == true && drop == false && animator.GetBool("drop") == false)
        {
            animator.SetBool("drop", true);
            StartCoroutine(wait_drop());
        }


        if (incorrect_anim == true)
        {
            if (animator.GetBool("correct") == false && drop == true && finish_correct == false)
            {
                animator.SetBool("correct", true);
                StartCoroutine(wait_correct());
                
            }
        } 
        else if (correct_anim == true)
        {
            if (animator.GetBool("incorrect") == false && drop == true && finish_incorrect == false)
            {
                animator.SetBool("incorrect", true);
                StartCoroutine(wait_incorrect());
                
            }
        }

        
        if((finish_correct == true || finish_incorrect == true) && finish_game == false)
        {
            StartCoroutine(wait_finish());
        }
        

    }


    IEnumerator wait_drop()
    {
        yield return new WaitForSeconds(1.2f);
        drop = true;
    }

    IEnumerator wait_correct()
    {
        yield return new WaitForSeconds(3.2f);
        lose.gameObject.SetActive(true);
        finish_incorrect = true;
    }

    IEnumerator wait_incorrect()
    {
        yield return new WaitForSeconds(3.2f);
        win.gameObject.SetActive(true);
        finish_correct = true;
    }

    IEnumerator wait_finish()
    {
        yield return new WaitForSeconds(2f);
        //Time.timeScale = 0f;
        audio = GetComponent<AudioSource>();
        audio.Stop();
        finish_game = true;
    }

}
