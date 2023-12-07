using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using System;
using UnityEngine.EventSystems;

public class Anillas_test : MonoBehaviour
{
    [SerializeField]
    private GameObject _anillas_estructure;
    [SerializeField]
    private GameObject _red_ring;
    [SerializeField]
    private GameObject _orange_ring;
    [SerializeField]
    private GameObject _yellow_ring;
    [SerializeField]
    private GameObject _green_ring;
    [SerializeField]
    private GameObject _blue_ring;



    [SerializeField]
    private Image error_ring;
    [SerializeField]
    private Image error_object;
    [SerializeField]
    private Image error_out;
    [SerializeField]
    private Button ok_error_btn;
    [SerializeField]
    private Image congrats_msg;
    [SerializeField]
    private Button ok_congrats_btn;

    [SerializeField]
    private Image _final_pos_anillas;
    public TextMeshProUGUI text7;
    [SerializeField]
    private Button _unlock_info;

    public bool start;

    bool isDrag;
    Transform focus;
    Camera cam;
    Vector3 screenPos;
    Vector3 offset;
    Vector3 currentScreenPos;
    Vector3 currentPos;
    Vector3 initialPos;
    RaycastHit hit;
    Ray ray;

    float initial_x;
    float initial_y;

    Stack<string> st_left = new Stack<string>();
    Stack<string> st_mid = new Stack<string>();
    Stack<string> st_right = new Stack<string>();

    public bool _canMove;
    public int movements;
    public string pivot;
    public string previous_pivot;
    public int rings_num;
    public float x, y, z;

    public bool solved;
    public bool finish_waiting;
    public bool finish_animation;

    public string text_result;
    private DateTime tiempo1 = DateTime.Now, tiempo2;

    // Start is called before the first frame update
    void Start()
    {
        start = false;
        z = 1.254f;

        isDrag = false;
        cam = Camera.main;

        _canMove = false;
        movements = 0;
        pivot = "";
        previous_pivot = "";
        rings_num = 0;

        st_left.Push("red_ring");
        st_left.Push("orange_ring");
        st_left.Push("yellow_ring");
        st_left.Push("green_ring");
        st_left.Push("blue_ring");

        solved = false;
        finish_waiting = false;
        finish_animation = false;
    }

    public void can_Start()
    {
        start = true;
    }

    public void is_possible()
    {
        
        if (hit.transform.name == "red_ring" || hit.transform.name == "orange_ring" || hit.transform.name == "yellow_ring" || hit.transform.name == "green_ring" || hit.transform.name == "blue_ring")
        {
            initial_x = hit.collider.transform.position.x;
            initial_y = hit.collider.transform.position.y;
            if (st_left.Count > 0 && (st_left.Peek() == hit.transform.name))
            {
                st_left.Pop();
                _canMove = true;
            }
            else if (st_mid.Count > 0 && (st_mid.Peek() == hit.transform.name))
            {
                st_mid.Pop();
                _canMove = true;
            }
            else if (st_right.Count > 0 && (st_right.Peek() == hit.transform.name))
            {
                st_right.Pop();
                _canMove = true;
            }
            else
            {
                error_ring.gameObject.SetActive(true);
                ok_error_btn.gameObject.SetActive(true);
                _canMove = false;
            }
        } else
        {
            //error_object.gameObject.SetActive(true);
            //ok_error_btn.gameObject.SetActive(true);
            _canMove = false;
        }

        

    }

    public void ok_pressed()
    {
        error_ring.gameObject.SetActive(false);
        error_object.gameObject.SetActive(false);
        error_out.gameObject.SetActive(false);
        ok_error_btn.gameObject.SetActive(false);
    }


    public void check_pos()
    {
        if (focus.position.x >= 4.30f && focus.position.x <= 4.38f)
        {
            st_left.Push(hit.transform.name);
            pivot = "left";
            rings_num = st_left.Count;
        }
        else if (focus.position.x >= 4.12f && focus.position.x <= 4.20f)
        {
            st_mid.Push(hit.transform.name);
            pivot = "middle";
            rings_num = st_mid.Count;
        }
        else if (focus.position.x >= 3.96f && focus.position.x <= 4.04f)
        {
            st_right.Push(hit.transform.name);
            pivot = "right";
            rings_num = st_right.Count;
        }
        else 
        {
            //error_out.gameObject.SetActive(true);
            //ok_error_btn.gameObject.SetActive(true);
            if (initial_x >= 4.30f && initial_x <= 4.38f)
            {
                pivot = "left";
                st_left.Push(hit.transform.name);
            }
            else if (initial_x >= 4.12f && initial_x <= 4.20f)
            {
                pivot = "middle";
                st_mid.Push(hit.transform.name);
            }
            else if (initial_x >= 3.96f && initial_x <= 4.04f)
            {
                pivot = "right";
                st_right.Push(hit.transform.name);
            }
            rings_num = -1;


        }

    }

