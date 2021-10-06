using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    private int count;
    // Start is called before the first frame update
    void Start()
    {
        count = PlayerPrefs.GetInt("Count");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void restartGame()
    {
        count = count + 1;
        PlayerPrefs.SetInt("Count", count);
        if(count == 3)
            FindObjectOfType<UnityAds>().showInterstitialAd();
        
        else if(count == 5)
        {
            PlayerPrefs.SetInt("Count", 0);
            FindObjectOfType<UnityAds>().showRewardedAd();
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
    }
}
