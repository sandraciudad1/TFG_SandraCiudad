using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using System;
using System.Threading;

public class Caras_test : MonoBehaviour
{
    [SerializeField]
    public GameObject _canvasCaras;
    [SerializeField]
    public GameObject _background;
    [SerializeField]
    private Button finish_btn_caras;
    [SerializeField]
    private Image bar_fill;

    [SerializeField]
    private Sprite caras11;
    [SerializeField]
    private Sprite caras12; 
    [SerializeField]
    private Sprite caras13;
    [SerializeField]
    private Sprite caras21;
    [SerializeField]
    private Sprite caras22;
    [SerializeField]
    private Sprite caras23;
    [SerializeField]
    private Sprite caras31;
    [SerializeField]
    private Sprite caras32;
    [SerializeField]
    private Sprite caras33;
    [SerializeField]
    private Sprite caras41;
    [SerializeField]
    private Sprite caras42;
    [SerializeField]
    private Sprite caras43;
    [SerializeField]
    private Sprite caras51;
    [SerializeField]
    private Sprite caras52;
    [SerializeField]
    private Sprite caras53;
    [SerializeField]
    private Sprite caras61;
    [SerializeField]
    private Sprite caras62;
    [SerializeField]
    private Sprite caras63;

    /*[SerializeField]
    private Sprite test_caras71;
    [SerializeField]
    private Sprite test_caras72;
    [SerializeField]
    private Sprite test_caras73;
    [SerializeField]
    private Sprite test_caras74;
    [SerializeField]
    private Sprite test_caras81;
    [SerializeField]
    private Sprite test_caras82;
    [SerializeField]
    private Sprite test_caras83;
    [SerializeField]
    private Sprite test_caras84;
    [SerializeField]
    private Sprite test_caras91;
    [SerializeField]
    private Sprite test_caras92;
    [SerializeField]
    private Sprite test_caras93;
    [SerializeField]
    private Sprite test_caras94;
    [SerializeField]
    private Sprite test_caras101;
    [SerializeField]
    private Sprite test_caras102;
    [SerializeField]
    private Sprite test_caras103;
    [SerializeField]
    private Sprite test_caras104;*/

    [SerializeField]
    private float timerTime;
    public int min, seg = 15, intervalo = 1;
    public float nextTime = 0;

    public Button img1;
    public Button img2;
    public Button img3;
    
    /*public Image image1;
    public Image image2;
    public Image image3;
    public Image image4;*/
   
    public Image red_cross1;
    public Image red_cross2;
    public Image red_cross3;
    /*public Image red_cross4;
    public TMP_Dropdown image1_dd;
    public TMP_Dropdown image2_dd;
    public TMP_Dropdown image3_dd;
    public TMP_Dropdown image4_dd;*/

    private int count;
    private DateTime tiempo1 = DateTime.Now, tiempo2;

    public bool allowed;
    public bool im1, im2, im3, im4;

    public string value;
    public bool pressed;
    public bool start_timer;
    public string text_result;
    public float stop;

    [SerializeField] TextMeshProUGUI timer_text;
    public float remaining_time;

    public void Start()
    {
        count = 1;
        value = "";
        pressed = false;
        start_timer = false;
        text_result = "";
        nextTest();
        //allowed = false;
        //im1 = false; im2 = false; im3 = false; im4 = false;
    }


    void Update()
    {
        int minutes = 0;
        int seconds = 0;

       


        if (count > 6)
        {
            /*image1.gameObject.SetActive(false);
            image2.gameObject.SetActive(false);
            image3.gameObject.SetActive(false);
            image4.gameObject.SetActive(false);
            red_cross4.gameObject.SetActive(false);
            image1_dd.gameObject.SetActive(false);
            image2_dd.gameObject.SetActive(false);
            image3_dd.gameObject.SetActive(false);
            image4_dd.gameObject.SetActive(false);*/
            img1.gameObject.SetActive(false);
            img2.gameObject.SetActive(false);
            img3.gameObject.SetActive(false);
            red_cross1.gameObject.SetActive(false);
            red_cross2.gameObject.SetActive(false);
            red_cross3.gameObject.SetActive(false);
            finish_btn_caras.gameObject.SetActive(true);
        }
        else if (count <= 6)
        {   //cuando acabe el tiempo poner los botones interactables
            //el usuario pulsa un boton y se reseta el contador
            if (start_timer == true)
            {
                remaining_time -= Time.deltaTime;
                minutes = Mathf.FloorToInt(remaining_time / 60);
                seconds = Mathf.FloorToInt(remaining_time % 60);
                timer_text.text = string.Format("{0:00}:{1:00}", minutes, seconds);

                if (pressed == false && minutes == 0 && seconds == 0)
                {
                    start_timer = false;
                    text_result = "Sin elegir";
                    nextTest();
                }

            }


            if (pressed == true)
            {
                //seconds = 0;
                //start_timer = false;
                start_timer = false;
                minutes = Mathf.FloorToInt(stop / 60);
                seconds = Mathf.FloorToInt(stop % 60);
                timer_text.text = string.Format("{0:00}:{1:00}", minutes, seconds);
                text_result = value;
                nextTest();
            }
                    
            
            
            

            /*checkAllowed();
            if (allowed == true)
            {
                if (Time.time >= nextTime)
                {
                    nextTime += intervalo;
                    seg -= 1;
                }

                if (seg < 0)
                {
                    seg = 0;
                }

                if (seg == 0 && min >= 1)
                {
                    min -= 1;
                    seg = 60;
                }

                if (min == 0 && seg == 0)
                {
                    nextTest();
                    allowed = false;
                    seg = 15;
                    nextTime = 0;
                }
            }*/
        }
    }

