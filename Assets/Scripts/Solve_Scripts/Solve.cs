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
    private GameObject _killer;


    [SerializeField]
    private GameObject bg_weapon;
    [SerializeField]
    private GameObject bg_place;
    [SerializeField]
    private GameObject bg_extra;
    [SerializeField]
    private GameObject bg_reason;
    [SerializeField]
    private GameObject bg_killer;


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
    public bool anim;
    public bool _story;
    public bool wait;
    public int solution;
    public bool acusar;


    public string month;
    public string day;
    public string year;
    public string hour;
    public string _min;
    public string actual_date;

    private DateTime tiempo1, tiempo2;

    public int count;
    public int weapon_counter;
    public int reason_counter;
    public int place_counter;
    public int extra_counter;
    public int characters_counter;
    public int Xavier_counter;
    public int Bianca_counter;
    public int Giovanni_counter;
    public int Emma_counter;
    public int Gertrud_counter;
    public int Gustavo_counter;
    public int Alessandro_counter;


    [SerializeField]
    private TextMeshProUGUI correct_solution;
    [SerializeField]
    private TextMeshProUGUI incorrect_solution;

    Vector3 player_infront_pos = new Vector3(-10f, 0f, 6f);
    Quaternion player_infront_rot = Quaternion.Euler(0f, 270f, 0f);

    [SerializeField]
    private Image win;
    [SerializeField]
    private Image lose;

    public bool save;
    public int counter_solve;
    [SerializeField]
    private Button close_btn_solution;
    [SerializeField]
    private GameObject msg_canvas;
    [SerializeField]
    private GameObject error_window;
    [SerializeField]
    private Button ok_errorMsg_btn;

    public int coches;
    public int lamparas;
    public int ordenadores;
    public int aire_acondicionado;
    public int reflectantes;
    public int otros;
    public int total_counter;

    [SerializeField] private Button soundBtn1;
    [SerializeField] private TextMeshProUGUI skip;
    [SerializeField] private TextMeshProUGUI s;

    // Start is called before the first frame update
    public void Start()
    {
        //acusar_btn.gameObject.SetActive(false);
        count = 0;
        check = false;
        _isColliding = false;
        anim = false;
        _story = false;
        wait = false;
        save = false;
    }

    // Update is called once per frame
    public void Update()
    {
        clickControl cc = GameObject.Find("Solve").GetComponent<clickControl>();
        if (cc != null)
        {
            coches = cc.coches;
            lamparas = cc.lamparas;
            ordenadores = cc.ordenadores;
            aire_acondicionado = cc.aire_acondicionado;
            reflectantes = cc.reflectantes;
            otros = cc.otros;
            total_counter = coches + lamparas + ordenadores + aire_acondicionado + reflectantes + otros;
        }


        if((win.gameObject.activeInHierarchy || lose.gameObject.activeInHierarchy) && save == false)
        {
            saveResults();
            saveTimeResults();
            save = true;
        }


        if (acusar == false)
        {
            if (name == "Giovanni")
            {
                solution = 1;
            } else if (name == "Xavier" || name == "Emma" || name == "Gustavo" || name == "Gertrud" || name == "Alessandro")
            {
                solution = -1;
            }
        }
        

        Player player = GameObject.Find("Player").GetComponent<Player>();
        if (_weapon.activeInHierarchy == true && _place.activeInHierarchy == true && _extra.activeInHierarchy == true && _reason.activeInHierarchy == true && count == 0)
        {
            tiempo1 = DateTime.Now;
            month = DateTime.Now.ToString("MM");
            day = DateTime.Now.ToString("dd");
            year = DateTime.Now.ToString("yyyy");
            hour = DateTime.Now.ToString("HH");
            _min = DateTime.Now.ToString("mm");
            actual_date = day + "_" + month + "_" + year + "__" + hour + "_" + _min;

            if (player != null)
            {
                if (player._doingTest == false && player._isPressed == true && player._canMove == true)
                {
                    background.gameObject.SetActive(true);
                    solve_text.gameObject.SetActive(true);
                    soundBtn1.gameObject.SetActive(true);
                    skip.gameObject.SetActive(true);
                    s.gameObject.SetActive(true);
                    player._canMove = false;
                    count += 1;
                }
            }
           

        }


        if (_isColliding == true && _weapon.activeInHierarchy == true && _place.activeInHierarchy == true && _extra.activeInHierarchy == true && _reason.activeInHierarchy == true)
        {
            player._isPressed = false;
            float step = Time.deltaTime;
            player.transform.position = Vector3.MoveTowards(player.transform.position, player_infront_pos, step * 2);
            player.transform.rotation = Quaternion.RotateTowards(player.transform.rotation, player_infront_rot, step * 10);
            if(player.transform.position == player_infront_pos && player.transform.rotation == player_infront_rot && anim == false)
            {
                
                animationController_solution sol = GameObject.Find("Giovanni").GetComponent<animationController_solution>();
                animationController_knife knife = GameObject.Find("knife").GetComponent<animationController_knife>();
                if (sol != null && knife != null)
                {
                    sol._canStart = true;
                    knife._canStart = true;
                }
                anim = true;
            }
        }

        if (anim == true && _story == false)
        {
            _weapon.gameObject.SetActive(false);
            _place.gameObject.SetActive(false);
            _extra.gameObject.SetActive(false);
            _reason.gameObject.SetActive(false);
            _killer.gameObject.SetActive(false);

            bg_weapon.gameObject.SetActive(false);
            bg_place.gameObject.SetActive(false);
            bg_extra.gameObject.SetActive(false);
            bg_reason.gameObject.SetActive(false);
            bg_killer.gameObject.SetActive(false);

            StartCoroutine(wait_anim());
            Story story = GameObject.Find("story").GetComponent<Story>();
            if (story != null && wait == true)
            {
                story.startIntroduction();
                _story = true;
            }
        }

    }

    IEnumerator wait_anim()
    {
        yield return new WaitForSeconds(1.5f);
        wait = true;
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
        soundBtn1.gameObject.SetActive(true);
        skip.gameObject.SetActive(false);
        s.gameObject.SetActive(false);
    }

    public void solve_btn_pressed()
    {
        counter_solve += 1;
        Player player = GameObject.Find("Player").GetComponent<Player>();
        if (player != null)
        {

            if (player._isPressed == false)
            {
                msg_canvas.SetActive(true);
                error_window.SetActive(true);
                ok_errorMsg_btn.gameObject.SetActive(true);
            } 
            else
            {
                close_btn_solution.gameObject.SetActive(true);
                _Giovanni.SetActive(true);
                knife.SetActive(true);
                background.gameObject.SetActive(true);
                buttons.SetActive(true);
                player._isPressed = false;
            }
        }
    }

    public void errorMsg_btn_click()
    {
        msg_canvas.SetActive(false);
        error_window.SetActive(false);
        ok_errorMsg_btn.gameObject.SetActive(false);
    }

    public void close_btn_clicked()
    {
        Player player = GameObject.Find("Player").GetComponent<Player>();
        if (player != null)
        {
            player._isPressed = true;
        }
        buttons.SetActive(false);
        close_btn_solution.gameObject.SetActive(false);
        background.gameObject.SetActive(false);
    }

    public void reset_values()
    {
        bg_xavier.color = Color.white;
        bg_giovanni.color = Color.white;
        bg_emma.color = Color.white;
        bg_gertrud.color = Color.white;
        bg_gustavo.color = Color.white;
        bg_alessandro.color = Color.white;
        name = "";
    }

    public void Xavier_pressed()
    {
        reset_values();
        bg_xavier.color = Color.red;
        acusar_btn.gameObject.SetActive(true);
        name = "Xavier";
        animationController_solution anim = GameObject.Find("Giovanni").GetComponent<animationController_solution>();
        if (anim != null)
        {
            anim.solution = false;
        }
    }

    public void Giovanni_pressed()
    {
        reset_values();
        bg_giovanni.color = Color.red;
        acusar_btn.gameObject.SetActive(true);
        name = "Giovanni";
        animationController_solution anim = GameObject.Find("Giovanni").GetComponent<animationController_solution>();
        if (anim != null)
        {
            anim.solution = true;
        }
    }

    public void Emma_pressed()
    {
        reset_values();
        bg_emma.color = Color.red;
        acusar_btn.gameObject.SetActive(true);
        name = "Emma";
        animationController_solution anim = GameObject.Find("Giovanni").GetComponent<animationController_solution>();
        if (anim != null)
        {
            anim.solution = false;
        }
    }

    public void Gertrud_pressed()
    {
        reset_values();
        bg_gertrud.color = Color.red;
        acusar_btn.gameObject.SetActive(true);
        name = "Gertrud";
        animationController_solution anim = GameObject.Find("Giovanni").GetComponent<animationController_solution>();
        if (anim != null)
        {
            anim.solution = false;
        }
    }

    public void Gustavo_pressed()
    {
        reset_values();
        bg_gustavo.color = Color.red;
        acusar_btn.gameObject.SetActive(true);
        name = "Gustavo";
        animationController_solution anim = GameObject.Find("Giovanni").GetComponent<animationController_solution>();
        if (anim != null)
        {
            anim.solution = false;
        }
    }

    public void Alessandro_pressed()
    {
        reset_values();
        bg_alessandro.color = Color.red;
        acusar_btn.gameObject.SetActive(true);
        name = "Alessandro";
        animationController_solution anim = GameObject.Find("Giovanni").GetComponent<animationController_solution>();
        if (anim != null)
        {
            anim.solution = false;
        }
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



    public void saveTimeResults()
    {
        tiempo2 = DateTime.Now;
        string path = "C:/Users/sandr.LAPTOP-GVVQRNIB/Documents/GitHub/TFG_SandraCiudad/Assets/Results/Solution/Time_" + actual_date + ".txt";
        string text = (tiempo2 - tiempo1).Hours + " horas " + (tiempo2 - tiempo1).Minutes + " minutos " + (tiempo2 - tiempo1).Seconds + " segundos";
        File.AppendAllLines(path, new String[] { text });
    }

    public void saveResults()
    {
        string path_res = "C:/Users/sandr.LAPTOP-GVVQRNIB/Documents/GitHub/TFG_SandraCiudad/Assets/Results/Solution/Results_" + actual_date + ".txt";
        string text_result = "Número de veces que se ha consultado información \n\t Arma: " + weapon_counter + " veces" + "\n\t Lugar: " + place_counter + " veces" + "\n\t Motivo: " + reason_counter + " veces" + "\n\t Pista extra: " + extra_counter + " veces" +
                            
                            "\n\t Personajes: " + characters_counter + " veces" + "\n\t\t Bianca: " + Bianca_counter + " veces" + "\n\t\t Xavier: " + Xavier_counter + " veces" + "\n\t\t Giovanni: " + Giovanni_counter + " veces" + "\n\t\t Emma: " + 
                            Emma_counter + " veces" + "\n\t\t Gertrud: " + Gertrud_counter + " veces" + "\n\t\t Gustavo: " + Gustavo_counter + " veces" + "\n\t\t Alessandro: " + Alessandro_counter + " veces" + 
                            
                            "\n\n Número de veces que se ha presionado el botón de solucionar: " + counter_solve + " veces" + 
                            
                            "\n\n Se han presionado " + total_counter + " objetos no relacionados con las pistas, de los cuales: " + "\n\t Coches: " + coches + "\n\t Lámparas: " + lamparas + "\n\t Ordenadores: " + ordenadores + 
                            "\n\t Aire acondicionado: " + aire_acondicionado + "\n\t Objetos que reflejan o desprenden una pequeña luz: " + reflectantes +"\n\t Otros: " + otros;
        File.AppendAllLines(path_res, new String[] { text_result });
    }

    public void acusar_btn_pressed()
    {
        buttons.SetActive(false);
        acusar_btn.gameObject.SetActive(false);

        solve_btn.gameObject.SetActive(false);

        bodega_msg.gameObject.SetActive(true);
        ok_bodega_msg.gameObject.SetActive(true);
    }


}
