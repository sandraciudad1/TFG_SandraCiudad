using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationController_knife : MonoBehaviour
{
    Animator animator;

    public bool _canStart;
    public bool fall;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        _canStart = false;
        fall = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (_canStart == true && fall == false && animator.GetBool("fall") == false)
        {
            animator.SetBool("fall", true);
            StartCoroutine(wait_drop());
        }

    }


    IEnumerator wait_drop()
    {
        yield return new WaitForSeconds(1.4f);
        fall = true;
        animator.SetBool("drop", false);
    }
}
