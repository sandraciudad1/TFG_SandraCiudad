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
            if(player.isPressed == true)
            {
                float xRotation = transform.localEulerAngles.x - (Input.GetAxis("Mouse Y") * _sensitivity);
                Vector3 rotation = new Vector3(xRotation, transform.localEulerAngles.y, transform.localEulerAngles.z);
                transform.localEulerAngles = rotation;
            }
        }


        
    }
}
