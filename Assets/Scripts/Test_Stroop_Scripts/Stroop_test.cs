using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using System;

public class Stroop_test : MonoBehaviour
{
    [SerializeField]
    public GameObject _canvasStroop;
    [SerializeField]
    public Image _background;
    [SerializeField]
    private Button finish_btn;
    [SerializeField]
    private Image bar_fill;
    [SerializeField]
    private Sprite pb_clean;
    [SerializeField]
    private Sprite pb_postit;

    public String color1_txt;
    public String color2_txt;
    public String color3_txt;

    public TextMeshProUGUI title_color1_txt;
    public TextMeshProUGUI title_color2_txt;
    public TextMeshProUGUI title_color3_txt;

    public TMP_Dropdown color1_dd;
    public TMP_Dropdown color2_dd;
    public TMP_Dropdown color3_dd;

    
    private int count=0;
    public DateTime tiempo1, tiempo2;

    public string month;
    public string day;
    public string year;
    public string hour;
    public string _min;

    public bool _hasfinish_stoop;

    [SerializeField] GameObject arrowBtn;
    [SerializeField] TextMeshProUGUI timer_text;
    public float remaining_time;
    private int minutes;
    private int seconds;

    public bool next;
    public bool restart=true;
    private bool start;
    public bool time;

    public string actual_date;
    public float timer = 0;

    //initialize variable count
    public void Start()
    {
        tiempo1 = DateTime.Now;
        month = DateTime.Now.ToString("MM");
        day = DateTime.Now.ToString("dd");
        year = DateTime.Now.ToString("yyyy");
        hour = DateTime.Now.ToString("HH");
        _min = DateTime.Now.ToString("mm");
        actual_date = day + "_" + month + "_" + year + "__" + hour + "_" + _min;
        
        next = true;
        time = false;
        //nextTest();
        testOptions();
    }

    public void canStart()
    {
        restart = true;
        start = true;
        //nextTest();
        
    }

    //checks if there are more tests to continue or not
    public void Update()
    {

        if (count >= 10 && time == false)
        {
            arrowBtn.gameObject.SetActive(false);
            title_color1_txt.gameObject.SetActive(false);
            title_color2_txt.gameObject.SetActive(false);
            title_color3_txt.gameObject.SetActive(false);
            color1_dd.gameObject.SetActive(false);
            color2_dd.gameObject.SetActive(false);
            color3_dd.gameObject.SetActive(false);
            timer_text.gameObject.SetActive(false);
            _background.sprite = pb_clean;
            arrowBtn.gameObject.SetActive(false);
            finish_btn.gameObject.SetActive(true);
            saveTimeResults();
            removeFirst();
            time = true;
        }
        else if (start == true)
        {
            timer += Time.deltaTime; 
            remaining_time = timer; 

            int minutes = Mathf.FloorToInt(remaining_time / 60);
            int seconds = Mathf.FloorToInt(remaining_time % 60);
            minutes = Mathf.Abs(minutes);
            seconds = Mathf.Abs(seconds);
            timer_text.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }

        if ((color1_dd.value != 0 && color2_dd.value != 0 && color3_dd.value != 0))
        {
            selectColors();
            arrowBtn.gameObject.SetActive(true);

        }
        

    }


    public void selectColors()
    {
        color1_dd.onValueChanged.AddListener(delegate
        {
            UpdateColorText(1, color1_dd.value);
        });

        color2_dd.onValueChanged.AddListener(delegate
        {
            UpdateColorText(2, color2_dd.value);
        });

        color3_dd.onValueChanged.AddListener(delegate
        {
            UpdateColorText(3, color3_dd.value);
        });
    }

    private void UpdateColorText(int colorNumber, int colorIndex)
    {
        string colorName = "";
        switch (colorIndex)
        {
            case 1:
                colorName = "ROJO";
                break;
            case 2:
                colorName = "NARANJA";
                break;
            case 3:
                colorName = "AMARILLO";
                break;
            case 4:
                colorName = "VERDE";
                break;
            case 5:
                colorName = "AZUL";
                break;
            case 6:
                colorName = "MORADO";
                break;
        }

        switch (colorNumber)
        {
            case 1:
                color1_txt = colorName;
                break;
            case 2:
                color2_txt = colorName;
                break;
            case 3:
                color3_txt = colorName;
                break;
        }
    }



    public void finishStroop()
    {
        show_cards show = GameObject.Find("Cards").GetComponent<show_cards>();
        if(show != null)
        {
            show.show_weapon_card();
        }

        Player player = GameObject.Find("Player").GetComponent<Player>();
        if (player != null)
        {
            player._doingTest = false;
        }

        UI_Manager ui_manager = GameObject.Find("Inventry").GetComponent<UI_Manager>();
        if (ui_manager != null)
        {
            ui_manager.weaponCollected();
        }

        Raycast raycast = GameObject.Find("pinboard").GetComponent<Raycast>();
        if (raycast != null)
        {
            raycast.canMove = false;
        }

        _canvasStroop.SetActive(false);
    }


    public void defaultValues()
    {
        arrowBtn.gameObject.SetActive(false);
        color1_txt = " ";
        color2_txt = " ";
        color3_txt = " ";
        _background.sprite = pb_postit;
        color1_dd.value = 0; color2_dd.value = 0; color3_dd.value = 0;
        next = true;
    }


