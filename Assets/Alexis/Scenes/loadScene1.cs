using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadScene1 : MonoBehaviour
{
    // Must use "Collider" as variable for trigger functions
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // Load level 1
            //PlayerPrefs.SetInt("Player Score", collision.count);
            SceneManager.LoadScene(0);
        }

    }
}
