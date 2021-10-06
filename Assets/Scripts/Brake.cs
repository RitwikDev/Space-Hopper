using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Brake : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool buttonPressed = false;
    public GameObject player;
    private Vector3 inputVector;
    private Rigidbody rb;
    public float pressedTime = 0f;
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

            if(pressedTime > 1)
                pressedTime = 1;
        }
        else
            inputVector = new Vector3(0f, 0f, 0f);
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
        pressedTime = 0f;
    }
}
