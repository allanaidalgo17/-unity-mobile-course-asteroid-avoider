using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour, IUnityAdsListener
{
    [SerializeField] private bool testMode = true;

    public static AdManager Instance;

    private GameOverHandler gameOverHandler;

    private const string GAME_ID = "4672817";
    private const string AD_PLACEMENT_ID = "rewardedVideo";

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            Advertisement.AddListener(this);
            Advertisement.Initialize(GAME_ID, testMode);
        }
    }

    public void ShowAd(GameOverHandler gameOverHandler)
    {
        this.gameOverHandler = gameOverHandler;

        Advertisement.Show(AD_PLACEMENT_ID);
    }

    public void OnUnityAdsDidError(string message)
    {
        Debug.Log($"Unity Ads Error: {message}");
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        switch (showResult)
        {
            case ShowResult.Finished:
                gameOverHandler.Continue();
                break;
            case ShowResult.Skipped:
                break;
            case ShowResult.Failed:
                Debug.LogWarning($"Unity Ads Falied: {placementId}");
                break;
        }
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        Debug.Log($"Unity Ads Started: {placementId}");
    }

    public void OnUnityAdsReady(string placementId)
    {
        Debug.Log($"Unity Ads Ready: {placementId}");
    }
}
