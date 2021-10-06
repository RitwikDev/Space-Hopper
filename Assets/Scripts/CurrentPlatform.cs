using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentPlatform : MonoBehaviour
{
    private GameObject currentPlatform;
    // Start is called before the first frame update
    void Start()
    {
        currentPlatform = GameObject.Find("3 Platforms");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionStay(Collision col)
    {
    }

    public GameObject getCurrentPlatform()
    {
        return currentPlatform;
    }

    public void setCurrentPlatform(GameObject gameObject)
    {
        currentPlatform = gameObject;
    }
}
