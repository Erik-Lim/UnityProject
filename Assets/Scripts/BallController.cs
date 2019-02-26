using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    int Invert;
    public int TowardsPlayer = 1;
    float xVel = 14.0f;

    // Start is called before the first frame update
    void Start()
    {
        Invert = 1;
        TowardsPlayer = 1;

        GetComponent<Rigidbody>().velocity = new Vector3(xVel, 0.0f, 5.0f);
    }

    // Update is called once per frame
    void Update()
    {
        //if enemy lost
        if(transform.position.z < -12f)
        {
            GameObject.Find("Main Camera").GetComponent<Score>().IncreaseScore(2);
            Start();
            transform.position = Vector3.zero;
        }
        //if player lost
        if (transform.position.z > 12f)
        {
            GameObject.Find("Main Camera").GetComponent<Score>().IncreaseScore(1);
            Start();
            transform.position = Vector3.zero;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "wall")
        {
            Invert = Invert * -1;
            GetComponent<Rigidbody>().velocity = new Vector3(xVel * Invert, 0.0f, 5.0f*TowardsPlayer);
        }
        else if (collision.gameObject.name == "Player")
        {
            TowardsPlayer = 1;
            GetComponent<Rigidbody>().velocity = new Vector3(xVel * Invert, 0.0f, 5.0f);
        }
        else if (collision.gameObject.name == "AI")
        {
            TowardsPlayer = -1;
            GetComponent<Rigidbody>().velocity = new Vector3(xVel * Invert, 0.0f, -5.0f);
        }
    }
}
