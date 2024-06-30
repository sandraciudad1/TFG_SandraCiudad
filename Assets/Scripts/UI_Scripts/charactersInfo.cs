using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using System;

public class charactersInfo : MonoBehaviour
{
    [SerializeField]
    private GameObject _background;
    [SerializeField]
    private GameObject _buttonsCharacters;
    [SerializeField]
    private GameObject _info;
    [SerializeField]
    private Sprite Xavier;
    [SerializeField]
    private Sprite Bianca;
    [SerializeField]
    private Sprite Giovanni;
    [SerializeField]
    private Sprite Emma;
    [SerializeField]
    private Sprite Gertrud;
    [SerializeField]
    private Sprite Gustavo;
    [SerializeField]
    private Sprite Alessandro;

    [SerializeField]
    private GameObject msg_canvas;
    [SerializeField]
    private GameObject error_window;
    [SerializeField]
    private GameObject error_test;
    [SerializeField]
    private Button ok_errorMsg_btn;

    public TextMeshProUGUI name;
    public TextMeshProUGUI relation;
    public TextMeshProUGUI description;

    public Image image;

    [SerializeField] private Button soundXavier;
    [SerializeField] private Button soundBianca;
    [SerializeField] private Button soundGiovanni;
    [SerializeField] private Button soundEmma;
    [SerializeField] private Button soundGertrud;
    [SerializeField] private Button soundGustavo;
    [SerializeField] private Button soundAlessandro;

    public AudioSource audioSource;
    public AudioClip audXavier;
    public AudioClip audBianca;
    public AudioClip audGiovanni;
    public AudioClip audEmma;
    public AudioClip audGertrud;
    public AudioClip audGustavo;
    public AudioClip audAlessandro;

    public int chatBtnCounter = 0;

    public void showInfo()
    {
        Solve solve = GameObject.Find("Solve").GetComponent<Solve>();
        if (solve != null)
        {
            solve.characters_counter += 1;
        }

        Player player = GameObject.Find("Player").GetComponent<Player>();
        if (player != null)
        {
            if (player._isPressed == false)
            {
                msg_canvas.SetActive(true);
                error_window.SetActive(true);
                ok_errorMsg_btn.gameObject.SetActive(true);
            } 
            else if (player._doingTest == true)
            {
                msg_canvas.SetActive(true);
                error_test.SetActive(true);
                ok_errorMsg_btn.gameObject.SetActive(true);
            } 
            else
            {
                _background.SetActive(true);
                _buttonsCharacters.SetActive(true);
                player._isPressed = false;
            }
            

        }
        
    }

    public void errorMsg_btn_click()
    {
        msg_canvas.SetActive(false);
        error_window.SetActive(false);
        error_test.SetActive(false);
        ok_errorMsg_btn.gameObject.SetActive(false);
    }


    public void close_btn_info()
    {
        _info.SetActive(false);
        _buttonsCharacters.SetActive(true);
    }

    public void close_btn_char()
    {
        _buttonsCharacters.SetActive(false);
        _background.SetActive(false);
        Player player = GameObject.Find("Player").GetComponent<Player>();
        if (player != null)
        {
            player._isPressed = true;
        }
    }

    public void resetSoundButtons()
    {
        soundXavier.gameObject.SetActive(false);
        soundBianca.gameObject.SetActive(false);
        soundGiovanni.gameObject.SetActive(false);
        soundEmma.gameObject.SetActive(false);
        soundGertrud.gameObject.SetActive(false);
        soundGustavo.gameObject.SetActive(false);
        soundAlessandro.gameObject.SetActive(false);
    }

