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
    private GameObject _date;
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
    private GameObject _bgdate;
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


    public void check()
    {
        Player player = GameObject.Find("Player").GetComponent<Player>();
        if (player != null)
        {
            if (player._isPressed == false)
            {
                Debug.Log("en el is pressed");
                possible = false;
                msg_canvas.SetActive(true);
                error_window.SetActive(true);
                ok_errorMsg_btn.gameObject.SetActive(true);
            }
            else if (player._doingTest == true)
            {
                Debug.Log("en el doing test");
                possible = false;
                msg_canvas.SetActive(true);
                error_test.SetActive(true);
                ok_errorMsg_btn.gameObject.SetActive(true);
            }
            else
            {
                Debug.Log("en el possible = true");
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

    public void placeCollected()
    {
        _place.SetActive(true);
        _bgplace.SetActive(true);
    }

    /*public void killerCollected()
    {
        _killer.SetActive(true);
        _bgkiller.SetActive(true);
    }*/

    public void extraCollected()
    {
        _extra.SetActive(true);
        _bgextra.SetActive(true);
    }

    public void dateCollected()
    {
        _date.SetActive(true);
        _bgdate.SetActive(true);
    }

}
