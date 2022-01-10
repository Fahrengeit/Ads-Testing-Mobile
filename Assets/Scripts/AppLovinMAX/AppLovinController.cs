using UnityEngine;
using UnityEngine.UI;

public class AppLovinController : MonoBehaviour
{
    private AppLovinInitializer _initializer;

    [SerializeField]
    private string MaxSdkKey;

    public InterstitialAdController InterstitialAdController;
    public RewardedAdController RewardedAdController;

    public Button InitializeButton;

    private bool _isInitialized;

    public void Awake()
    {
        _initializer = new AppLovinInitializer();
        InitializeButton.onClick.AddListener(Initialize);
    }

    private void Initialize()
    {
        if (!_isInitialized)
        {
            _initializer.Initialize(MaxSdkKey);
            _initializer.OnInitialized += Initialized;
            _isInitialized = true;
        }
    }

    private void Initialized()
    {
        InterstitialAdController.Initialize(new AppLovinInterstitialAdsManager());
        RewardedAdController.Initialize(new AppLovinRewardedAdsManager());
    }
}