    public void XavierInfo()
    {
        Solve solve = GameObject.Find("Solve").GetComponent<Solve>();
        if (solve != null)
        {
            solve.Xavier_counter += 1;
        }
        _buttonsCharacters.SetActive(false);
        resetSoundButtons();
        soundXavier.gameObject.SetActive(true);
        _info.SetActive(true);
        name.text = "Xavier";
        relation.text = "Marido de la v�ctima";
        relation.color = Color.black;
        description.text = "Xavier es licenciado en negocios y finanzas y trabaja en una gran empresa con prestigio a nivel " +
                            "internacional. Sus logros empresariales le obligan a viajar constantemente, por lo que apenas pasa" +
                            "tiempo con su familia, lo que le ocasiona m�s de un problema familiar, especialmente con Bianca. " +
                            "\n\n Es una persona a la que le encanta pasar tiempo en familia, aunque en su escaso tiempo libre " +
                            "es cortador de jam�n y colecciona botellas de vino de todo el mundo en su bodega.";
        image.sprite = Xavier;
    }

    public void BiancaInfo()
    {
        Solve solve = GameObject.Find("Solve").GetComponent<Solve>();
        if (solve != null)
        {
            solve.Bianca_counter += 1;
        }
        _buttonsCharacters.SetActive(false);
        resetSoundButtons();
        soundBianca.gameObject.SetActive(true);
        _info.SetActive(true);
        name.text = "Bianca";
        relation.text = "V�ctima";
        relation.color = Color.red;
        description.text = "Bianca es una apasionada de la medicina y la ciencia, por lo que se especializ� en cardiolog�a. " +
                            "Recientemente, se ha convertido en una de las cardi�logas m�s respetadas y admiradas de este pais " +
                            "por sus numerosos descubrimientos. " +
                            "\n\n Es una persona muy extrovertida y le encanta pasar tiempo con sus amigos. En su tiempo libre, " +
                            "participa en debates pol�ticos, por lo que tiene una amplia red de contactos.";
        image.sprite = Bianca;
    }

    public void GiovanniInfo()
    {
        Solve solve = GameObject.Find("Solve").GetComponent<Solve>();
        if (solve != null)
        {
            solve.Giovanni_counter += 1;
        }
        _buttonsCharacters.SetActive(false);
        resetSoundButtons();
        soundGiovanni.gameObject.SetActive(true);
        _info.SetActive(true);
        name.text = "Giovanni";
        relation.text = "Hijo de la v�ctima";
        relation.color = Color.black;
        description.text = "Giovanni es el hijo mayor de Xavier y Bianca. Es una persona con grandes aspiraciones, y sus dos pasiones " +
                            "son el arte y la moda. Actualmente trabaja en una conocida galer�a de arte mientras presenta su propia " +
                            "colecci�n de moda en pasarelas de todo el mundo." +
                            "\n\n Se caracteriza por ser una persona muy aventurera, por lo que en su tiempo libre le encanta explorar " +
                            "la naturaleza y hacer acampadas." +
                            "La relaci�n que mantiene con sus padres no es muy buena, ya que no aceptan su relaci�n amorosa.";
        image.sprite = Giovanni;
    }

    public void EmmaInfo()
    {
        Solve solve = GameObject.Find("Solve").GetComponent<Solve>();
        if (solve != null)
        {
            solve.Emma_counter += 1;
        }
        _buttonsCharacters.SetActive(false);
        resetSoundButtons();
        soundEmma.gameObject.SetActive(true);
        _info.SetActive(true);
        name.text = "Emma";
        relation.text = "Hija de la v�ctima";
        relation.color = Color.black;
        description.text = "Emma es la hija peque�a de Xavier y Bianca. Desde muy peque�a ha mostrado un alto nivel de inteligencia, " +
                            "destacando en �reas como las matem�ticas o la m�sica. Es una persona muy descuidada, sobre todo en lo relacionado " +
                            "con los estudios, lo que ocasiona alguna que otra discusi�n con sus padres." +
                            "\n\n Tiene un car�cter extrovertido y, en ocasiones, un poco violento. Dedica todo su tiempo libre a salir con " +
                            "sus amigas y a las redes sociales.";
        image.sprite = Emma;
    }

