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
    public GameObject canvasStroop;

    [SerializeField]
    private GameObject imagen;

    [SerializeField]
    private Button next_btn;

    public TextMeshProUGUI color1_txt;
    public TextMeshProUGUI color2_txt;
    public TextMeshProUGUI color3_txt;

    public TMP_Dropdown color1_dd;
    public TMP_Dropdown color2_dd;
    public TMP_Dropdown color3_dd;



    private void Start()
    {
        next_btn.gameObject.SetActive(false);
        File.Delete("C:/Users/sandr.LAPTOP-GVVQRNIB/Documents/GitHub/TFG_SandraCiudad/Assets/Results/Stroop_results.txt");
        
    }

    private void Update()
    {
        if (color1_dd.value != 0 && color2_dd.value != 0 && color3_dd.value != 0)
        {
            next_btn.gameObject.SetActive(true);
        } else
        {
            next_btn.gameObject.SetActive(false);
        }
    }

    public void selectColors()
    {
        color1_dd.onValueChanged.AddListener(delegate
        {
            color1_changed(color1_dd);
        });

        color2_dd.onValueChanged.AddListener(delegate
        {
            color2_changed(color2_dd);
        });

        color3_dd.onValueChanged.AddListener(delegate
        {
            color3_changed(color3_dd);
        });        
    }


    public void color1_changed(TMP_Dropdown sender)
    {
        if(sender.value == 1)
        {
            color1_txt.text = "ROJO";
            color1_txt.color = Color.red;
        } else if (sender.value == 2)
        {
            color1_txt.text = "AMARILLO";
            color1_txt.color = Color.yellow;
        } else if (sender.value == 3)
        {
            color1_txt.text = "VERDE";
            color1_txt.color = Color.green;
        } else if (sender.value == 4)
        {
            color1_txt.text = "AZUL";
            color1_txt.color = Color.blue;
        } else
        {
            color1_txt.text = " ";
        }
    }

    public void color2_changed(TMP_Dropdown sender)
    {
        if (sender.value == 1)
        {
            color2_txt.text = "ROJO";
            color2_txt.color = Color.red;
        }
        else if (sender.value == 2)
        {
            color2_txt.text = "AMARILLO";
            color2_txt.color = Color.yellow;
        }
        else if (sender.value == 3)
        {
            color2_txt.text = "VERDE";
            color2_txt.color = Color.green;
        }
        else if (sender.value == 4)
        {
            color2_txt.text = "AZUL";
            color2_txt.color = Color.blue;
        } else
        {
            color2_txt.text = " ";
        }
    }

    public void color3_changed(TMP_Dropdown sender)
    {
        if (sender.value == 1)
        {
            color3_txt.text = "ROJO";
            color3_txt.color = Color.red;
        }
        else if (sender.value == 2)
        {
            color3_txt.text = "AMARILLO";
            color3_txt.color = Color.yellow;
        }
        else if (sender.value == 3)
        {
            color3_txt.text = "VERDE";
            color3_txt.color = Color.green;
        }
        else if (sender.value == 4)
        {
            color3_txt.text = "AZUL";
            color3_txt.color = Color.blue;
        } else
        {
            color3_txt.text = " ";
        }
    }


    public void finishStroop()
    {
        canvasStroop.SetActive(false);

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
        Destroy(this.gameObject);

    }

    public void defaultValues()
    {
        color1_dd.gameObject.SetActive(false);
        color2_dd.gameObject.SetActive(false);
        color3_dd.gameObject.SetActive(false);
        
        color1_txt.text = " ";
        color2_txt.text = " ";
        color3_txt.text = " ";
        imagen.SetActive(true);
    }

    public void saveTestsResults()
    {
        string path = "C:/Users/sandr.LAPTOP-GVVQRNIB/Documents/GitHub/TFG_SandraCiudad/Assets/Results/Stroop_results.txt";
        string texto = color1_txt.text + ", " + color2_txt.text + ", " + color3_txt.text;
        File.AppendAllLines(path, new String[] { texto });


        /*TextWriter write = new StreamWriter("C:/Users/sandr.LAPTOP-GVVQRNIB/Documents/GitHub/TFG_SandraCiudad/Assets/Results/Stroop_results.txt");
        write.WriteLine("\n" +color1_txt.text + ", " + color2_txt.text + ", " + color3_txt.text);
        write.Close();*/
    }

    public void image1changing()
    {
        defaultValues();
        StartCoroutine(change());
    }

    public void next_btn_click()
    {
        saveTestsResults();
        image1changing();
    }

    IEnumerator change()
    {
        yield return new WaitForSeconds(5.0f);

        //Reset dropdown values for button desactivation
        color1_dd.value = 0; color2_dd.value = 0; color3_dd.value = 0;
        
        imagen.SetActive(false);
        selectColors();
        color1_dd.gameObject.SetActive(true);
        color2_dd.gameObject.SetActive(true);
        color3_dd.gameObject.SetActive(true);

    }
}
