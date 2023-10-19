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

    public void weaponCollected()
    {
        _weapon.SetActive(true);
        _bgweapon.SetActive(true);
    }

    public void weaponClicked()
    {
        Player player = GameObject.Find("Player").GetComponent<Player>();
        if (player != null)
        {
            player._isPressed = false;
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
