using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class UnityAds : MonoBehaviour
{
    private string gameID = "4086000", interstitialID = "Interstitial_iOS", rewardedID = "Rewarded_iOS", bannerID = "Banner_iOS";
    public bool testMode = true;
    // Start is called before the first frame update
    void Start()
    {
        Advertisement.Initialize(gameID, testMode);
        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
        StartCoroutine(ShowBannerWhenReady());
    }

    public void showInterstitialAd()
    {
        Advertisement.Show(interstitialID);
    }

    public void showRewardedAd()
    {
        Advertisement.Show(rewardedID);
    }

    IEnumerator ShowBannerWhenReady () 
    {
        while (!Advertisement.IsReady(bannerID)) 
        {
            yield return new WaitForSeconds(0.5f);
        }
        Advertisement.Banner.Show(bannerID);
    }
}