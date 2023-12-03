using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationController_anillas : MonoBehaviour
{
    Animator animator;

    //player movements
    Vector3 player_anillas_pos = new Vector3(4.093f, 0.7f, 2.79f);
    Quaternion player_anillas_rot = Quaternion.Euler(0f, 176.3f, 0f);

    Vector3 player_final_pos = new Vector3(4.119f, 0.7f, 1.931f);

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


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
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
                if ((hitInfo.transform.name == "Cube" || hitInfo.transform.name == "Cylinder_mid" || hitInfo.transform.name == "Cylinder_left" || hitInfo.transform.name == "Cylinder_right") && counter == 0)
                {
                    clicked = true;
                    counter = 1;
                }
            }
        }

        float step = Time.deltaTime;
        Player player = GameObject.Find("Player").GetComponent<Player>();
        if (player != null && clicked == true && anillas_pos == false)
        {
            player._doingTest = true;
            player.transform.position = Vector3.MoveTowards(player.transform.position, player_anillas_pos, step * 2);
            player.transform.localRotation = Quaternion.Slerp(player.transform.rotation, player_anillas_rot, step * 3);
            if (player.transform.position == player_anillas_pos && player.transform.localRotation == player_anillas_rot)
            {
                anillas_pos = true;
            }
        }


        anillas anillas = GameObject.Find("Anillas").GetComponent<anillas>();
        if (anillas != null)
        {
            if (animator.GetBool("turnOff_bright") == false && anillas_pos==true && turnOn==false)
            {
                animator.SetBool("turnOff_bright", true);
                StartCoroutine(wait_Onlight());
            }

            if (turnOn == true && arrivedpos == false)
            {
                anillas.startIntroduction();
                arrivedpos = true;
            }

            
            if (player!=null && init_anim == true && turnOff == false && animator.GetBool("turnOff_light") == false)
            {
                animator.SetBool("turnOff_light", true);
                StartCoroutine(wait_Offlight());
            }

            if (turnOff == true && finish == false)
            {
                player.transform.position = Vector3.MoveTowards(player.transform.position, player_final_pos, step * 2);
                if(player.transform.position == player_final_pos)
                {
                    finish = true;
                }
            }

            if (finish == true && next == false)
            {
                anillas.finish = true;
                next = true;
            }
        }

    }

    IEnumerator wait_Onlight()
    {
        yield return new WaitForSeconds(2.8f);
        turnOn = true;
    }

    IEnumerator wait_Offlight()
    {
        yield return new WaitForSeconds(2.8f);
        turnOff = true;
    }
}
