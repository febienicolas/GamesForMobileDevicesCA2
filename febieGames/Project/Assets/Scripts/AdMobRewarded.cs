using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using GoogleMobileAds.Api;
using UnityEngine.UI;

public class AdMobRewarded : MonoBehaviour
{
    private RewardBasedVideoAd rewardedVideo;

    public Text rewardText;

    private int gameAmount = 0;

    private int rewardAmount = 0;

    public void Start()
    {
#if UNITY_ANDROID
        string appId = "ca-app-pub-3963265922936304~9741129936";
#elif UNITY_IPHONE
            string appId = "ca-app-pub-3940256099942544~1458002511";
#else
            string appId = "unexpected_platform";
#endif

        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(appId);

        rewardedVideo = RewardBasedVideoAd.Instance;
        rewardedVideo.OnAdRewarded += HandleUserEarnedReward;
        rewardedVideo.OnAdClosed += HandleRewardedAdClosed;
        RequestRewardVideo();

    }

    void Update()
    {
        if (rewardAmount > 0)
        {
            gameAmount += rewardAmount;
            rewardText.text = gameAmount.ToString();
            rewardAmount = 0;
        }
    }

    public void ShowRewardVideo()
    {
        if (rewardedVideo.IsLoaded())
            rewardedVideo.Show();
    }

    public void RequestRewardVideo()
    {
#if UNITY_ANDROID
        string rewardAdId = "ca-app-pub-3940256099942544/5224354917";
#elif UNITY_IPHONE
            string adUnitId = "ca-app-pub-3940256099942544/2934735716";
#else
            string adUnitId = "unexpected_platform";
#endif

        rewardedVideo.LoadAd(CreateNewRequest(), rewardAdId);

    }

    private AdRequest CreateNewRequest()
    {
        return new AdRequest.Builder().Build();
    }

    private void HandleUserEarnedReward(object sender, Reward args)
    {

        double amount = args.Amount;
        rewardAmount = (int)amount;

    }

    private void HandleRewardedAdClosed(object sender, EventArgs args)
    {
        RequestRewardVideo();
    }
}




  