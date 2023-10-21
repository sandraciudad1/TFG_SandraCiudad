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


    public void showInfo()
    {
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

    public void XavierInfo()
    {
        _buttonsCharacters.SetActive(false);
        _info.SetActive(true);
        name.text = "Xavier";
        relation.text = "Marido de la víctima";
        relation.color = Color.black;
        description.text = "Xavier es un licenciado en negocios y finanzas que trabaja en una gran empresa con prestigio a nivel " +
                            "internacional. Sus grandes logros empresariales le han permitido generar grandes ingresos. " +
                            "\n\n Es una persona muy influyente y está involucrado en organizaciones benéficas. Es conocido por " +
                            "ser muy solidario y le encanta pasar tiempo en familia. En su tiempo libre juega al golf y colecciona " +
                            "botellas de vino de todo el mundo.";
        image.sprite = Xavier;
    }

    public void BiancaInfo()
    {
        _buttonsCharacters.SetActive(false);
        _info.SetActive(true);
        name.text = "Bianca";
        relation.text = "Víctima";
        relation.color = Color.red;
        description.text = "Bianca es una apasionada de la medicina y la ciencia, por lo que se especializó en cardiología. " +
                            "Recientemente, se ha convertido en una de las cardiólogas más respetadas y admiradas de este pais " +
                            "por sus numerosos descubrimientos. " +
                            "\n\n Es una persona muy extrovertida y le encanta pasar tiempo con sus amigos. En su tiempo libre, " +
                            "participa en debates políticos, por lo que tiene una amplia red de contactos.";
        image.sprite = Bianca;
    }

    public void GiovanniInfo()
    {
        _buttonsCharacters.SetActive(false);
        _info.SetActive(true);
        name.text = "Giovanni";
        relation.text = "Hijo de la víctima";
        relation.color = Color.black;
        description.text = "Giovanni es el hijo mayor de Xavier y Bianca. Es una persona con grandes aspiraciones, y sus dos pasiones " +
                            "son el arte y la moda. Actualmente trabaja en una conocida galería de arte mientras presenta su propia " +
                            "colección de moda en pasarelas de todo el mundo." +
                            "\n\n Se caracteriza por ser una persona muy aventurera, por lo que en su tiempo libre le encanta viajar a " +
                            "la naturaleza y hacer deportes de riesgo.";
        image.sprite = Giovanni;
    }

    public void EmmaInfo()
    {
        _buttonsCharacters.SetActive(false);
        _info.SetActive(true);
        name.text = "Emma";
        relation.text = "Hija de la víctima";
        relation.color = Color.black;
        description.text = "Emma es la hija pequeña de Xavier y Bianca. Desde muy pequeña ha mostrado un alto nivel de inteligencia, " +
                            "destacando en áreas como las matemáticas o la música. Es una persona muy analítica y perfeccionista, por lo que " +
                            "cree que ha nacido para ser criminóloga." +
                            "\n\n Tiene un carácter muy introvertido, y no le gusta mucho establecer relaciones con los demás. Dedica todo su " +
                            "tiempo libre a aprender cosas nuevas y ver series de crimen y misterio.";
        image.sprite = Emma;
    }

    public void GertrudInfo()
    {
        _buttonsCharacters.SetActive(false);
        _info.SetActive(true);
        name.text = "Gertrud";
        relation.text = "Limpiadora de la víctima";
        relation.color = Color.black;
        description.text = "Gertrud es una señora de avanzada edad, que durante toda su vida ha trabajado en la mansión de los Walton como " +
                            "encargada de la limpieza y el mantenimiento del hogar." +
                            "\n\n Es una persona muy espiritual y reservada, que se caracteriza por su gran vinculación con la iglesia. En " +
                            "su tiempo libre participa en actividades religiosas y grupos de oración, además de cuidar de sus numerosas mascotas.";
        image.sprite = Gertrud;
    }

    public void GustavoInfo()
    {
        _buttonsCharacters.SetActive(false);
        _info.SetActive(true);
        name.text = "Gustavo";
        relation.text = "Cocinero de la víctima";
        relation.color = Color.black;
        description.text = "Gustavo es un hombre de familia humilde que trabaja desde hace 15 años en la mansión de los Walton como cocinero. " +
                            "Los largos turnos de trabajo lo obligan a hospedarse allí, por lo que tiene una muy buena relación con la familia, " +
                            "especialmente con Emma y Giovanni, que los considera hijos." +
                            "\n\n Es un apasionado de las colecciones, por lo que se dedica a coleccionar todo tipo de cosas, desde monedas y " +
                            "sellos hasta animales disecados.";
        image.sprite = Gustavo;
    }

    public void AlessandroInfo()
    {
        _buttonsCharacters.SetActive(false);
        _info.SetActive(true);
        name.text = "Alessandro";
        relation.text = "Vigilante de la víctima";
        relation.color = Color.black;
        description.text = "Alessandro es un jóven de 27 años que ha trabajado toda su vida como portero en distintas discotecas, aunque " +
                            "recientemente ha sido contratado por la familia Walton para supervisar y mantener la seguridad en la mansión." +
                            "\n\n Mantiene una relación amorosa con Giovanni desde hace 2 años, aunque Xavier y Emma no son capaces de aceptarla. " +
                            "En su tiempo libre, le apasiona escuchar música clásica y hacer deporte.";
        image.sprite = Alessandro;
    }

}
