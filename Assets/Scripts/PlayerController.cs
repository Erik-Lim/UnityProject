using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float _moveSpeed = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        transform.position = new Vector3(Input.GetAxis("Horizontal") * _moveSpeed, 0.0f, transform.position.z);
    }
}
