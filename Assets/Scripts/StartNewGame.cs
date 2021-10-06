using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartNewGame : MonoBehaviour
{
    public bool start;
    private float timeToStart;
    public Canvas playerControls;
    // Start is called before the first frame update
    void Start()
    {
        timeToStart = 0f;
        start = false;
        playerControls.GetComponent<CanvasGroup>().alpha = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(timeToStart <= 5f)
        {
            timeToStart = timeToStart + Time.deltaTime;
            playerControls.GetComponent<CanvasGroup>().alpha = timeToStart/5f;
        }
        else
            start = true;
    }
}
