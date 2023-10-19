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
    public GameObject _background;
    [SerializeField]
    private Button finish_btn;

    public TextMeshProUGUI color1_txt;
    public TextMeshProUGUI color2_txt;
    public TextMeshProUGUI color3_txt;

    public TextMeshProUGUI title_color1_txt;
    public TextMeshProUGUI title_color2_txt;
    public TextMeshProUGUI title_color3_txt;

    public TMP_Dropdown color1_dd;
    public TMP_Dropdown color2_dd;
    public TMP_Dropdown color3_dd;

    
    private int count;
    private DateTime tiempo1 = DateTime.Now, tiempo2;
    public bool _hasfinish_stoop;


    //initialize variable count
    private void Start()
    {
        count = 1;
    }


    //checks if there are more tests to continue or not
    private void Update()
    {
        if (count > 1)
        {
            title_color1_txt.gameObject.SetActive(false);
            title_color2_txt.gameObject.SetActive(false);
            title_color3_txt.gameObject.SetActive(false);
            finish_btn.gameObject.SetActive(true);
        }
        else if (count <= 1 && (color1_dd.value != 0 && color2_dd.value != 0 && color3_dd.value != 0))
        {
            saveTestsResults();
            nextTest();
        }
    }


    //Method for edit labels with color selectec in each dropdown
    public void selectColors()
    {
        color1_dd.onValueChanged.AddListener(delegate
        {
            if (color1_dd.value == 1)
            {
                color1_txt.text = "ROJO";
            } else if (color1_dd.value == 2)
            {
                color1_txt.text = "AMARILLO";
            }
            else if (color1_dd.value == 3)
            {
                color1_txt.text = "VERDE";
            } else if (color1_dd.value == 4)
            {
                color1_txt.text = "AZUL";
            }
        });

        color2_dd.onValueChanged.AddListener(delegate
        {
            if (color2_dd.value == 1)
            {
                color2_txt.text = "ROJO";
            }
            else if (color2_dd.value == 2)
            {
                color2_txt.text = "AMARILLO";
            }
            else if (color2_dd.value == 3)
            {
                color2_txt.text = "VERDE";
            }
            else if (color2_dd.value == 4)
            {
                color2_txt.text = "AZUL";
            }
        });

        color3_dd.onValueChanged.AddListener(delegate
        {
            if (color3_dd.value == 1)
            {
                color3_txt.text = "ROJO";
            }
            else if (color3_dd.value == 2)
            {
                color3_txt.text = "AMARILLO";
            }
            else if (color3_dd.value == 3)
            {
                color3_txt.text = "VERDE";
            }
            else if (color3_dd.value == 4)
            {
                color3_txt.text = "AZUL";
            }
        });        
    }



    //Method for finish test
    public void finishStroop()
    {
        show_cards show = GameObject.Find("Cards").GetComponent<show_cards>();
        if(show != null)
        {
            show.show_weapon_card();
        }
        //_hasfinish_stoop = true;

        Player player = GameObject.Find("Player").GetComponent<Player>();
        if (player != null)
        {
            player._doingTest = false;
        }
        Destroy(this.gameObject);

        UI_Manager ui_manager = GameObject.Find("Inventry").GetComponent<UI_Manager>();
        if (ui_manager != null)
        {
            ui_manager.weaponCollected();
        }
        Destroy(this.gameObject);

        tiempo2 = DateTime.Now;
        string path = "C:/Users/sandr.LAPTOP-GVVQRNIB/Documents/GitHub/TFG_SandraCiudad/Assets/Results/Stroop/Time.txt";
        string text = (tiempo2 - tiempo1).Hours + " horas " + (tiempo2 - tiempo1).Minutes + " minutos " + (tiempo2 - tiempo1).Seconds + " segundos";
        File.AppendAllLines(path, new String[] { text });

        _canvasStroop.SetActive(false);
        //_background.SetActive(false);
        //finish_btn.gameObject.SetActive(false);
    }


    //Method for restore default values in dropdown and labels
    public void defaultValues()
    {
        color1_dd.gameObject.SetActive(false);
        color2_dd.gameObject.SetActive(false);
        color3_dd.gameObject.SetActive(false);   
        color1_txt.text = " ";
        color2_txt.text = " ";
        color3_txt.text = " ";
        title_color1_txt.gameObject.SetActive(true);
        title_color2_txt.gameObject.SetActive(true);
        title_color3_txt.gameObject.SetActive(true);
        color1_dd.value = 0; color2_dd.value = 0; color3_dd.value = 0;
    }


    //Method for saving test results in .txt file
    public void saveTestsResults()
    {
        string path = "C:/Users/sandr.LAPTOP-GVVQRNIB/Documents/GitHub/TFG_SandraCiudad/Assets/Results/Stroop/Results.txt";
        string text = color1_txt.text + ", " + color2_txt.text + ", " + color3_txt.text;
        File.AppendAllLines(path, new String[] { text });
    }


    //method that defines all tests labels and colors
    public void testOptions()
    {
        if (count == 1)
        {
            title_color1_txt.text = "AZUL"; title_color1_txt.color = Color.green;
            title_color2_txt.text = "AZUL"; title_color2_txt.color = Color.red;
            title_color3_txt.text = "VERDE"; title_color3_txt.color = Color.yellow;
        } else if (count == 2)
        {
            title_color1_txt.text = "AZUL"; title_color1_txt.color = Color.yellow;
            title_color2_txt.text = "AZUL"; title_color2_txt.color = Color.green;
            title_color3_txt.text = "ROJO"; title_color3_txt.color = Color.blue;
        } else if (count == 3)
        {
            title_color1_txt.text = "AMARILLO"; title_color1_txt.color = Color.blue;
            title_color2_txt.text = "VERDE"; title_color2_txt.color = Color.red;
            title_color3_txt.text = "AMARILLO"; title_color3_txt.color = Color.red;
        } else if (count == 4)
        {
            title_color1_txt.text = "ROJO"; title_color1_txt.color = Color.yellow;
            title_color2_txt.text = "VERDE"; title_color2_txt.color = Color.yellow;
            title_color3_txt.text = "AZUL"; title_color3_txt.color = Color.yellow;
        } else if (count == 5)
        {
            title_color1_txt.text = "AZUL"; title_color1_txt.color = Color.red;
            title_color2_txt.text = "ROJO"; title_color2_txt.color = Color.green;
            title_color3_txt.text = "AMARILLO"; title_color3_txt.color = Color.red;
        } else if (count == 6)
        {
            title_color1_txt.text = "VERDE"; title_color1_txt.color = Color.yellow;
            title_color2_txt.text = "AMARILLO"; title_color2_txt.color = Color.blue;
            title_color3_txt.text = "ROJO"; title_color3_txt.color = Color.yellow;
        } else if (count == 7)
        {
            title_color1_txt.text = "AMARILLO"; title_color1_txt.color = Color.red;
            title_color2_txt.text = "ROJO"; title_color2_txt.color = Color.yellow;
            title_color3_txt.text = "AMARILLO"; title_color3_txt.color = Color.blue;
        } else if (count == 8)
        {
            title_color1_txt.text = "AZUL"; title_color1_txt.color = Color.green;
            title_color2_txt.text = "VERDE"; title_color2_txt.color = Color.blue;
            title_color3_txt.text = "AZUL"; title_color3_txt.color = Color.green;
        } else if (count == 9)
        {
            title_color1_txt.text = "ROJO"; title_color1_txt.color = Color.green;
            title_color2_txt.text = "AZUL"; title_color2_txt.color = Color.yellow;
            title_color3_txt.text = "ROJO"; title_color3_txt.color = Color.green;

        } else if (count == 10)
        {
            title_color1_txt.text = "VERDE"; title_color1_txt.color = Color.blue;
            title_color2_txt.text = "AMARILLO"; title_color2_txt.color = Color.red;
            title_color3_txt.text = "VERDE"; title_color3_txt.color = Color.blue;

        }
    }

    //method to change test
    public void nextTest()
    {
        count = count + 1;
        defaultValues();
        testOptions();
        StartCoroutine(change());
    }


    //coroutine that show test for 5 seconds and then hide 
    IEnumerator change()
    {
        yield return new WaitForSeconds(5.0f);
        title_color1_txt.gameObject.SetActive(false);
        title_color2_txt.gameObject.SetActive(false);
        title_color3_txt.gameObject.SetActive(false);
        color1_dd.gameObject.SetActive(true);
        color2_dd.gameObject.SetActive(true);
        color3_dd.gameObject.SetActive(true);
        selectColors();
    }
}
