using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour {

   /* public GameObject controleMobParaReward;

    void Start()
    {
        Advertisement.Initialize("2877209");
    }

    public void voltaParaCasa()
    {
        PlayerPrefs.SetInt("saidaScene", 500);
        Application.LoadLevel("homeInside");
    }

    public void ShowRewardedAd()
    {
        if (Advertisement.IsReady("adsMorte"))
        {
            var options = new ShowOptions { resultCallback = HandleShowResult };
            Advertisement.Show("adsMorte", options);
        }
    }

    private void HandleShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                Debug.Log("The ad was successfully shown.");
                //
                // YOUR CODE TO REWARD THE GAMER
                // Give coins etc.

                controleMobParaReward.GetComponent<controleMOB>().revivePorVideo();

                break;
            case ShowResult.Skipped:
                Debug.Log("The ad was skipped before reaching the end.");
                break;
            case ShowResult.Failed:
                Debug.LogError("The ad failed to be shown.");
                break;
        }
    }*/
}
