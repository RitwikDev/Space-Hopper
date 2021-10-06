using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextPlatform : MonoBehaviour
{
    public GameObject player, threePlatforms, twoPlatforms, onePlatform;
    private GameObject toMove = null, currentPlatform;
    private float platformLength = 67f, oneSec;
    private bool startMoving = false;
    public ScoreKeeper scoreKeeper;
    public CurrentPlatform currentPlatformObject;
    public Obstacle obstacle;

    // Start is called before the first frame update
    void Start()
    {
        oneSec = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float playerSpeed = player.GetComponent<Player>().speed;
        switch(playerSpeed)
        {
            case 25f:   platformLength = 85f;
                        break;
            
            case 30f:   platformLength = 93f;
                        break;

            case 35f:   platformLength = 105f;
                        break;

            case 40f:   platformLength = 115f;
                        break;

            case 45f:   platformLength = 125f;
                        break;
        }

        if(startMoving)
        {
            Vector3 newPositionAbove = new Vector3(toMove.transform.position.x, 0f, toMove.transform.position.z);
            toMove.transform.position = Vector3.Lerp(toMove.transform.position, newPositionAbove, oneSec);
            if(oneSec >= 1)
            {
                oneSec = 0;
                startMoving = false;
            }
            oneSec = oneSec + Time.deltaTime;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        currentPlatform = currentPlatformObject.getCurrentPlatform();
        this.transform.position = new Vector3(currentPlatform.transform.position.x, this.transform.position.y, this.transform.position.z + platformLength);

        startMoving = false;
        if(col.gameObject == player)
        {
            float x = Random.Range(0f, 1f);
            
            if(currentPlatform == threePlatforms)
                toMove = (x<0.5)? twoPlatforms : onePlatform;

            else if(currentPlatform == twoPlatforms)
                toMove = (x<0.5)? threePlatforms : onePlatform;
            
            else if(currentPlatform == onePlatform)
                toMove = (x<0.5)? twoPlatforms : threePlatforms;

            currentPlatformObject.setCurrentPlatform(toMove);

            float offset = Random.Range(-4f, 4f);
            Vector3 newPositionBelow = new Vector3(currentPlatform.transform.position.x+offset, -15f, currentPlatform.transform.position.z+platformLength);
            toMove.transform.position = newPositionBelow;
            if(FindObjectOfType<ScoreKeeper>().getScore() > 10)
                obstacle.setObstacles(toMove);
            toMove.SetActive(true);
            startMoving = true;
            
            scoreKeeper.updateScore();
        }
    }
}
