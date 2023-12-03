using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Anillas_test : MonoBehaviour
{
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
    public float x, y;

    // Start is called before the first frame update
    void Start()
    {
        start = false;

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
    }

    public void can_Start()
    {
        start = true;
    }

    public void is_possible()
    {
        if (hit.transform.name == "red_ring" || hit.transform.name == "orange_ring" || hit.transform.name == "yellow_ring" || hit.transform.name == "green_ring" || hit.transform.name == "blue_ring")
        {
            if (st_left.Count > 0 && (st_left.Peek() == hit.transform.name))
            {
                //previous_pivot = "left";
                /*initial_x = focus.position.x;
                initial_y = focus.position.y -0.05f;
                Debug.Log("before movements x = " + initial_x + " and y = " + initial_y);*/
                st_left.Pop();
                _canMove = true;
            }
            else if (st_mid.Count > 0 && (st_mid.Peek() == hit.transform.name))
            {
                //previous_pivot = "mniddle";
                /*initial_x = focus.position.x;
                initial_y = focus.position.y - 0.05f;
                Debug.Log("before movements x = " + initial_x + " and y = " + initial_y);*/
                st_mid.Pop();
                _canMove = true;
            }
            else if (st_right.Count > 0 && (st_right.Peek() == hit.transform.name))
            {
                //previous_pivot = "right";
                /*initial_x = focus.position.x;
                initial_y = focus.position.y - 0.05f;
                Debug.Log("before movements x = " + initial_x + " and y = " + initial_y);*/
                st_right.Pop();
                _canMove = true;
            }
            else
            {
                Debug.Log("ERROR. ESTE DISCO CONTIENE OTROS ENCIMA.");
                _canMove = false;
            }
        } else
        {
            Debug.Log("ESTE OBJETO NO SE PUEDE MOVER. NO ES UN DISCO.");
            _canMove = false;
        }

        

    }


    public void check_pos()
    {
        if (focus.position.x >= 4.30f && focus.position.x <= 4.38f)
        {
            Debug.Log("eje izquierdo");
            st_left.Push(hit.transform.name);
            pivot = "left";
            rings_num = st_left.Count;
        }
        else if (focus.position.x >= 4.12f && focus.position.x <= 4.20f)
        {
            Debug.Log("eje central");
            st_mid.Push(hit.transform.name);
            pivot = "middle";
            rings_num = st_mid.Count;
        }
        else if (focus.position.x >= 3.96f && focus.position.x <= 4.04f)
        {
            Debug.Log("eje derecho");
            st_right.Push(hit.transform.name);
            pivot = "right";
            rings_num = st_right.Count;
        }
        else 
        {
            Debug.Log("FUERA DE LOS EJES");
            pivot = "out";
            
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
        else if (pivot == "out")
        {
            /*x = initial_x;
            y = initial_y;
            if (x >= 4.30f && x <= 4.38f)
            {
                st_left.Push(hit.transform.name);
            } 
            else if (x >= 4.12f && x <= 4.20f)
            {
                st_mid.Push(hit.transform.name);
            } 
            else if (x >= 3.96f && x <= 4.04f)
            {
                st_right.Push(hit.transform.name);
            }*/
        }

        //checking rings correct position (y axis)
        if (rings_num == 0)
        {
            y = 1.15f;
        } 
        else if (rings_num == 1)
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
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)&&  start==true)
        {
            ray = (cam.ScreenPointToRay(Input.mousePosition));
            if (Physics.Raycast(ray.origin, ray.direction, out hit))
            {
                focus = hit.collider.transform;
                //initialPos = focus.position;
                
                is_possible();
                if (_canMove == true)
                {
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
            focus.position = new Vector3(x, y, currentPos.z);
            isDrag = false;
        }
        else if (isDrag == true)
        {
            currentScreenPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPos.z);
            currentPos = cam.ScreenToWorldPoint(currentScreenPos) + offset;

            focus.position = currentPos;
            
            

        }

    }

   
}
