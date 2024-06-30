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
    private Image _placeCard;
    [SerializeField]
    private Image _extraCard;
    [SerializeField]
    private Image _killerCard;

    [SerializeField]
    private Button _confirm_btn;

    

    public void confirm_btn_click()
    {
        _weaponCard.gameObject.SetActive(false);
        _reasonCard.gameObject.SetActive(false);
        _placeCard.gameObject.SetActive(false);
        _extraCard.gameObject.SetActive(false);
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

    public void show_place_card()
    {
        Player player = GameObject.Find("Player").GetComponent<Player>();
        if (player != null)
        {
            player._isPressed = false;
        }
        _placeCard.gameObject.SetActive(true);
        _confirm_btn.gameObject.SetActive(true);

    }


    public void show_extra_card()
    {
        Player player = GameObject.Find("Player").GetComponent<Player>();
        if (player != null)
        {
            player._isPressed = false;
        }
        _extraCard.gameObject.SetActive(true);
        _confirm_btn.gameObject.SetActive(true);
    }

    public void show_killer_card()
    {
        Player player = GameObject.Find("Player").GetComponent<Player>();
        if (player != null)
        {
            player._isPressed = false;
        }
        _killerCard.gameObject.SetActive(true);
        _confirm_btn.gameObject.SetActive(true);

    }
}
