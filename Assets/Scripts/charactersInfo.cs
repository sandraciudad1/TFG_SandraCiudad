using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charactersInfo : MonoBehaviour
{
    [SerializeField]
    private GameObject _background;
    [SerializeField]
    private GameObject _buttonsCharacters;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showInfo()
    {
        Player player = GameObject.Find("Player").GetComponent<Player>();
        if (player != null)
        {
            player._isPressed = false;
            _background.SetActive(true);
            _buttonsCharacters.SetActive(true);
        }
        
    }


    public void XavierInfo()
    {
        _buttonsCharacters.SetActive(false);

    }

    public void BiancaInfo()
    {
        _buttonsCharacters.SetActive(false);
    }

    public void GiovanniInfo()
    {
        _buttonsCharacters.SetActive(false);
    }

    public void EmmaInfo()
    {
        _buttonsCharacters.SetActive(false);
    }

    public void GertrudInfo()
    {
        _buttonsCharacters.SetActive(false);
    }

    public void GustavoInfo()
    {
        _buttonsCharacters.SetActive(false);
    }

    public void AlessandroInfo()
    {
        _buttonsCharacters.SetActive(false);
    }

}
