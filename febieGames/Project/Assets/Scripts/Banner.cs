using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;

public class Banner : MonoBehaviour
{

    public string gameId = "3486326";
    public string placementId = "banner";
    public bool testMode = true;
    private object adUnitId;

    public object AdSize { get; private set; }

    void Start()
    {
        Advertisement.Initialize(gameId, testMode);
        StartCoroutine(ShowBannerWhenReady());
        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_LEFT);
    }

    IEnumerator ShowBannerWhenReady()
    {
        while (!Advertisement.IsReady(placementId))
        {
            yield return new WaitForSeconds(0.5f);
        }
        Advertisement.Banner.Show(placementId);


        
    }
}