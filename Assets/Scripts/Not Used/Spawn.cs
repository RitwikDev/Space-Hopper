using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject player;
    public GameObject nextPlatform;
    // Update is called once per frame
    void OnTriggerEnter(Collider col)
    {
        // if(col.gameObject == player)
        //     Instantiate(nextPlatform, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z+16f), this.transform.rotation);
    }
}
