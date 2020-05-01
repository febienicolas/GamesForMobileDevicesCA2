using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class interAd : MonoBehaviour { 
    string gameId = "3486326";
    bool testMode = true;

    void Start () {
    // Initialize the Ads service:
    Advertisement.Initialize(gameId, testMode);
        // Show an ad:
        Advertisement.Show();
    }
}