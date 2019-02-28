using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerBehavior : MonoBehaviour
{
    public string scene = "MainMenu";
    public Color loadToColor = Color.black;
    public float speed = 1.0f;

    public Canvas winCanvas;
    public Canvas loseCanvas;
    public Text setTime;
    public Text countText;

    private Rigidbody player;
    public static float currentTime = 0.0f;
    public int count;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();

        // Win/lose states disabled
        winCanvas.gameObject.SetActive(false);
        loseCanvas.gameObject.SetActive(false);
    }

    void Update()
    {
        currentTime += Time.deltaTime;
        setTime.text = "Time: " + currentTime;

        // Lose game
        /*
        if (currentTime > 10.0f)
        {
            // Freeze game
            Time.timeScale = 0;
            loseCanvas.gameObject.SetActive(true);
            if (Input.GetButtonDown("Fire1"))
            {
                SceneManager.LoadScene(3);
                //Initiate.Fade(scene, loadToColor, speed);
            }
        }
        */
    }
    
    // Must use "Collider" as variable for trigger functions
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "NPC")
        {
            count = count + 1;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "Score: " + count.ToString();
    }
}
