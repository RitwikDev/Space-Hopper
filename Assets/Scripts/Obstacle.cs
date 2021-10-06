using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private GameObject currentPlatformGameObject;
    public CurrentPlatform currentPlatform;
    public GameObject[] onePlatformObstacles = new GameObject[3], twoPlatformsObstacles = new GameObject[3], threePlatformsObstacles = new GameObject[5];

    // Start is called before the first frame update
    void Start()
    {
        destroyObstacles(onePlatformObstacles);
        destroyObstacles(twoPlatformsObstacles);
        destroyObstacles(threePlatformsObstacles);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setObstacles(GameObject currentPlatform)
    {
        if(currentPlatform.name.Equals("1 Platform"))
            set1PlatformObstacle(currentPlatform);

        else if(currentPlatform.name.Equals("2 Platforms"))
            set2PlatformsObstacle(currentPlatform);

        else if(currentPlatform.name.Equals("3 Platforms"))
            set3PlatformsObstacle(currentPlatform);
    }

    private void set1PlatformObstacle(GameObject currentPlatform)
    {
        destroyObstacles(onePlatformObstacles);
        int x = Random.Range(0, 10);
            
        if(x == 0 || x == 1)
            return;     //No obstacle

        else if(x == 2 || x == 3 || x == 4)
        {
            x = Random.Range(0, 2);
            if(x == 0)
                onePlatformObstacles[0].SetActive(true);
            else
                onePlatformObstacles[2].SetActive(true);
        }

        else if(x == 5 || x == 6 || x == 7)
        {
            x = Random.Range(0, 2);
            if(x == 0)
            {
                onePlatformObstacles[0].SetActive(true);
                onePlatformObstacles[1].SetActive(true);
            }

            else
            {
                onePlatformObstacles[0].SetActive(true);
                onePlatformObstacles[2].SetActive(true);
            }
        }

        else
        {
            onePlatformObstacles[0].SetActive(true);
            onePlatformObstacles[1].SetActive(true);
            onePlatformObstacles[2].SetActive(true);
        }
    }

    private void set2PlatformsObstacle(GameObject currentPlatform)
    {
        destroyObstacles(twoPlatformsObstacles);
        int x = Random.Range(0, 10);
            
        if(x == 0 || x == 1)
            return;     //No obstacle

        else if(x == 2 || x == 3 || x == 4)
            twoPlatformsObstacles[Random.Range(0, 3)].SetActive(true);

        else if(x == 5 || x == 6 || x == 7)
        {
            x = Random.Range(0, 3);
            if(x == 0)
            {
                twoPlatformsObstacles[0].SetActive(true);
                twoPlatformsObstacles[1].SetActive(true);
            }

            else if(x == 1)
            {
                twoPlatformsObstacles[0].SetActive(true);
                twoPlatformsObstacles[2].SetActive(true);
            }

            else
            {
                twoPlatformsObstacles[1].SetActive(true);
                twoPlatformsObstacles[2].SetActive(true);
            }
        }

        else
        {
            twoPlatformsObstacles[0].SetActive(true);
            twoPlatformsObstacles[1].SetActive(true);
            twoPlatformsObstacles[2].SetActive(true);
        }
    }

    private void set3PlatformsObstacle(GameObject currentPlatform)
    {
        destroyObstacles(threePlatformsObstacles);
        int x = Random.Range(0, 12);
            
        if(x == 0 || x == 1)
            return;     //No obstacle

        else if(x == 2 || x == 3)
            threePlatformsObstacles[Random.Range(0, 5)].SetActive(true);

        else if(x == 4 || x == 5)
        {
            threePlatformsObstacles[Random.Range(0, 5)].SetActive(true);
            threePlatformsObstacles[Random.Range(0, 5)].SetActive(true);
        }

        else if(x == 6 || x == 7)
        {
            threePlatformsObstacles[Random.Range(0, 5)].SetActive(true);
            threePlatformsObstacles[Random.Range(0, 5)].SetActive(true);
            threePlatformsObstacles[Random.Range(0, 5)].SetActive(true);
        }

        else if(x == 8 || x == 9)
        {
            threePlatformsObstacles[Random.Range(0, 5)].SetActive(true);
            threePlatformsObstacles[Random.Range(0, 5)].SetActive(true);
            threePlatformsObstacles[Random.Range(0, 5)].SetActive(true);
            threePlatformsObstacles[Random.Range(0, 5)].SetActive(true);
        }

        else
        {
            threePlatformsObstacles[0].SetActive(true);
            threePlatformsObstacles[1].SetActive(true);
            threePlatformsObstacles[2].SetActive(true);
            threePlatformsObstacles[3].SetActive(true);
            threePlatformsObstacles[4].SetActive(true);
        }
    }

    private void destroyObstacles(GameObject[] platform)
    {
        for(int i=0; i<platform.Length; i=i+1)
            platform[i].SetActive(false);
    }
}
