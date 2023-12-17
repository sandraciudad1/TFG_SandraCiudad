using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UI_Manager : MonoBehaviour
{

    [SerializeField]
    private GameObject _weapon;
    [SerializeField]
    private GameObject _reason;
    [SerializeField]
    private GameObject _place;
    [SerializeField]
    private GameObject _killer;
    [SerializeField]
    private GameObject _extra;

    [SerializeField]
    private GameObject _bgweapon;
    [SerializeField]
    private GameObject _bgreason;
    [SerializeField]
    private GameObject _bgplace;
    [SerializeField]
    private GameObject _bgkiller;
    [SerializeField]
    private GameObject _bgextra;

    [SerializeField]
    private GameObject msg_canvas;
    [SerializeField]
    private GameObject error_window;
    [SerializeField]
    private GameObject error_test;
    [SerializeField]
    private Button ok_errorMsg_btn;

    public bool possible;
    public int weapon_counter;
    public int reason_counter;
    public int place_counter;
    public int extra_counter;

    public void check()
    {
        Player player = GameObject.Find("Player").GetComponent<Player>();
        if (player != null)
        {
            if (player._isPressed == false)
            {
                possible = false;
                msg_canvas.SetActive(true);
                error_window.SetActive(true);
                ok_errorMsg_btn.gameObject.SetActive(true);
            }
            else if (player._doingTest == true)
            {
                possible = false;
                msg_canvas.SetActive(true);
                error_test.SetActive(true);
                ok_errorMsg_btn.gameObject.SetActive(true);
            }
            else
            {
                possible = true;
            }
        }
    }

    public void weaponCollected()
    {
        _weapon.SetActive(true);
        _bgweapon.SetActive(true);
    }

    public void weaponClicked()
    {
        weapon_counter += 1;
        check();
        if(possible == true)
        {
            show_cards show = GameObject.Find("Cards").GetComponent<show_cards>();
            if (show != null)
            {
                show.show_weapon_card();
            }
        }
    }

    public void reasonCollected()
    {
        _reason.SetActive(true);
        _bgreason.SetActive(true);
    }

    public void reasonClicked()
    {
        reason_counter += 1;
        check();
        if (possible == true)
        {
            show_cards show = GameObject.Find("Cards").GetComponent<show_cards>();
            if (show != null)
            {
                show.show_reason_card();
            }
        }
    }

    public void placeCollected()
    {
        _place.SetActive(true);
        _bgplace.SetActive(true);
    }

    public void placeClicked()
    {
        place_counter += 1;
        check();
        if (possible == true)
        {
            show_cards show = GameObject.Find("Cards").GetComponent<show_cards>();
            if (show != null)
            {
                show.show_place_card();
            }
        }
    }


    public void extraCollected()
    {
        _extra.SetActive(true);
        _bgextra.SetActive(true);
    }

    public void extraClicked()
    {
        extra_counter += 1;
        check();
        if (possible == true)
        {
            show_cards show = GameObject.Find("Cards").GetComponent<show_cards>();
            if (show != null)
            {
                show.show_extra_card();
            }
        }
    }


    

}
