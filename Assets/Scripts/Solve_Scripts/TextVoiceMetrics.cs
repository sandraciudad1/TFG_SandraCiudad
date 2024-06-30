using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using System;

public class TextVoiceMetrics : MonoBehaviour
{
    public string month;
    public string day;
    public string year;
    public string hour;
    public string _min;
    public string actual_date;
    private DateTime tiempo1, tiempo2;

    private int skipCounter = 0;
    private int introCounter = 0, characterCounter = 0, stroopCounter = 0, nbackCounter = 0, anillasCounter = 0, carasCounter = 0, solveCounter = 0, storyCounter = 0, totalCounter = 0;
    public string introInfo, characterInfo, stroopInfo, nbackInfo, anillasInfo, carasInfo, solveInfo, storyInfo;

    [SerializeField] GameObject Giovanni;
    public bool finish=false, save=false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            skipCounter++;
        }

        typewriterUI twUI = GameObject.Find("Introduction").GetComponent<typewriterUI>();
        if (twUI != null)
        {
            introCounter = twUI.introBtnCounter;
            if (introCounter > 5)
            {
                introCounter = 5;
            }
            introInfo = "En la INTRODUCCIÓN se ha reproducido " + introCounter.ToString() + " audio/s de un total de 5";
        }

        charactersInfo charInfo = GameObject.Find("Characters_info").GetComponent<charactersInfo>();
        if (charInfo != null)
        {
            characterCounter = charInfo.chatBtnCounter;
            if (characterCounter > 7)
            {
                characterCounter = 7;
            }
            characterInfo = "En los PERSONAJES se ha reproducido " + characterCounter.ToString() + " audio/s de un total de 7";
        }

        typewriter_stroop twStroop = GameObject.Find("pinboard").GetComponent<typewriter_stroop>();
        if (twStroop != null)
        {
            stroopCounter = twStroop.stroopBtnCounter;
            if (stroopCounter > 6)
            {
                stroopCounter = 6;
            }
            stroopInfo = "En STROOP se ha reproducido " + stroopCounter.ToString() + " audio/s de un total de 6";
        }

        typewriter_nback twNBack = GameObject.Find("card_deck").GetComponent<typewriter_nback>();
        if (twNBack != null)
        {
            nbackCounter = twNBack.cartasBtnCounter;
            if (nbackCounter > 6)
            {
                nbackCounter = 6;
            }
            nbackInfo = "En N-BACK se ha reproducido " + nbackCounter.ToString() + " audio/s de un total de 6";
        }

        typewriter_anillas twAnillas = GameObject.Find("Anillas").GetComponent<typewriter_anillas>();
        if (twAnillas != null)
        {
            anillasCounter = twAnillas.anillasBtnCounter;
            if (anillasCounter > 6)
            {
                anillasCounter = 6;
            }
            anillasInfo = "En ANILLAS se ha reproducido " + anillasCounter.ToString() + " audio/s de un total de 6";
        }

        typewriter_caras twCaras = GameObject.Find("remoteControl").GetComponent<typewriter_caras>();
        if (twCaras != null)
        {
            carasCounter = twCaras.carasBtnCounter;
            if (carasCounter > 7)
            {
                carasCounter = 7;
            }
            carasInfo = "En CARAS se ha reproducido " + carasCounter.ToString() + " audio/s de un total de 7";
        }

        typewriter_solve twSolve = GameObject.Find("Solve").GetComponent<typewriter_solve>();
        if (twSolve != null)
        {
            solveCounter = twSolve.solveBtnCounter;
            if (solveCounter > 1)
            {
                solveCounter = 1;
            }
            solveInfo = "En SOLUCION se ha reproducido " + solveCounter.ToString() + " audio/s de un total de 1";
        }

        typewriter_story twStory = GameObject.Find("story").GetComponent<typewriter_story>();
        if (twStory != null)
        {
            storyCounter = twStory.storyBtnCounter;
            if (storyCounter > 12)
            {
                storyCounter = 12;
            }
            storyInfo = "En HISTORIA se ha reproducido " + storyCounter.ToString() + " audio/s de un total de 12";
        }

        totalCounter = introCounter + characterCounter + stroopCounter + nbackCounter + anillasCounter + carasCounter + solveCounter + storyCounter;

        if (Giovanni.activeInHierarchy)
        {
            animationController_solution acSolution = GameObject.Find("Giovanni").GetComponent<animationController_solution>();
            if (acSolution!=null)
            {
                finish = acSolution.finish_game;
            }
        }

        if (finish == true && save==false)
        {
            saveResults();
            save = true;
        }
        
    }

    public void saveResults()
    {
        double porcentajeAudio = (totalCounter/50) * 100;
        double porcentajeSkip = (skipCounter/43) * 100;
        string cadenaSkip;
        if (skipCounter > 43)
        {
            cadenaSkip = "en algunos textos, la tecla S se ha pulsado más de una vez.";
        } 
        else if (skipCounter < 43)
        {
            cadenaSkip = "en algunos textos, la tecla S no se ha pulsado.";
        } 
        else
        {
            cadenaSkip = "la tecla S se ha pulsado una vez en todos los textos.";
        }
        string path_res = "C:/Users/sandr.LAPTOP-GVVQRNIB/Documents/GitHub/TFG_SandraCiudad/Assets/Results/Solution/Metrics_" + actual_date + ".txt";
        string text_result = "Este juego tiene un total de 50 textos que pueden ser escuchados, de los cuales: " +
                             "\n\n" + introInfo + "\n" + characterInfo + "\n" + stroopInfo + "\n" + nbackInfo + "\n" + anillasInfo + "\n" + carasInfo + "\n" + 
                             solveInfo + "\n" + storyInfo + "\n Por tanto, se han reproducido un total de " + totalCounter + " audios, lo que equivale a un "
                             + porcentajeAudio + "% del total." + 

                             "\n\nPor otro lado, 43 de esos 50 textos pueden ser saltados utilizando para ello la tecla S. \n El usuario ha pulsado esta tecla un " +
                             "total de " + skipCounter + " veces durante el juego, lo que significa que " + cadenaSkip + "\nEsto equivale a un " + porcentajeSkip +
                             "% del total.";
        File.AppendAllLines(path_res, new String[] { text_result });
    }
}
