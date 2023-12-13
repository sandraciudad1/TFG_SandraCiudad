using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookY : MonoBehaviour
{
    [SerializeField]
    private float _sensitivity = 1.0f;

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
            if(player._isPressed == true && player._doingTest == false)
            {
                

                if ((transform.localEulerAngles.x >= 0 && transform.localEulerAngles.x <= 90) || (transform.localEulerAngles.x >= 330 && transform.localEulerAngles.x <= 360))
                {
                    float xRotation = transform.localEulerAngles.x - (Input.GetAxis("Mouse Y") * _sensitivity);
                    Vector3 rotation = new Vector3(xRotation, transform.localEulerAngles.y, transform.localEulerAngles.z);
                    transform.localEulerAngles = rotation;
                }
                else if(transform.localEulerAngles.x > 90 && transform.localEulerAngles.x <= 180)
                {
                    Vector3 rotation = new Vector3(90, transform.localEulerAngles.y, transform.localEulerAngles.z);
                    transform.localEulerAngles = rotation;
                } else if (transform.localEulerAngles.x > 180 && transform.localEulerAngles.x < 330)
                {
                    Vector3 rotation = new Vector3(330, transform.localEulerAngles.y, transform.localEulerAngles.z);
                    transform.localEulerAngles = rotation;
                }
                

            }
            else 
            {
                Vector3 rotation = new Vector3(0, 0, 0);
                transform.localEulerAngles = rotation;
            }
        }


        
    }
}
