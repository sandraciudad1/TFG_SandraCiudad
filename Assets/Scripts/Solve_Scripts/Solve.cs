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
    private Button solve_btn;

    [SerializeField]
    private GameObject buttons;
    [SerializeField]
    private Button acusar_btn;

    [SerializeField]
    private Image bg_xavier;
    [SerializeField]
    private Image bg_giovanni;
    [SerializeField]
    private Image bg_emma;
    [SerializeField]
    private Image bg_gertrud;
    [SerializeField]
    private Image bg_gustavo;
    [SerializeField]
    private Image bg_alessandro;

    [SerializeField]
    private GameObject _Giovanni;
    [SerializeField]
    private GameObject knife;
    [SerializeField]
    private TextMeshProUGUI bodega_msg;
    [SerializeField]
    private Button ok_bodega_msg;

    public string name;
    public bool success;
    public bool check;
    public bool _isColliding;

    private DateTime tiempo1, tiempo2;

    public int count;

    [SerializeField]
    private TextMeshProUGUI correct_solution;
    [SerializeField]
    private TextMeshProUGUI incorrect_solution;


    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        check = false;
        _isColliding = false;
    }

    // Update is called once per frame
    public void Update()
    {
        Player player = GameObject.Find("Player").GetComponent<Player>();
        if (_weapon.activeInHierarchy == true && _place.activeInHierarchy == true && _extra.activeInHierarchy == true && _reason.activeInHierarchy == true && count == 0)
        {

            if (player != null)
            {
                if (player._doingTest == false && player._isPressed == true && player._canMove == true)
                {
                    tiempo1 = DateTime.Now;
                    background.gameObject.SetActive(true);
                    solve_text.gameObject.SetActive(true);
                    player._canMove = false;
                }
            }
            count += 1;

        }


        if (_isColliding == true)
        {
            player._isPressed = false;
            animationController_solution sol = GameObject.Find("Giovanni").GetComponent<animationController_solution>();
            animationController_knife knife = GameObject.Find("knife").GetComponent<animationController_knife>();
            if (sol != null && knife != null)
            {
                sol._canStart = true;
                knife._canStart = true;
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
        solve_btn.gameObject.SetActive(true);
        
    }


    public void solve_btn_pressed()
    {
        background.gameObject.SetActive(true);
        buttons.SetActive(true);
    }

    public void Xavier_pressed()
    {
        bg_xavier.color = Color.red;
        acusar_btn.gameObject.SetActive(true);
        name = "Xavier";
    }

    public void Giovanni_pressed()
    {
        bg_giovanni.color = Color.red;
        acusar_btn.gameObject.SetActive(true);
        name = "Giovanni";
    }

    public void Emma_pressed()
    {
        bg_emma.color = Color.red;
        acusar_btn.gameObject.SetActive(true);
        name = "Emma";
    }

    public void Gertrud_pressed()
    {
        bg_gertrud.color = Color.red;
        acusar_btn.gameObject.SetActive(true);
        name = "Gertrud";
    }

    public void Gustavo_pressed()
    {
        bg_gustavo.color = Color.red;
        acusar_btn.gameObject.SetActive(true);
        name = "Gustavo";
    }

    public void Alessandro_pressed()
    {
        bg_alessandro.color = Color.red;
        acusar_btn.gameObject.SetActive(true);
        name = "Alessandro";
    }

    public void ok_bodega_pressed()
    {
        background.gameObject.SetActive(false);
        bodega_msg.gameObject.SetActive(false);
        ok_bodega_msg.gameObject.SetActive(false);
        Player player = GameObject.Find("Player").GetComponent<Player>();
        if (player != null)
        {
            player._doingTest = false;
            player._isPressed = true;
            player._canMove = true;
            //check = true;
            //Update();
        }
        Giovanni g = GameObject.Find("Giovanni").GetComponent<Giovanni>();
        if (g != null)
        {
            g._start = true;
        }
    }

    public void acusar_btn_pressed()
    {
        buttons.SetActive(false);
        acusar_btn.gameObject.SetActive(false);

        _Giovanni.SetActive(true);
        knife.SetActive(true);


        bodega_msg.gameObject.SetActive(true);
        ok_bodega_msg.gameObject.SetActive(true);

        //check_player_position();
        
        

        //-     mesaje de dirigirse a bodega
        //-     activar el gameobject del asesino
        //-         comprobar si la pos del jugador es la bodega
        //-         paralizar movimientos jugador
        //darle la vuelta al asesino
        //el asesino cuenta la historia
        //comprobar si el usuario ha acertado
        //en caso de si: asesino se pone triste y se va arrestado
        //en caso de no: el asesino se pone contento y escapa
        //mensaje al usuario para que sepa si ha resuelto o no
        //si ha resuelto: medalla por resolver
        
        
        /*if (name == "Giovanni")
        {
            correct_solution.gameObject.SetActive(true);
        }
        else
        {
            incorrect_solution.gameObject.SetActive(true);
        }*/





        /*tiempo2 = DateTime.Now;
        string path = "C:/Users/sandr.LAPTOP-GVVQRNIB/Documents/GitHub/TFG_SandraCiudad/Assets/Results/Solution/Time.txt";
        string text = (tiempo2 - tiempo1).Hours + " horas " + (tiempo2 - tiempo1).Minutes + " minutos " + (tiempo2 - tiempo1).Seconds + " segundos";
        File.AppendAllLines(path, new String[] { text });

        UI_Manager ui = GameObject.Find("Inventry").GetComponent<UI_Manager>();
        charactersInfo characters = GameObject.Find("Characters_info").GetComponent<charactersInfo>();
        if (ui != null && characters != null)
        {
            string path_res = "C:/Users/sandr.LAPTOP-GVVQRNIB/Documents/GitHub/TFG_SandraCiudad/Assets/Results/Solution/Results.txt";
            string text_result = "Número de veces que se ha consultado información \n\t Arma: " + ui.weapon_counter + " veces" + "\n\t Lugar: " + ui.place_counter + " veces" + "\n\t Motivo: " + ui.reason_counter + " veces" + "\n\t Pista extra: " + ui.extra_counter + " veces" 
                                + "\n\t Personajes: " + characters.characters_counter + " veces";
            File.AppendAllLines(path_res, new String[] { text_result });
        }*/

    }


}
