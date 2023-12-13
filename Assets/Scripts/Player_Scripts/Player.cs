using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using System;

public class Player : MonoBehaviour
{

    private CharacterController _controler;
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _gravity;
    [SerializeField]
    private float _sensitivity;

    [SerializeField]
    public bool _hasweapon = false;
    [SerializeField]
    public bool _hasreason = false;
    [SerializeField]
    public bool _hasplace = false;
    //[SerializeField]
    //public bool _haskiller = false;
    [SerializeField]
    public bool _hasdate = false;
    [SerializeField]
    public bool _hasextra = false;

    [SerializeField]
    public bool _finishStroop = false;


    [SerializeField]
    public bool _doingTest = false;
    [SerializeField]
    public bool _isPressed = false;
    [SerializeField]
    public int _mouseCounter = 0;

    public bool _canMove;

    // Start is called before the first frame update
    void Start()
    {
        _speed = 3.5f;
        _gravity = 9.81f;
        _sensitivity = 1f;

        _controler = GetComponent<CharacterController>();

        _canMove = true;
    }

    // Update is called once per frame
    public void Update()
    {
        
        if (_isPressed == true && _doingTest == false && _canMove == true)
        {
            //_canMove = true;
            //Debug.Log("el jugador puede moverse libremente");
            //_speed = 3.5f;
            //hiddenCursor();
            movements();
            rotations();
        }

    }

    //Hides the cursor when playing
    void hiddenCursor() 
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    //Defines player movements
    void movements()  
    {
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Vector3 velocity = direction * _speed * Time.deltaTime;
        velocity.y -= _gravity;
        //Trasform local direction into global direction
        velocity = transform.transform.TransformDirection(velocity);
        _controler.Move(velocity);
    }

    //Player rotations
    void rotations() 
    {
        float yRotation = transform.localEulerAngles.y + (Input.GetAxis("Mouse X") * _sensitivity);
        Vector3 rotation = new Vector3(transform.localEulerAngles.x, yRotation, transform.localEulerAngles.z);
        transform.localEulerAngles = rotation;
    }


}
