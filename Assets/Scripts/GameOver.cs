using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject gameOver, player, fuelTracker;
    private AudioSource scream;
    void Start()
    {
        gameOver.SetActive(false);
        scream = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject == player)
            setGameOver();
    }

    public void setGameOver()
    {
        fuelTracker.SetActive(false);
        gameOver.SetActive(true);
        scream.Play();
        // fuelTracker.GetComponent<FuelTracker>().setFuel(0);
    }
}
