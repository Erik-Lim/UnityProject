using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadScene2 : MonoBehaviour
{
    public string scene = "Level2";
    public Color loadToColor = Color.white;
    public float speed = 1.0f;

    // Must use "Collider" as variable for trigger functions
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // Load level 2
            //PlayerPrefs.SetInt("Player Score", collision.count);
            Initiate.Fade(scene, loadToColor, speed);
            //SceneManager.LoadScene(1);
        }

    }
}
