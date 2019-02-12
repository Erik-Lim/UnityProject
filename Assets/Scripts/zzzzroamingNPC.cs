using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roamingNPC : MonoBehaviour
{
    Animator animator;
    private Rigidbody NPC;
    private float timer = 0.0f;
    private bool turn = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        NPC = GetComponent<Rigidbody>();
        animator.SetInteger("Switch", 9);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("time is: " + timer);
        timer += Time.deltaTime;


        if (timer <= 3.6f)
        {
            animator.SetInteger("Switch", 0);
            transform.Translate(0, 0, Time.deltaTime);
        }

        if(timer > 3.6f && timer < 4.6f)
        {
            animator.SetInteger("Switch", 2);
            //transform.Translate(0, 0, 0);
            if (!turn)
            {
                transform.Rotate(0, 180, 0);
                turn = true;
            }
        }

        if (timer > 4.6f)
        {
            timer = 0.0f;
            turn = false;
        }
    }

    // Must use "Collider" as variable for trigger functions
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            animator.SetInteger("Switch", 1);
        }
    }

    void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            animator.SetInteger("Switch", 1);
        }
    }
}
