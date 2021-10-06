using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelCell : MonoBehaviour
{
    public GameObject player;
    public FuelTracker fuelTracker;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        fuelTracker.resetFuel(this.gameObject.transform.parent.parent.name);
        this.gameObject.SetActive(false);
    }
}
