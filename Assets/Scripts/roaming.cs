﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class roaming : MonoBehaviour
{
    Transform target;

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

    public float rotSpeed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
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
    }

    IEnumerator Talking()
    {
        animator.SetInteger("Switch", 1);
        isTalking = true;
        yield return new WaitForSeconds(3);
        isTalking = false;
        isWandering = false;
    }

    IEnumerator Wander()
    {
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
        isWandering = false;
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            myButton.gameObject.SetActive(true);
            _AudioSource.Play();

            isWalking = isRotating = false;
            StopCoroutine(wanderCoroutine);
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

    void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // Face player
            var step = rotSpeed * Time.deltaTime;
            Vector3 direction = (target.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, step);
        }
    }

    void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            myButton.gameObject.SetActive(false);
            isTalking = false;
            isWandering = false;
        }
    }
}