    /*public void checkAllowed()
    {
        if (im1 == true && im2 == true && im3 == true && im4 == true){
            allowed = true;
        } else
        {
            allowed = false;
        }
    }*/

    /*public void selectColors()
    {
        image1_dd.onValueChanged.AddListener(delegate
        {
            im1 = true;
            if (image1_dd.value == 1)
            {
                red_cross1.transform.position = new Vector3(375, 300, 0);
                red_cross1.gameObject.SetActive(true);
            }
            else if (image1_dd.value == 2)
            {
                red_cross1.transform.position = new Vector3(475, 300, 0);
                red_cross1.gameObject.SetActive(true);
            }
            else if (image1_dd.value == 3)
            {
                red_cross1.transform.position = new Vector3(575, 300, 0);
                red_cross1.gameObject.SetActive(true);
            }
        });

        image2_dd.onValueChanged.AddListener(delegate
        {
            im2 = true;
            if (image2_dd.value == 1)
            {
                red_cross2.transform.position = new Vector3(730, 300, 0);
                red_cross2.gameObject.SetActive(true);
            }
            else if (image2_dd.value == 2)
            {
                red_cross2.transform.position = new Vector3(830, 300, 0);
                red_cross2.gameObject.SetActive(true);
            }
            else if (image2_dd.value == 3)
            {
                red_cross2.transform.position = new Vector3(935, 300, 0);
                red_cross2.gameObject.SetActive(true);
            }
        });

        image3_dd.onValueChanged.AddListener(delegate
        {
            im3 = true;
            if (image3_dd.value == 1)
            {
                red_cross3.transform.position = new Vector3(370, 125, 0);
                red_cross3.gameObject.SetActive(true);
            }
            else if (image3_dd.value == 2)
            {
                red_cross3.transform.position = new Vector3(475, 125, 0);
                red_cross3.gameObject.SetActive(true);
            }
            else if (image3_dd.value == 3)
            {
                red_cross3.transform.position = new Vector3(575, 125, 0);
                red_cross3.gameObject.SetActive(true);
            }
        });

        image4_dd.onValueChanged.AddListener(delegate
        {
            im4 = true;
            if (image4_dd.value == 1)
            {
                red_cross4.transform.position = new Vector3(730, 125, 0);
                red_cross4.gameObject.SetActive(true);
            }
            else if (image4_dd.value == 2)
            {
                red_cross4.transform.position = new Vector3(830, 125, 0);
                red_cross4.gameObject.SetActive(true);
            }
            else if (image4_dd.value == 3)
            {
                red_cross4.transform.position = new Vector3(930, 125, 0);
                red_cross4.gameObject.SetActive(true);
            }
        });
    }*/

    public void finishStroop()
    {
        show_cards show = GameObject.Find("Cards").GetComponent<show_cards>();
        if (show != null)
        {
            show.show_reason_card();
        }

        Player player = GameObject.Find("Player").GetComponent<Player>();
        if (player != null)
        {
            player._doingTest = false;
        }
        Destroy(this.gameObject);

        UI_Manager ui_manager = GameObject.Find("Inventry").GetComponent<UI_Manager>();
        if (ui_manager != null)
        {
            ui_manager.reasonCollected();
        }
        Destroy(this.gameObject);

        tiempo2 = DateTime.Now;
        string path = "C:/Users/sandr.LAPTOP-GVVQRNIB/Documents/GitHub/TFG_SandraCiudad/Assets/Results/Caras/Time.txt";
        string text = (tiempo2 - tiempo1).Hours + " horas " + (tiempo2 - tiempo1).Minutes + " minutos " + (tiempo2 - tiempo1).Seconds + " segundos";
        File.AppendAllLines(path, new String[] { text });

        _canvasCaras.SetActive(false);
    }

