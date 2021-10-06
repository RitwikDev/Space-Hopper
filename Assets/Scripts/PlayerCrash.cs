using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrash : MonoBehaviour
{
    public GameObject player;
    public GameOver gameOver;
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
        // if(col.gameObject == player)
        // {
        //     player.gameObject.SetActive(false);
        //     gameOver.setGameOver();
        // }
    }
}
