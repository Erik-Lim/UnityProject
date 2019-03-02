using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class startPong : MonoBehaviour
{
    Transform target;

    private IEnumerator coroutine;
    public Image image;
    Color color;
    public GameObject myObject;
    public Camera setMainCamera;
    private bool pongPlayed = false;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        myObject.SetActive(false);
        setMainCamera = GameObject.FindWithTag("Player").GetComponent<CharacterControl>()._camera;
    }

    // Update is called once per frame
    void Update()
    {
        setMainCamera = GameObject.FindWithTag("Player").GetComponent<CharacterControl>()._camera;

        if (pongPlayed)
        {
            myObject.SetActive(true);
            pongPlayed = false;
        }
    }

    IEnumerator FadeOut()
    {
        // alpha cannot be 0 to use CrossFadeAlpha
        color.a = 0.01f;
        image.color = color;
        // Fade out to black and face board
        image.CrossFadeAlpha(255f, 3.0f, false);
        yield return new WaitForSeconds(3);
        var pos = transform.position;
        pos.x = 4.2f;
        pos.y = 0.942f;
        pos.z = 145.0f;
        target.transform.position = pos;
        // Fade back into game
        setMainCamera.transform.eulerAngles = new Vector3(0, 180, 0);
        image.CrossFadeAlpha(0f, 3.0f, false);
        yield return new WaitForSeconds(3);
        pongPlayed = true;
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            coroutine = FadeOut();
            StartCoroutine(coroutine);
        }
    }
}
