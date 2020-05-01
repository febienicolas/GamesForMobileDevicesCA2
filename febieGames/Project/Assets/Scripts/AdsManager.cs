using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Monetization;
using UnityEngine.UI;

public class AdsManager : MonoBehaviour
{
    public Text rewardText;
    private int rewardCount = 0;
    private string gameId = "1234567";

    private bool testMode = true;
    string placementId_rewardedVideo = "rewardedVideo";
    
   
    void Start()
    {
        if (Application.platform == RuntimePlatform.IPhonePlayer)
            gameId = "";
        else if (Application.platform == RuntimePlatform.Android)
            gameId = "3486326";

        Monetization.Initialize(gameId, testMode);

    }

    public void ShowAd()
    {

        StartCoroutine(WaitForAd());

    }

    public void ShowRewardedAd()
    {
        StartCoroutine(WaitForAd(true));
    }

    IEnumerator WaitForAd(bool reward = false)
    {
        string placementId = placementId_rewardedVideo;
        while (!Monetization.IsReady(placementId))
        {
            yield return null;
        }
        ShowAdPlacementContent ad = null;
        ad = Monetization.GetPlacementContent(placementId) as ShowAdPlacementContent;

        if (ad != null)
        {
            if (reward)
                ad.Show(AdFinished);
            else
                ad.Show();
        }
    }

 

    void AdFinished(ShowResult result)
    {

        if (result == ShowResult.Finished)
        {

            rewardCount++;
            rewardText.text = rewardCount.ToString();

        }
    }



}

