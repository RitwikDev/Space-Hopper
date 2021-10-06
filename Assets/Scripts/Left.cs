using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Left : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool buttonPressed = false;
    public GameObject player;
    private Vector3 inputVector;
    private Rigidbody rb;
    private float pressedTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = player.gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(buttonPressed)
        {
            if(pressedTime < 1)
                pressedTime = pressedTime + Time.deltaTime;

            if(rb.velocity.y < 0)
                rb.velocity = rb.velocity + Vector3.up * Physics.gravity.y * 3f * Time.deltaTime;
            
            else if(rb.velocity.y > 0)
                rb.velocity = rb.velocity + Vector3.up * Physics.gravity.y * 2f * Time.deltaTime;

            inputVector = new Vector3(-pressedTime * 10f, rb.velocity.y, rb.velocity.z);

            if(player.transform.rotation.z < 0.45  && !FindObjectOfType<Player>().grounded)
                player.transform.Rotate(new Vector3(0f, 0f, pressedTime * 45f));
        }
        else if(!FindObjectOfType<Right>().buttonPressed)
        {
            if(pressedTime > 0)
                pressedTime = pressedTime - Time.deltaTime/100;
            
            if(pressedTime < 0)
                pressedTime = 0;

            inputVector = new Vector3(0f, 0f, 0f);
            player.transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
    }

    void FixedUpdate()
    {
        if(buttonPressed)
            rb.velocity = inputVector;
    } 

    public void OnPointerDown(PointerEventData data)
    {
        if(FindObjectOfType<StartNewGame>().start)
        {
            buttonPressed = true;
            pressedTime = 0f;
        }
    }

    public void OnPointerUp(PointerEventData data)
    {
        buttonPressed = false;
    }
}
