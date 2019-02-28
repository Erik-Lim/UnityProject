using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCdialogue : MonoBehaviour
{
    public DialogueTrigger low;
    public DialogueTrigger high;
    private int karma = 0;
    // Start is called before the first frame update
    void Start()
    {
        // Get karma score from main player
        karma = GameObject.FindWithTag("Player").GetComponent<PlayerBehavior>().count;
    }

    // Update is called once per frame
    void Update()
    {
        // Update karma score from main player
        karma = GameObject.FindWithTag("Player").GetComponent<PlayerBehavior>().count;
        Debug.Log(karma);
    }

    void OnTriggerEnter(Collider collision)
    {
        // Prompt player to hit "Fire1" (left ctrl) to start dialogue
        if (collision.gameObject.tag == "Player")
        {
            // display text/button that sasy to hit Left Ctrl (or A? for joystick)
        }
    }

    void OnTriggerStay(Collider collision)
    {
        // Start dialogue if player hits "Fire1" (left ctrl)
        if (collision.gameObject.tag == "Player")
        {
            if (Input.GetButtonDown("Fire1"))
            {
                // Also disable text/button that prompted player to hit button

                // if collosion.karam < 10
                if (karma < 10)
                    low.TriggerDialogue();
                // if collosion.karam >= 10
                if (karma >= 10)
                    high.TriggerDialogue();
            }
        }
    }

    void OnTriggerExit(Collider collision)
    {
        // End dialogue upon player exit
        if (collision.gameObject.tag == "Player")
        {
            FindObjectOfType<DialogueManager>().EndDialogue();
        }
    }
}
