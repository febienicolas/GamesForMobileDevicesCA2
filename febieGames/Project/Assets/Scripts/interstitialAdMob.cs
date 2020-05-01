using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;

public class interstitialAdMob : MonoBehaviour
{
    private BannerView bannerView;
    private InterstitialAd interstitial;

    //use this for initialization 
    void start()
    {
#if UNITY_ANDROID
        string appId = "ca-app-pub-3963265922936304~9741129936";
#elif UNITY_IPHONE
        string appId = "ca-app-pub-3940256099942544/4411468910";
#else
        string appId = "unexpected_platform";
#endif

        MobileAds.Initialize(appId);


        //RequestBanner();


    }

    public void ShowInterstitial()
    {
        RequestInterstitial();

    }
    private void RequestInterstitial()
    {

#if UNITY_ANDROID
        string instertitialId = "ca-app-pub-3940256099942544/1033173712";
#elif UNITY_IPHONE
        string instertitialId = "ca-app-pub-3940256099942544/4411468910";
#else
        string instertitialId = "unexpected_platform";
#endif
        if (interstitial != null)
            interstitial.Destroy();

        interstitial = new InterstitialAd(instertitialId);
        interstitial.OnAdLoaded += HandleOnAdLoaded;

        interstitial.LoadAd(CreateNewRequest());
    }

    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        if (interstitial.IsLoaded())
            interstitial.Show();
    }

   

    private AdRequest CreateNewRequest()
    {

        return new AdRequest.Builder().Build();
    }
}


       