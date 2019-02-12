using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class roaming : MonoBehaviour
{
    public Button myButton; 

    Animator animator;
    public AudioSource _AudioSource;
    public AudioClip _AudioClip1;

    private bool isWandering = false;
    private bool isRotating = false;
    private bool isWalking = false;
    private bool stayIdle = false;
    private bool isTalking = false;
    private IEnumerator wanderCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetInteger("Switch", 1);
        wanderCoroutine = Wander();
        myButton.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isWandering)
        {
            Debug.Log("Wandering is false: STARTING COROUTINE");
            wanderCoroutine = Wander();
            StartCoroutine(wanderCoroutine);
        }

        if (isRotating)
        {
            if (!stayIdle)
            {
                transform.Rotate(0, 90, 0);
                animator.SetInteger("Switch", 2);
                stayIdle = true;
            }

            else
            {
                animator.SetInteger("Switch", 1);
            }
        }

        if (isWalking)
        {
            transform.Translate(0, 0, Time.deltaTime);
        }

        if (isTalking)
        {
            Debug.Log("Talking to player");
            animator.SetInteger("Switch", 1);
        }

        Debug.Log("isWandering is " + isWandering);
    }

    IEnumerator Talking()
    {
        Debug.Log("Talking to player");
        animator.SetInteger("Switch", 1);
        isTalking = true;
        yield return new WaitForSeconds(3);
        Debug.Log("Done talking");
        isTalking = false;
        isWandering = false;
    }

    IEnumerator Wander()
    {
        Debug.Log("She be wandering -------------");
        int rotTime = Random.Range(1, 3);
        int rotateWait = Random.Range(1, 3);
        int walkWait = Random.Range(1, 2);
        int walkTime = Random.Range(1, 5);

        // Wait
        isWandering = true;
        animator.SetInteger("Switch", 1);
        yield return new WaitForSeconds(walkWait);

        // Walk
        isWalking = true;
        animator.SetInteger("Switch", 0);
        yield return new WaitForSeconds(walkTime);
        isWalking = false;

        // Wait
        animator.SetInteger("Switch", 1);
        yield return new WaitForSeconds(rotateWait);

        // Turn
        isRotating = true;
        yield return new WaitForSeconds(rotTime);

        isRotating = false;
        stayIdle = false;
        Debug.Log("DONE with ------ Wander()");
        isWandering = false;
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            myButton.gameObject.SetActive(true);
            //_AudioSource.clip = _AudioClip1;
            _AudioSource.Play();

            isWalking = isRotating = false;
            StopCoroutine(wanderCoroutine);
            Debug.Log("Stopped wander couroutine.");
            transform.Translate(0, 0, 0);
            isTalking = true;
        }

        else
        {
            // Turn around if running into something
            isWalking = isRotating = false;
            StopCoroutine(wanderCoroutine);
            transform.Translate(0, 0, 0);
            transform.Rotate(0, 90, 0);
            isWandering = false;
        }
    }

    void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            myButton.gameObject.SetActive(false);
            Debug.Log("Done talking");
            isTalking = false;
            isWandering = false;
        }
    }
}
