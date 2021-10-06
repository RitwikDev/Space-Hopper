using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    float smoothFactor = 0.5f;
    Vector3 offset;

    void Start()
    {
        transform.position = new Vector3(0f, 20f, -5f);
        transform.eulerAngles = new Vector3(0f, 90f, 0f);
        // transform.LookAt(target);
    }
    void FixedUpdate()
    {
        if(FindObjectOfType<StartNewGame>().start)
        {
            offset = new Vector3(0, 1f, -8);
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothPosition = Vector3.Lerp(transform.position, desiredPosition, smoothFactor);
            transform.position = smoothPosition;

            Vector3 rotate = new Vector3(Input.GetAxis("Horizontal")*10f, 0, Input.GetAxis("Vertical")*10f);
            transform.LookAt(target);
        }
        
        else
        {
            transform.LookAt(target);
            transform.Translate(Vector3.left * 0.19f);
            transform.Translate(Vector3.down * 0.06f);
            transform.Translate(Vector3.forward * 0.08f);
        }
    }
}