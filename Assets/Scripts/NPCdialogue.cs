using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCdialogue : MonoBehaviour
{
    public DialogueTrigger low;
    public DialogueTrigger high;
    public DialogueManager dialogueManger;

    private int karma = 0;
    private bool finishedDialogue = false;

    // Dialogue flags
    private bool startedDialogue = false;


    // Start is called before the first frame update
    void Start()
    {
        // Get karma score from main player
        karma = GameObject.FindWithTag("Player").GetComponent<PlayerBehavior>().count;
        finishedDialogue = dialogueManger.finished;
    }

    // Update is called once per frame
    void Update()
    {
        // Update karma score from main player
        karma = GameObject.FindWithTag("Player").GetComponent<PlayerBehavior>().count;
        finishedDialogue = dialogueManger.finished;
        Debug.Log(finishedDialogue);
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


                if (startedDialogue)
                {
                    dialogueManger.DisplayNextSentence();

                    if (finishedDialogue)
                    {
                        Debug.Log("NPC says finished = true");
                        startedDialogue = false;
                        dialogueManger.finished = false;
                    }
                }

                else
                {
                    startedDialogue = true;

                    // if collosion.karam < 10
                    if (karma < 10)
                    {
                        low.TriggerDialogue();
                        dialogueManger.DisplayNextSentence();
                    }
                    // if collosion.karam >= 10
                    if (karma >= 10)
                    {
                        high.TriggerDialogue();
                        dialogueManger.DisplayNextSentence();
                    }
                }
            }
        }
    }

    void OnTriggerExit(Collider collision)
    {
        // End dialogue upon player exit
        if (collision.gameObject.tag == "Player")
        {
            FindObjectOfType<DialogueManager>().EndDialogue();
            startedDialogue = false;
            dialogueManger.finished = false;
        }
    }
}