    public void defaultValues()
    {
        red_cross1.gameObject.SetActive(false);
        red_cross2.gameObject.SetActive(false);
        red_cross3.gameObject.SetActive(false);
        pressed = false;
        remaining_time = 10;
        start_timer = true;
        /*red_cross4.gameObject.SetActive(false);
        image1_dd.value = 0; image2_dd.value = 0; image3_dd.value = 0; image4_dd.value = 0;*/
    }


    public void saveTestsResults()
    {
        string path = "C:/Users/sandr.LAPTOP-GVVQRNIB/Documents/GitHub/TFG_SandraCiudad/Assets/Results/Caras/Results.txt";
        if (count > 0)
        {
            //string text = image1_dd.value + ", " + image2_dd.value + ", " + image3_dd.value + ", " + image4_dd.value;
            File.AppendAllLines(path, new String[] { text_result });
        }
    }

    public void UpdateProgress()
    {
        float amount = (float)count / 10;
        bar_fill.fillAmount = amount;
    }

    /*public void testOptions()
    {
        if (count == 1) 
        {
            image1.sprite = test_caras11;
            image2.sprite = test_caras12;
            image3.sprite = test_caras13;
            image4.sprite = test_caras14;
        }
        else if (count == 2)
        {
            image1.sprite = test_caras21;
            image2.sprite = test_caras22;
            image3.sprite = test_caras23;
            image4.sprite = test_caras24;
        }
        else if (count == 3)
        {
            image1.sprite = test_caras31;
            image2.sprite = test_caras32;
            image3.sprite = test_caras33;
            image4.sprite = test_caras34;
        }
        else if (count == 4)
        {
            image1.sprite = test_caras41;
            image2.sprite = test_caras42;
            image3.sprite = test_caras43;
            image4.sprite = test_caras44;
        }
        else if (count == 5)
        {
            image1.sprite = test_caras51;
            image2.sprite = test_caras52;
            image3.sprite = test_caras53;
            image4.sprite = test_caras54;
        }
        else if (count == 6)
        {
            image1.sprite = test_caras61;
            image2.sprite = test_caras62;
            image3.sprite = test_caras63;
            image4.sprite = test_caras64;
        }
        else if (count == 7)
        {
            image1.sprite = test_caras71;
            image2.sprite = test_caras72;
            image3.sprite = test_caras73;
            image4.sprite = test_caras74;
        }
        else if (count == 8)
        {
            image1.sprite = test_caras81;
            image2.sprite = test_caras82;
            image3.sprite = test_caras83;
            image4.sprite = test_caras84;
        }
        else if (count == 9)
        {
            image1.sprite = test_caras91;
            image2.sprite = test_caras92;
            image3.sprite = test_caras93;
            image4.sprite = test_caras94;

        }
        else if (count == 10)
        {
            image1.sprite = test_caras101;
            image2.sprite = test_caras102;
            image3.sprite = test_caras103;
            image4.sprite = test_caras104;

        }
    }*/

    public void firstClicked()
    {
        red_cross1.gameObject.SetActive(true);
        pressed = true;
        start_timer = false;
        value = "Izquierda";
        stop = Time.time;
    }

    public void secondClicked()
    {
        red_cross2.gameObject.SetActive(true);
        pressed = true;
        start_timer = false;
        value = "Centro";
        stop = Time.time;
    }

    public void thirdClicked()
    {
        red_cross3.gameObject.SetActive(true);
        pressed = true;
        start_timer = false;
        value = "Derecha";
        stop = Time.time;
    }


    public void testOptions()
    {
        if (count == 1)
        {
            img1.image.sprite = caras11;
            img2.image.sprite = caras12;
            img3.image.sprite = caras13;

        } else if (count == 2)
        {
            img1.image.sprite = caras21;
            img2.image.sprite = caras22;
            img3.image.sprite = caras23;
        } else if (count == 3)
        {
            img1.image.sprite = caras31;
            img2.image.sprite = caras32;
            img3.image.sprite = caras33;
        } else if (count == 4)
        {
            img1.image.sprite = caras41;
            img2.image.sprite = caras42;
            img3.image.sprite = caras43;
        } else if (count == 5)
        {
            img1.image.sprite = caras51;
            img2.image.sprite = caras52;
            img3.image.sprite = caras53;
        } else if (count == 6)
        {
            img1.image.sprite = caras61;
            img2.image.sprite = caras62;
            img3.image.sprite = caras63;
        }


    }


    public void nextTest()
    {
        saveTestsResults();
        UpdateProgress();
        count = count + 1;
        defaultValues();
        testOptions();
        //selectColors();
    }


}
