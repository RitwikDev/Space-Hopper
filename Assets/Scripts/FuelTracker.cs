using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelTracker : MonoBehaviour
{
    private float fuelLeft;
    private GameObject nextPlatform;
    public GameObject gameOver, fuelCell1Platform;
    public GameObject[] fuelCellsTwoPlatforms = new GameObject[2], fuelCellsThreePlatforms = new GameObject[3];
    public CurrentPlatform currentPlatform;
    private static bool fuelCreated = false;
    // public Scrollbar fuelScrollBar;
    public Image fuelImageLeft, fuelImageRight;
    public Player player;
    public GameOver gameOverObject;

    // Start is called before the first frame update
    void Start()
    {
        fuelCreated = false;
        fuelLeft = 30f;
        fuelCell1Platform.SetActive(false);
        
        foreach(GameObject i in fuelCellsTwoPlatforms)
            i.SetActive(false);
        
        foreach(GameObject i in fuelCellsThreePlatforms)
            i.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(FindObjectOfType<StartNewGame>().start)
        {
            if(fuelLeft > 0)
            {
                fuelLeft = fuelLeft - Time.deltaTime;
                // fuelScrollBar.size = fuelLeft/30f;
                fuelImageLeft.fillAmount = fuelLeft/30f;
                fuelImageRight.fillAmount = fuelLeft/30f;
            }

            if(fuelLeft <= 0)
            {
                player.stopMoving();
                gameOverObject.setGameOver();
            }

            if(fuelLeft <= Random.Range(5f, 9f) && !fuelCreated)
                createFuel();
        }
    }

    public void resetFuel(string platform)
    {
        fuelLeft = 30f;
        deleteFuel(platform);
        fuelCreated = false;
    }

    private void createFuel()
    {
        fuelCreated = true;
        nextPlatform = currentPlatform.getCurrentPlatform();
        if(nextPlatform.name.Equals("3 Platforms"))
            for(int i=0; i<fuelCellsThreePlatforms.Length; i=i+1)
                fuelCellsThreePlatforms[i].SetActive(true);

        else if(nextPlatform.name.Equals("2 Platforms"))
            for(int i=0; i<fuelCellsTwoPlatforms.Length; i=i+1)
                fuelCellsTwoPlatforms[i].SetActive(true);

        else
            fuelCell1Platform.SetActive(true);
    }

    public void setFuel(float x)
    {
        fuelLeft = x;
    }

    public void deleteFuel(string platform)
    {
        if(platform.Equals("3 Platforms"))
            for(int i=0; i<fuelCellsThreePlatforms.Length; i=i+1)
                fuelCellsThreePlatforms[i].SetActive(false);

        else if(platform.Equals("2 Platforms"))
            for(int i=0; i<fuelCellsTwoPlatforms.Length; i=i+1)
                fuelCellsTwoPlatforms[i].SetActive(false);

        else
            fuelCell1Platform.SetActive(false);
    }
}