    public void saveTimeResults()
    {
        tiempo2 = DateTime.Now;
        string path = "C:/Users/sandr.LAPTOP-GVVQRNIB/Documents/GitHub/TFG_SandraCiudad/Assets/Results/Stroop/Time_" + actual_date + ".txt";
        string text = (tiempo2 - tiempo1).Hours + " horas " + (tiempo2 - tiempo1).Minutes + " minutos " + (tiempo2 - tiempo1).Seconds + " segundos";

        File.AppendAllLines(path, new String[] { text });
    }

    public void saveTestsResults()
    {

        string path = "C:/Users/sandr.LAPTOP-GVVQRNIB/Documents/GitHub/TFG_SandraCiudad/Assets/Results/Stroop/Results_" + actual_date + ".txt";
        string text = color1_txt + ", " + color2_txt + ", " + color3_txt;
        File.AppendAllLines(path, new String[] { text });
    }

    public void removeFirst()
    {
        string path = "C:/Users/sandr.LAPTOP-GVVQRNIB/Documents/GitHub/TFG_SandraCiudad/Assets/Results/Stroop/Results_" + actual_date + ".txt";

        if (File.Exists(path))
        {
            string[] lines = File.ReadAllLines(path);
            if (lines.Length >= 2)
            {
                string[] newLines = new string[lines.Length - 1];
                Array.Copy(lines, 1, newLines, 0, newLines.Length);
                File.WriteAllLines(path, newLines);
            }
        }
    }



    public void UpdateProgress()
    {
        count++;
        float amount = (float)count / 10;
        bar_fill.fillAmount = amount;
    }


    
    public void testOptions()
    {
        Color red = Color.HSVToRGB(0 / 360f, 100 / 100f, 100 / 100f);
        Color orange = Color.HSVToRGB(32 / 360f, 100 / 100f, 100 / 100f);
        Color yellow = Color.HSVToRGB(52 / 360f, 100 / 100f, 100 / 100f);
        Color green = Color.HSVToRGB(108 / 360f, 100 / 100f, 100 / 100f);
        Color blue = Color.HSVToRGB(215 / 360f, 100 / 100f, 100 / 100f);
        Color purple = Color.HSVToRGB(279 / 360f, 100 / 100f, 100 / 100f);

        if (count == 0)
        {
            title_color1_txt.text = "VERDE"; title_color1_txt.color = orange;
            title_color2_txt.text = "AZUL"; title_color2_txt.color = red;
            title_color3_txt.text = "MORADO"; title_color3_txt.color = yellow;
        }
        if (count == 1)
        {
            title_color1_txt.text = "AZUL"; title_color1_txt.color = orange;
            title_color2_txt.text = "AMARILLO"; title_color2_txt.color = blue;
            title_color3_txt.text = "MORADO"; title_color3_txt.color = red;
        } else if (count == 2)
        {
            title_color1_txt.text = "MORADO"; title_color1_txt.color = yellow;
            title_color2_txt.text = "ROJO"; title_color2_txt.color = blue;
            title_color3_txt.text = "NARANJA"; title_color3_txt.color = green;
        } else if (count == 3)
        {
            title_color1_txt.text = "VERDE"; title_color1_txt.color = blue;
            title_color2_txt.text = "AMARILLO"; title_color2_txt.color = orange;
            title_color3_txt.text = "ROJO"; title_color3_txt.color = purple;
        } else if (count == 4)
        {
            title_color1_txt.text = "AMARILLO"; title_color1_txt.color = red;
            title_color2_txt.text = "ROJO"; title_color2_txt.color = purple;
            title_color3_txt.text = "MORADO"; title_color3_txt.color = yellow;
        } else if (count == 5)
        {
            title_color1_txt.text = "NARANJA"; title_color1_txt.color = yellow;
            title_color2_txt.text = "ROJO"; title_color2_txt.color = green;
            title_color3_txt.text = "AMARILLO"; title_color3_txt.color = blue;
        } else if (count == 6)
        {
            title_color1_txt.text = "AZUL"; title_color1_txt.color = green;
            title_color2_txt.text = "MORADO"; title_color2_txt.color = green;
            title_color3_txt.text = "VERDE"; title_color3_txt.color = orange;
        } else if (count == 7)
        {
            title_color1_txt.text = "ROJO"; title_color1_txt.color = orange;
            title_color2_txt.text = "NARANJA"; title_color2_txt.color = purple;
            title_color3_txt.text = "AZUL"; title_color3_txt.color = red;
        } else if (count == 8)
        {
            title_color1_txt.text = "VERDE"; title_color1_txt.color = purple;
            title_color2_txt.text = "VERDE"; title_color2_txt.color = yellow;
            title_color3_txt.text = "MORADO"; title_color3_txt.color = green;
        } else if (count == 9)
        {
            title_color1_txt.text = "AZUL"; title_color1_txt.color = purple;
            title_color2_txt.text = "ROJO"; title_color2_txt.color = orange;
            title_color3_txt.text = "AMARILLO"; title_color3_txt.color = red;

        } else if (count == 10)
        {
            title_color1_txt.text = "NARANJA"; title_color1_txt.color = red;
            title_color2_txt.text = "VERDE"; title_color2_txt.color = blue;
            title_color3_txt.text = "NARANJA"; title_color3_txt.color = yellow;

        }
    }


    
    //method to change test
    public void nextTest()
    {
        saveTestsResults();
        UpdateProgress();
        //count = count + 1;
        defaultValues();
        testOptions();
        restart = true;
    }

}
