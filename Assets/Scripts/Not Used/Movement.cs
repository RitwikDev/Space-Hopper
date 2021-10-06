using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 10f;
    Rigidbody rb;
    /*
    public CharacterController controller;
    public float speed = 10f;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    public Transform camera;
    */

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        rb.AddForce(movement*speed);
    }

    // Update is called once per frame
    /*void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        if(direction.magnitude > 0f)
        {
            float targerAngle = Mathf.Atan2(direction.x, direction.z)*Mathf.Rad2Deg + camera.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targerAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDirection = Quaternion.Euler(0f, targerAngle, 0f)*Vector3.forward;
            controller.Move(moveDirection.normalized*speed*Time.deltaTime);
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody.AddForce(Vector3.up*jumpHeight, ForceMode.Impulse);
        }
    }*/
}
