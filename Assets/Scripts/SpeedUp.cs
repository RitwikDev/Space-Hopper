using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : MonoBehaviour
{
    public GameObject player;

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject == player)
            if(FindObjectOfType<ScoreKeeper>().getScore() % 5 == 0 && player.GetComponent<Player>().speed <= 50)
                player.GetComponent<Player>().speed = player.GetComponent<Player>().speed + 2;
    }
}