    public void GertrudInfo()
    {
        Solve solve = GameObject.Find("Solve").GetComponent<Solve>();
        if (solve != null)
        {
            solve.Gertrud_counter += 1;
        }
        _buttonsCharacters.SetActive(false);
        resetSoundButtons();
        soundGertrud.gameObject.SetActive(true);
        _info.SetActive(true);
        name.text = "Gertrud";
        relation.text = "Personal de limpieza";
        relation.color = Color.black;
        description.text = "Gertrud es una se�ora de avanzada edad, que durante toda su vida ha trabajado en la mansi�n de los Walton como " +
                            "encargada de la limpieza y en ocasiones ayudante de cocina." +
                            "\n\n Es una persona muy espiritual y reservada, que se caracteriza por su gran vinculaci�n con la iglesia. En " +
                            "su tiempo libre participa en actividades religiosas y grupos de oraci�n, adem�s de cuidar de sus numerosas mascotas.";
        image.sprite = Gertrud;
    }

    public void GustavoInfo()
    {
        Solve solve = GameObject.Find("Solve").GetComponent<Solve>();
        if (solve != null)
        {
            solve.Gustavo_counter += 1;
        }
        _buttonsCharacters.SetActive(false);
        resetSoundButtons();
        soundGustavo.gameObject.SetActive(true);
        _info.SetActive(true);
        name.text = "Gustavo";
        relation.text = "Cocinero";
        relation.color = Color.black;
        description.text = "Gustavo es un hombre de familia humilde que trabaja desde hace 15 a�os en la mansi�n de los Walton como cocinero. " +
                            "Los largos turnos de trabajo lo obligan a hospedarse all�, por lo que tiene una muy buena relaci�n con la familia, " +
                            "especialmente con Emma y Giovanni, que los considera hijos." +
                            "\n\n Es un apasionado de las colecciones, por lo que se dedica a coleccionar todo tipo de cosas.";
        image.sprite = Gustavo;
    }

    public void AlessandroInfo()
    {
        Solve solve = GameObject.Find("Solve").GetComponent<Solve>();
        if (solve != null)
        {
            solve.Alessandro_counter += 1;
        }
        _buttonsCharacters.SetActive(false);
        resetSoundButtons();
        soundAlessandro.gameObject.SetActive(true);
        _info.SetActive(true);
        name.text = "Alessandro";
        relation.text = "Personal de seguridad";
        relation.color = Color.black;
        description.text = "Alessandro es un apasionado del deporte y la defensa personal. Es vigilante de seguridad y ha sido contratado" +
                            "por la familia Walton para mantener la seguridad en la mansi�n. Su misi�n es vigilar la mansi�n tanto por dentro " +
                            "como por fuera, a excepci�n de la bodega, cuya puerta debe estar siempre cerrada para conservar la temperatura" +
                            "y no estropear el vino." +
                            "\n\n Mantiene una relaci�n amorosa con Giovanni, aunque Xavier y Bianca no son capaces de aceptarla.";
        image.sprite = Alessandro;
    }

    public void soundXavierBtn()
    {
        chatBtnCounter++;
        audioSource.clip = audXavier;
        audioSource.Play();
    }

    public void soundBiancaBtn()
    {
        chatBtnCounter++;
        audioSource.clip = audBianca;
        audioSource.Play();
    }

    public void soundGiovanniBtn()
    {
        chatBtnCounter++;
        audioSource.clip = audGiovanni;
        audioSource.Play();
    }

    public void soundEmmaBtn()
    {
        chatBtnCounter++;
        audioSource.clip = audEmma;
        audioSource.Play();
    }

    public void soundGertrudBtn()
    {
        chatBtnCounter++;
        audioSource.clip = audGertrud;
        audioSource.Play();
    }

    public void soundGustavoBtn()
    {
        chatBtnCounter++;
        audioSource.clip = audGustavo;
        audioSource.Play();
    }

    public void soundAlessandroBtn()
    {
        chatBtnCounter++;
        audioSource.clip = audAlessandro;
        audioSource.Play();
    }
}
