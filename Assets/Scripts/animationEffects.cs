using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using System;
public class animationEffects : MonoBehaviour
{
    [SerializeField]
    private GameObject _player;
    [SerializeField]
    private GameObject _pinBoard;
    [SerializeField]
    private Image _pb_original;
    [SerializeField]
    private Image _pb_clean;

    public bool finish;
    
    Vector3 target_pos = new Vector3(13.37f, 0.7f, -9.29f);
    //Vector3 v = new Vector3(0, 0, 0);
    Quaternion target_rot = Quaternion.Euler(0, 0, 0);
    Vector3 scale_change = new Vector3(4, 4, 4);
    Vector3 final_pos = new Vector3(-1.6f, -10.1f, 0f);

    // Start is called before the first frame update
    void Start()
    {
        finish = false;
    }

    // Update is called once per frame
    public void Update()
    {
        float step = 2 * Time.deltaTime;    
        Raycast raycast = GameObject.Find("Pin_Board").GetComponent<Raycast>();
        if (raycast != null)
        {
            Player player = GameObject.Find("Player").GetComponent<Player>();
            Debug.Log("en animation effects canMove = " + raycast.canMove);
            if (player != null && raycast.canMove == true)
            {
                player.transform.position = Vector3.MoveTowards(transform.position, target_pos, step);
                player.transform.localRotation = Quaternion.Slerp(transform.rotation, target_rot, step);
                if (player.transform.position == target_pos)
                {
                    raycast.canMove = false;
                    _pinBoard.SetActive(false);
                    _pb_original.gameObject.SetActive(true);
                    _pb_original.transform.position = Vector3.MoveTowards(transform.position, final_pos, step);
                    _pb_original.transform.localScale = scale_change;
                }
            }
        }
        
            
    }
}
