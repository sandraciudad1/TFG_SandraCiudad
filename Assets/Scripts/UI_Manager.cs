using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Manager : MonoBehaviour
{
    [SerializeField]
    private GameObject _pistol;
    [SerializeField]
    private GameObject _bg;

    public void visibleBackground()
    {
        _bg.SetActive(true);
    }

    public void pistolCollected()
    {
        _pistol.SetActive(true);
    }

}
