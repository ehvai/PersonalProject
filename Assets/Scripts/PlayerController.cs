using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private float speed = 10.0f;
    private float zBound = 18.0f;
    private float xBound = 22.0f;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame

    void Update()
    {

    }
    void FixedUpdate()
    {
        MovePlayerPosition();
        // ConstrainPlayerPosition();

    }

    // Move player left right back and forward by keypress
    void MovePlayerPosition()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        playerRb.MovePosition(Vector3.forward * speed * verticalInput);
        playerRb.MovePosition(Vector3.right * speed * horizontalInput);
        // transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        // transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed);
    }

    // Constrain player to the game area.
    void ConstrainPlayerPosition()
    {
        if (transform.position.z < -zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zBound);
        }

        if (transform.position.z > zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zBound);
        }

        if (transform.position.x < -xBound)
        {
            transform.position = new Vector3(-xBound, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xBound)
        {
            transform.position = new Vector3(xBound, transform.position.y, transform.position.z);
        }

    }
}
