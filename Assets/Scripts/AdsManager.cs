using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour , IUnityAdsLoadListener, IUnityAdsShowListener
{
    [SerializeField] private Behaviour _player;
    [SerializeField] private TitleScreen _titleScreen;
    private int _ad;
    void Start()
    {
        Advertisement.Initialize("5201745");
        //Advertisement.AddListener(this);
        Advertisement.Load("Rewarded_Android", this);
    }

    void Update()
    {
        
    }

    public void PlayAd()
    {
        //if(Advertisement.IsReady("Interstitial_Android") && _ad%3 == 0)
        //{
            Advertisement.Show("Interstitial_Android", this);
        //}
        //_ad++;
    }

    public void PlayRewardAd()
    {
        //if (Advertisement.IsReady("Rewarded_Android"))
            Advertisement.Show("Rewarded_Android", this);
        //else
            //Debug.Log("rewarded ad not ready");
    }

    public void OnUnityAdsReady(string placementId)
    {
        Debug.Log("ads ready");
    }

    public void OnUnityAdsDidError(string message)
    {
        Debug.Log("ads not ready"+ message);
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        Debug.Log("video started");
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (placementId == "Rewarded_Android" && showResult == ShowResult.Finished)
        {
            _player.AddDblCoins();
            _titleScreen.Retry();
        }
    }

    public void OnUnityAdsAdLoaded(string placementId)
    {
        //throw new System.NotImplementedException();
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsShowStart(string placementId)
    {
    }

    public void OnUnityAdsShowClick(string placementId)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        if (placementId == "Rewarded_Android" && showCompletionState == UnityAdsShowCompletionState.COMPLETED)
        {
            _player.AddDblCoins();
            _titleScreen.Retry();
        }
    }
}
