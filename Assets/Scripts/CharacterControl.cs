using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterControl : MonoBehaviour {

    [SerializeField] private float _moveSpeed = 0;
    [SerializeField] private float _rotateSpeed = 0;

    private bool curState = false;

    private IEnumerator coroutine;
    private CharacterController _characterController;
    private Camera _camera;
    public Image image;
    Color color;

    private bool pongPlayed = false;
    public string scene = "PingPong";

    void Start ()
    {
		_characterController = GetComponent<CharacterController>();
        _camera = Camera.main;
        Cursor.lockState = CursorLockMode.Locked;
    }
	
	void Update ()
    {
        if(curState != true)
        {
            Vector3 moveDir = transform.forward * Input.GetAxis("Vertical") + transform.right * Input.GetAxis("Horizontal");
            _characterController.SimpleMove(moveDir * _moveSpeed);

            float yRot = Input.GetAxis("Mouse X") * _rotateSpeed;
            float xRot = Input.GetAxis("Mouse Y") * _rotateSpeed;
            transform.Rotate(0, yRot, 0);
            _camera.transform.Rotate(-xRot, 0, 0);

            if (Input.GetMouseButtonDown(0))
                Cursor.lockState = CursorLockMode.Locked;
        }

        if (Input.GetButtonDown("Fire2"))
        {
            if(curState == false)
            {
                Cursor.lockState = CursorLockMode.None;
                curState = true;

            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                curState = false;
            }
        }

        if(pongPlayed)
        {
            Cursor.lockState = CursorLockMode.Locked;
            curState = false;
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
        pos.z = 0.6f;
        transform.position = pos;
        // Fade back into game
        _camera.transform.eulerAngles = new Vector3(0, 180, 0);
        image.CrossFadeAlpha(0f, 3.0f, false);
        yield return new WaitForSeconds(3);
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Pong")
        {
            Cursor.lockState = CursorLockMode.None;
            curState = true;
            coroutine = FadeOut();
            StartCoroutine(coroutine);
        }
    }

}