    public void correct_pos()
    {
        //checking pivot correct position (x axis)
        if (pivot == "left")
        {
            x = 4.34f;
        } 
        else if (pivot == "middle")
        {
            x = 4.16f;
        } 
        else if (pivot == "right")
        {
            x = 3.98f;
        }

        //checking rings correct position (y axis)
        if (rings_num == 1)
        {
            y = 1.18f;
        } 
        else if (rings_num == 2)
        {
            y = 1.21f;
        }
        else if (rings_num == 3)
        {
            y = 1.24f;
        } 
        else if (rings_num == 4)
        {
            y = 1.27f;
        }
        else if (rings_num == 5)
        {
            y = 1.30f;
        }
        else if (rings_num == -1)
        {
            y = initial_y;
        }
    }

    public void check_result()
    {
        string[] pila = st_right.ToArray();
        if (st_left.Count==0 && st_mid.Count==0 && st_right.Count==5)
        {
            if (pila[0]== "yellow_ring" && pila[1] == "blue_ring" && pila[2] == "orange_ring" && pila[3] == "green_ring" && pila[4] == "red_ring")
            {
                //congrats_msg.gameObject.SetActive(true);
                //ok_congrats_btn.gameObject.SetActive(true);
                
                finish_anim();
            }
        }
    }

    public void congrats_btn_clicked()
    {
        congrats_msg.gameObject.SetActive(false);
        ok_congrats_btn.gameObject.SetActive(false);
        solved = true;
    }

    public void finish_anim()
    {
        //StartCoroutine(wait());
        animationController_anillas anim = GameObject.Find("anillas_structure").GetComponent<animationController_anillas>();
        if (anim != null)
        {
            anim.return_pos = true;
            //finish_waiting = false;
        }
        _final_pos_anillas.gameObject.SetActive(false);
        StartCoroutine(wait_anim());

        //poner enhorabuena y un boton para revelar info
        //cuando el botoon se pulse show card
    }

    IEnumerator wait_anim()
    {
        yield return new WaitForSeconds(2.0f);
        //finish_animation = true;
        //text7.gameObject.SetActive(true);
        _unlock_info.gameObject.SetActive(true);
    }

    public void unlock_btn_click()
    {
        _unlock_info.gameObject.SetActive(false);
        show_cards show = GameObject.Find("Cards").GetComponent<show_cards>();
        if (show != null)
        {
            show.show_extra_card();
        }

        Player player = GameObject.Find("Player").GetComponent<Player>();
        if (player != null)
        {
            player._doingTest = false;
        }

        UI_Manager ui_manager = GameObject.Find("Inventry").GetComponent<UI_Manager>();
        if (ui_manager != null)
        {
            ui_manager.extraCollected();
        }

        tiempo2 = DateTime.Now;
        string path = "C:/Users/sandr.LAPTOP-GVVQRNIB/Documents/GitHub/TFG_SandraCiudad/Assets/Results/Anillas/Time.txt";
        string text = (tiempo2 - tiempo1).Hours + " horas " + (tiempo2 - tiempo1).Minutes + " minutos " + (tiempo2 - tiempo1).Seconds + " segundos";
        File.AppendAllLines(path, new String[] { text });
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && start==true)
        {
            ray = (cam.ScreenPointToRay(Input.mousePosition));
            if (Physics.Raycast(ray.origin, ray.direction, out hit))
            {
                focus = hit.collider.transform;
                //initialPos = focus.position;
                
                is_possible();
                if (_canMove == true)
                {
                    movements += 1;
                    screenPos = cam.WorldToScreenPoint(focus.position);
                    offset = focus.position - cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPos.z));
                    isDrag = true;
                }
            }
        }
        else if (Input.GetMouseButtonUp(0) && isDrag == true)
        {
            check_pos();
            correct_pos();
            focus.position = new Vector3(x, y, z);
            saveTestsResults();
            check_result();
            isDrag = false;
        }
        else if (isDrag == true)
        {
            currentScreenPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPos.z);
            currentPos = cam.ScreenToWorldPoint(currentScreenPos) + offset;

            focus.position = currentPos;
        }

    }

    public void saveTestsResults()
    {
        string[] res_right = st_right.ToArray();
        string result_right = string.Join(",", res_right);
        string[] res_middle = st_mid.ToArray();
        string result_middle = string.Join(",", res_middle);
        string[] res_left = st_left.ToArray();
        string result_left = string.Join(",", res_left);

        string path = "C:/Users/sandr.LAPTOP-GVVQRNIB/Documents/GitHub/TFG_SandraCiudad/Assets/Results/Anillas/Results.txt";
        text_result = "Movimiento " + movements + "\n\t Eje izquierdo: " + result_left + "\n\t Eje central: " + result_middle + "\n\t Eje derecho: " + result_right + "\n";
        Debug.Log("Movimiento " + movements);
        Debug.Log("\n\t Eje izquierdo: " + result_left);
        Debug.Log("\n\t Eje central: " + result_middle);
        Debug.Log("Eje derecho: " + result_right + "\n");
        File.AppendAllLines(path, new String[] { text_result });
    }


}
