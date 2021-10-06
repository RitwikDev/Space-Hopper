using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 inputVector;
    public bool gameOver = false, grounded;
    private float moveX = 5, stopTime = 2f, brakePressedTime;
    public float speed = 18f;
    private Joystick joystick;
    private AudioSource landSound;
    private Brake brake;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        joystick = FindObjectOfType<Joystick>();
        transform.position = transform.position + new Vector3(0f, 20f, 0f);
        landSound = GetComponent<AudioSource>();
        brake = FindObjectOfType<Brake>();
    }

    // Update is called once per frame
    void Update()
    {
        if(FindObjectOfType<StartNewGame>().start)
        {
            if(!gameOver)
            {
                brakePressedTime = brake.pressedTime;
                if(Input.GetKeyDown(KeyCode.RightControl) && grounded)
                {
                    grounded = false;
                    playerJump();
                }

                if(rb.velocity.y < 0)
                    rb.velocity = rb.velocity + Vector3.up * Physics.gravity.y * 3f * Time.deltaTime;
                
                else if(rb.velocity.y > 0)
                    rb.velocity = rb.velocity + Vector3.up * Physics.gravity.y * 2f * Time.deltaTime;

                grounded = false;
                // inputVector = new Vector3(Input.GetAxis("Horizontal")*10f, rb.velocity.y, Input.GetAxis("Vertical")*10f);
                inputVector = new Vector3(rb.velocity.x, rb.velocity.y, speed - brakePressedTime * speed);
                // transform.LookAt(transform.position + new Vector3(0f, 0f, inputVector.z));
                // transform.Rotate(new Vector3(0f, 0f, -Input.GetAxis("Horizontal")*45f));
            }

            else
            {
                if(stopTime >= 0.5)
                {
                    stopMoving();
                    stopTime = stopTime - Time.deltaTime;
                }
            }
        }

        else
            rb.velocity = new Vector3(0f, -4f, 0f);
    }

    void FixedUpdate()
    {
        if(FindObjectOfType<StartNewGame>())
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, inputVector.z);
    }

    public void stopMoving()
    {
        gameOver = true;
        inputVector = new Vector3(0f, rb.velocity.y, moveX*2);
        transform.LookAt(transform.position + new Vector3(inputVector.x, 0f, inputVector.z));
        moveX = moveX - Time.deltaTime;
        if(moveX <= 0)
            moveX = 0;
        return;
    }

    void playerJump()
    {
        grounded = false;
        rb.velocity = Vector3.up * 15f;
    }

    void OnCollisionStay()
    {
            grounded = true;
    }

    public void jumpButtonPressed()
    {
        if(grounded)
            playerJump();
    }

    void OnCollisionEnter(Collision col)
    {
        landSound.Play();
    }
}