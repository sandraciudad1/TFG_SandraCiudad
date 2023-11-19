using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using System;


public class show_cards : MonoBehaviour
{
    [SerializeField]
    private Image _weaponCard;
    [SerializeField]
    private Image _reasonCard;

    [SerializeField]
    private Button _confirm_btn;

    

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    public void confirm_btn_click()
    {
        _weaponCard.gameObject.SetActive(false);
        _reasonCard.gameObject.SetActive(false);
        _confirm_btn.gameObject.SetActive(false);
        Player player = GameObject.Find("Player").GetComponent<Player>();
        if (player != null)
        {
            player._doingTest = false;
            player._isPressed = true;
        }
    }

    public void show_weapon_card()
    {
        Player player = GameObject.Find("Player").GetComponent<Player>();
        if (player != null)
        {
            player._isPressed = false;
        }
        _weaponCard.gameObject.SetActive(true);
        _confirm_btn.gameObject.SetActive(true);

    }

    public void show_reason_card()
    {
        Player player = GameObject.Find("Player").GetComponent<Player>();
        if (player != null)
        {
            player._isPressed = false;
        }
        _reasonCard.gameObject.SetActive(true);
        _confirm_btn.gameObject.SetActive(true);

    }
}
