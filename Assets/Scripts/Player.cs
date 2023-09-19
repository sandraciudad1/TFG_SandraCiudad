using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private CharacterController _controler;
    [SerializeField]
    private float _speed = 3.5f;
    [SerializeField]
    private float _gravity = 9.81f;
    [SerializeField]
    private float _sensitivity = 0.7f;
    /*[SerializeField]
    private GameObject _muzzleFlash;
    [SerializeField]
    private GameObject _hitMarker;
    */
    // Start is called before the first frame update
    void Start()
    {
        //_muzzleFlash.SetActive(false);
        _controler = GetComponent<CharacterController>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        hiddenCursor();
        movements();
        rotations();
    }

    void hiddenCursor() //Hides the cursor when playing
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    void movements() //Player movements 
    {
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Vector3 velocity = direction * _speed * Time.deltaTime;
        velocity.y -= _gravity;
        //Trasform local direction to global direction (local and glocal references systems are now aligned).
        velocity = transform.transform.TransformDirection(velocity);
        _controler.Move(velocity);
    }

    void rotations() //Player rotations
    {
        float yRotation = transform.localEulerAngles.y + (Input.GetAxis("Mouse X") * _sensitivity);
        Vector3 rotation = new Vector3(transform.localEulerAngles.x, yRotation, transform.localEulerAngles.z);
        transform.localEulerAngles = rotation;

    }

}
