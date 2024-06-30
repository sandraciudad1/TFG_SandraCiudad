using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookY : MonoBehaviour
{
    [SerializeField]
    private float _sensitivity = 1.0f;
    public int count;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Player player = GameObject.Find("Player").GetComponent<Player>();
        if (player != null)
        {
            if(player._isPressed == true && player._doingTest == false && player._canMove==true)
            {
                float xRotation = (transform.localEulerAngles.x - (Input.GetAxis("Mouse Y") * _sensitivity) + 360) % 360;
                if (xRotation > 180)
                {
                    xRotation -= 360;
                }
                xRotation = Mathf.Clamp(xRotation, -25, 80);
                transform.localEulerAngles = Vector3.right * xRotation;
                //xRotation = Mathf.Clamp(xRotation, -30, -30);
                //transform.localEulerAngles = new Vector3(xRotation, transform.localEulerAngles.y, transform.localEulerAngles.z);

                /*else if ((transform.localEulerAngles.x > 90 && transform.localEulerAngles.x <= 180) && count == 0)
                {
                    float xRotation = transform.localEulerAngles.x - (Input.GetAxis("Mouse Y") * _sensitivity);
                    Debug.Log("ABAJO " + xRotation);
                    Vector3 rotation = new Vector3(90, transform.localEulerAngles.y, transform.localEulerAngles.z);
                    transform.localEulerAngles = rotation;
                    count = 1;
                } else if ((transform.localEulerAngles.x > 180 && transform.localEulerAngles.x < 345) && count == 0)
                {
                    float xRotation = transform.localEulerAngles.x - (Input.GetAxis("Mouse Y") * _sensitivity);
                    Debug.Log("ARRIBA " + xRotation);
                    Vector3 rotation = new Vector3(345, transform.localEulerAngles.y, transform.localEulerAngles.z);
                    transform.localEulerAngles = rotation;
                    count = 1;
                }*/


            }
            else 
            {
                Vector3 rotation = new Vector3(0, 0, 0);
                transform.localEulerAngles = rotation;
            }
        }


        
    }
}
