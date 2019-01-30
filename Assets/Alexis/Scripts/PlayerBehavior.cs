using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    private Rigidbody player;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody>();
        Debug.Log("Welcome");
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    // Must use "Collider" as variable for trigger functions
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "NPC")
        {
            Debug.Log("NPC nearby");
        }

    }
}
