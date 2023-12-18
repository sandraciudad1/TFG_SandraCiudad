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

    public bool _canStart;
    public bool drop;
    public bool correct_anim;
    public bool finish_correct;
    public bool incorrect_anim;
    public bool finish_incorrect;

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
    }

    // Update is called once per frame
    void Update()
    {
        if (_canStart == true && drop == false && animator.GetBool("drop") == false)
        {
            animator.SetBool("drop", true);
            StartCoroutine(wait_drop());
        }


        if (correct_anim == true)
        {
            if (animator.GetBool("correct") == false && drop == true && finish_correct == false)
            {
                animator.SetBool("correct", true);
                StartCoroutine(wait_correct());
            }
        } 
        else if (incorrect_anim == true)
        {
            if (animator.GetBool("incorrect") == false && drop == true && finish_incorrect == false)
            {
                animator.SetBool("incorrect", true);
                StartCoroutine(wait_incorrect());
            }
        }

        

        

    }


    IEnumerator wait_drop()
    {
        yield return new WaitForSeconds(1.2f);
        drop = true;
    }

    IEnumerator wait_correct()
    {
        yield return new WaitForSeconds(3f);
        finish_correct = true;
    }

    IEnumerator wait_incorrect()
    {
        yield return new WaitForSeconds(3f);
        finish_incorrect = true;
    }

}
