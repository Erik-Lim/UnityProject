using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour {

    float x = 0;
    float y = 0;

    [SerializeField] private float _moveSpeed = 0;
    [SerializeField] private float _rotateSpeed = 0;

    private bool curState = false;

    private CharacterController _characterController;
    private Camera _camera;

    void Start ()
    {
		_characterController = GetComponent<CharacterController>();
        _camera = Camera.main;

        Cursor.lockState = CursorLockMode.Locked;
    }
	
	void Update ()
    {
        if(curState != true)
        {
            Vector3 moveDir = transform.forward * Input.GetAxis("Vertical") + transform.right * Input.GetAxis("Horizontal");
            _characterController.SimpleMove(moveDir * _moveSpeed);

            float yRot = Input.GetAxis("Mouse X") * _rotateSpeed;
            float xRot = Input.GetAxis("Mouse Y") * _rotateSpeed;
            transform.Rotate(0, yRot, 0);
            _camera.transform.Rotate(-xRot, 0, 0);

            if (Input.GetMouseButtonDown(0))
                Cursor.lockState = CursorLockMode.Locked;
        }

        if (curState == true)
        {
            //x = Input.GetAxis("Mouse X") + x;
            //y = Input.GetAxis("Mouse Y") + y;
            //transform.Rotate(x, 0, y);
        }

        if (Input.GetButtonDown("Fire2"))
        {
            if(curState == false)
            {
                Cursor.lockState = CursorLockMode.None;
                curState = true;

            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                curState = false;
            }
        }
    }
}
