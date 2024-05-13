using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using System;
using System.Threading;

public class Nback_test : MonoBehaviour
{
    [SerializeField]
    public GameObject _canvasNback;
    [SerializeField]
    private Button finish_btn_nback;
    [SerializeField]
    private Image bar_fill;
    [SerializeField]
    public GameObject progressBar;

    [SerializeField]
    private Sprite one;
    [SerializeField]
    private Sprite two;
    [SerializeField]
    private Sprite three;
    [SerializeField]
    private Sprite four;
    [SerializeField]
    private Sprite five;
    [SerializeField]
    private Sprite six;
    [SerializeField]
    private Sprite seven;
    [SerializeField]
    private Sprite eight;
    [SerializeField]
    private Sprite nine;

    [SerializeField]
    private Button card;

    public DateTime tiempo1, tiempo2;

    public string month;
    public string day;
    public string year;
    public string hour;
    public string _min;

    private int count;
    public string text_result;
    public bool pressed;
    public string value;
    public bool can_start;

    [SerializeField] TextMeshProUGUI timer_text;
    public float remaining_time;
    private int minutes;
    private int seconds;

    public bool finish_test;
    public bool _hasFinished;
    public bool time;

    public bool _canStart;
    public string actual_date;

    // Start is called before the first frame update
    void Start()
    {
        _canStart = false;
        count = 0;
        pressed = false;
        can_start = false;
        finish_test = false;
        _hasFinished = false;
        time = false;
    }

    public void canStart()
    {
        tiempo1 = DateTime.Now;
        month = DateTime.Now.ToString("MM");
        day = DateTime.Now.ToString("dd");
        year = DateTime.Now.ToString("yyyy");
        hour = DateTime.Now.ToString("HH");
        _min = DateTime.Now.ToString("mm");
        actual_date = day + "_" + month + "_" + year + "__" + hour + "_" + _min;
        _canStart = true;
        nextTest();
    }

    // Update is called once per frame
    void Update()
    {

        animationController_nback anim = GameObject.Find("CardFan_Hearts_").GetComponent<animationController_nback>();
        if (anim != null && anim.finish_nback_test == true && _hasFinished == false)
        {

            showCard_finish();
            _hasFinished = true;
        }

        if (count > 20 && time == false)
        {
            card.gameObject.SetActive(false);
            finish_btn_nback.gameObject.SetActive(true);
            timer_text.gameObject.SetActive(false);
            progressBar.SetActive(false);
            saveTimeResults();
            time = true;
        }
        else if (count <= 20 && _canStart == true)
        {
            remaining_time = Math.Abs(remaining_time);
            float timer = Math.Abs(Time.deltaTime);
            remaining_time -= timer;

            minutes = Mathf.FloorToInt(remaining_time / 60);
            seconds = Mathf.FloorToInt(remaining_time % 60);
            minutes = Math.Abs(minutes);
            seconds = Math.Abs(seconds);
            timer_text.text = string.Format("{0:00}:{1:00}", minutes, seconds);


            if (minutes == 0 && seconds == 0 && count > 0)
            {
                saveTestsResults();
            }

        }
    }

    IEnumerator wait_initial_pos()
    {
        yield return new WaitForSeconds(1.2f);
    }

    public void finishNback()
    {
        _canvasNback.SetActive(false);
        animationController_nback anim = GameObject.Find("CardFan_Hearts_").GetComponent<animationController_nback>();
        if (anim != null)
        {
            anim.cardFan_init = true;
        }
    }

    public void showCard_finish()
    {
        StartCoroutine(wait_initial_pos());
        show_cards show = GameObject.Find("Cards").GetComponent<show_cards>();
        if (show != null)
        {
            show.show_place_card();
        }


        Player player = GameObject.Find("Player").GetComponent<Player>();
        if (player != null)
        {
            player._doingTest = false;
        }

        UI_Manager ui_manager = GameObject.Find("Inventry").GetComponent<UI_Manager>();
        if (ui_manager != null)
        {
            ui_manager.placeCollected();
        }



    }

    public void button_pressed()
    {
        pressed = true;
        card.interactable = false;
    }

    public void checkFailure()
    {
        if (count == 4 || count == 10 || count == 15 || count == 17 || count == 18)
        {
            value = "ACIERTO.";
        }
        else
        {
            value = "ERROR.";
        }
    }

    public void saveTimeResults()
    {
        tiempo2 = DateTime.Now;
        string path = "C:/Users/sandr.LAPTOP-GVVQRNIB/Documents/GitHub/TFG_SandraCiudad/Assets/Results/Nback/Time_" + actual_date + ".txt";
        string text = (tiempo2 - tiempo1).Hours + " horas " + (tiempo2 - tiempo1).Minutes + " minutos " + (tiempo2 - tiempo1).Seconds + " segundos";

        File.AppendAllLines(path, new String[] { text });
    }

    public void saveTestsResults()
    {
        if (count > 0)
        {
            checkFailure();
            string path = "C:/Users/sandr.LAPTOP-GVVQRNIB/Documents/GitHub/TFG_SandraCiudad/Assets/Results/Nback/Results_" + actual_date + ".txt";
            if (card.interactable == false)
            {
                text_result = "La carta " + count + " ha sido presionada. " + value;
            }
            else if (card.interactable == true)
            {
                text_result = "La carta " + count + " no ha sido presionada. " + value;
            }


            File.AppendAllLines(path, new String[] { text_result });
            nextTest();
        }



    }

    public void UpdateProgress()
    {
        float amount = (float)count / 20;
        bar_fill.fillAmount = amount;
    }


    public void testOptions()
    {
        if (count == 1) { card.image.sprite = four; }
        else if (count == 2) { card.image.sprite = nine; }
        else if (count == 3) { card.image.sprite = five; }
        else if (count == 4) { card.image.sprite = nine; }
        else if (count == 5) { card.image.sprite = one; }
        else if (count == 6) { card.image.sprite = five; }
        else if (count == 7) { card.image.sprite = five; }
        else if (count == 8) { card.image.sprite = two; }
        else if (count == 9) { card.image.sprite = one; }
        else if (count == 10) { card.image.sprite = two; }
        else if (count == 11) { card.image.sprite = three; }
        else if (count == 12) { card.image.sprite = seven; }
        else if (count == 13) { card.image.sprite = eight; }
        else if (count == 14) { card.image.sprite = eight; }
        else if (count == 15) { card.image.sprite = eight; }
        else if (count == 16) { card.image.sprite = six; }
        else if (count == 17) { card.image.sprite = eight; }
        else if (count == 18) { card.image.sprite = six; }
        else if (count == 19) { card.image.sprite = three; }
        else if (count == 20) { card.image.sprite = four; }
    }

    public void defaultValues()
    {
        card.gameObject.SetActive(true);
        timer_text.gameObject.SetActive(true);
        progressBar.gameObject.SetActive(true);
        card.interactable = true;
        pressed = false;
        remaining_time = 6;
        value = "";
    }

    public void nextTest()
    {
        Debug.Log("count antes de actualizar " + count);
        UpdateProgress();
        defaultValues();
        count += 1;
        Debug.Log("count despues de actualizar " + count);
        testOptions();
    }
}

