using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hide : MonoBehaviour
{
    public GameObject thisObject;
    // Start is called before the first frame update
    void Start()
    {
        thisObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
