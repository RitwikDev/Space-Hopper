using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public GameObject player;
    public GameObject toDestroy;
    private float platformLength = 150f;
    public float gapBetweenPlatforms = 10f;

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject == player)
        {
            float offset = Random.Range(-4f, 4f);
            Vector3 newPosition = new Vector3(this.transform.position.x+offset, this.transform.position.y, this.transform.position.z+(2*(platformLength+gapBetweenPlatforms)));
            toDestroy.transform.position = newPosition;
        }
    }
}
