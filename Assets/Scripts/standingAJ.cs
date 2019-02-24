using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class standingAJ : MonoBehaviour
{
    Transform target;

    public Button myButton;

    Animator animator;
    public AudioSource _AudioSource;
    public AudioClip _AudioClip1;

    public float rotSpeed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        animator = GetComponent<Animator>();
        //myButton.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //myButton.gameObject.SetActive(true);
            //_AudioSource.clip = _AudioClip1;

            // Swtich from idle (0) to talking (1)
            animator.SetInteger("Switch", 1);
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
            //myButton.gameObject.SetActive(false);

            // Switch from talking (1) to idle (0)
            animator.SetInteger("Switch", 0);
        }
    }
}
