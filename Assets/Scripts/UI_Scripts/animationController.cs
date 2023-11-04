using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using System;

public class animationController : MonoBehaviour
{
    [SerializeField]
    public GameObject remoteControl;
    Animator animator;
    //SpriteRenderer sr;

    Vector3 target_pos = new Vector3(-9.639f, 0.614f, -2.442f);

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        //sr = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = (Camera.main.ScreenPointToRay(Input.mousePosition));
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                if (hitInfo.transform.name == "RemoteControl_")
                {
                    //sr.enabled = true;
                    animator.SetBool("clicked", true);
                    animator.SetBool("light", true);
                    
                }

                

            }
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            animator.SetBool("clicked", false);
        }
    }

    
}
