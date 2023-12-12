using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using System;

public class Solve : MonoBehaviour
{
    [SerializeField]
    private GameObject _weapon;
    [SerializeField]
    private GameObject _place;
    [SerializeField]
    private GameObject _extra;
    [SerializeField]
    private GameObject _reason;

    [SerializeField]
    private Image background;
    [SerializeField]
    private TextMeshProUGUI solve_text;
    [SerializeField]
    private Button ok_solve_btn;
    [SerializeField]
    private Image bg_solve;
    [SerializeField]
    private Button solve_btn;

    [SerializeField]
    private GameObject buttons;
    [SerializeField]
    private Button acusar_btn;

    private DateTime tiempo1, tiempo2;

    public int count;


    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_weapon.activeInHierarchy == true && _place.activeInHierarchy == true && _extra.activeInHierarchy == true && _reason.activeInHierarchy == true && count == 0)
        {
            Player player = GameObject.Find("Player").GetComponent<Player>();
            if (player != null)
            {
                tiempo1 = DateTime.Now;
                player._isPressed = false;
                background.gameObject.SetActive(true);
                solve_text.gameObject.SetActive(true);
                count += 1;
            }
            
        }
    }

    public void checkFinish()
    {
        typewriter_solve typewriter = GameObject.Find("Solve").GetComponent<typewriter_solve>();
        if (typewriter != null && typewriter._finishWritting == true)
        {
            ok_solve_btn.gameObject.SetActive(true);
            typewriter._finishWritting = false;
        }
    }

    public void ok_btn_pressed()
    {
        background.gameObject.SetActive(false);
        solve_text.gameObject.SetActive(false);
        ok_solve_btn.gameObject.SetActive(false);
        bg_solve.gameObject.SetActive(true);
        solve_btn.gameObject.SetActive(true);
    }


    public void solve_btn_pressed()
    {
        background.gameObject.SetActive(true);
        buttons.SetActive(true);
    }

    public void character_pressed()
    {
        acusar_btn.gameObject.SetActive(true);
    }

    public void acusar_btn_pressed()
    {
        background.gameObject.SetActive(false);
        buttons.SetActive(false);
        acusar_btn.gameObject.SetActive(false);


        //Metricas
        File.Delete("C:/Users/sandr.LAPTOP-GVVQRNIB/Documents/GitHub/TFG_SandraCiudad/Assets/Results/Solution/Results.txt");
        File.Delete("C:/Users/sandr.LAPTOP-GVVQRNIB/Documents/GitHub/TFG_SandraCiudad/Assets/Results/Solution/Time.txt");

        tiempo2 = DateTime.Now;
        string path = "C:/Users/sandr.LAPTOP-GVVQRNIB/Documents/GitHub/TFG_SandraCiudad/Assets/Results/Solution/Time.txt";
        string text = (tiempo2 - tiempo1).Hours + " horas " + (tiempo2 - tiempo1).Minutes + " minutos " + (tiempo2 - tiempo1).Seconds + " segundos";
        File.AppendAllLines(path, new String[] { text });

        UI_Manager ui = GameObject.Find("Inventry").GetComponent<UI_Manager>();
        if (ui != null)
        {
            string path_res = "C:/Users/sandr.LAPTOP-GVVQRNIB/Documents/GitHub/TFG_SandraCiudad/Assets/Results/Solution/Results.txt";
            string text_result = "Número de veces que se ha consultado información \n\t Arma: " + ui.weapon_counter + " veces" + "\n\t Arma: " + ui.weapon_counter + " veces" + "\n\t Lugar: " + 
                                ui.place_counter + " veces" + "\n\t Motivo: " + ui.reason_counter + " veces" + "\n\t Pista extra: " + ui.extra_counter + " veces";
            File.AppendAllLines(path_res, new String[] { text_result });
        }

    }

}
