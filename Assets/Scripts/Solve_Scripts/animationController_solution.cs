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

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        _canStart = false;
        drop = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (_canStart == true && drop == false && animator.GetBool("drop") == false)
        {
            animator.SetBool("drop", true);
            StartCoroutine(wait_drop());
        }

    }


    IEnumerator wait_drop()
    {
        yield return new WaitForSeconds(1.2f);
        drop = true;
        animator.SetBool("drop", false);
    }
}
