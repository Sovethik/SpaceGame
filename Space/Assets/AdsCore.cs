using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsCore : MonoBehaviour, IUnityAdsListener
{
    [SerializeField] private bool _testMode = true;
    private string gameId = "4398045";
    private string video = "Interstitial_Android";
    private string rewarded = "Rewarded_Android";

    private void Start()
    {
        Advertisement.Initialize(gameId, _testMode);
        Advertisement.AddListener(this);
    }

    public static void ShowAdsVideo(string placemetId)
    {
        if (Advertisement.IsReady())
            Advertisement.Show(placemetId);

        else
            SpawnTextAdv.Spawn = true;
    }


    public void OnUnityAdsReady(string placementId)
    {
       
    }

    public void OnUnityAdsDidError(string message)
    {
        
    }

    public void OnUnityAdsDidStart(string placementId)
    {
       
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if(showResult == ShowResult.Finished)
        {
            Game.ScoreCoin += 10;
            PlayerPrefs.SetInt("ScoreCoin", Game.ScoreCoin);

        }

        else if(showResult == ShowResult.Skipped)
        {

        }

        else if(showResult == ShowResult.Failed)
        {

        }

    }
}
