using UnityEngine;
using UnityEngine.UI;

public class RewardedAdController : InterstitialAdController
{
    private IRewardedAdsManager _rewardedAdsManager;

    public GameObject RewardedCounterWindow;
    public Text RewardedCounterText;
    private int _rewardCounter;

    public override void Initialize(IInterstitialAdsManager adsManager)
    {
        base.Initialize(adsManager);

        _rewardedAdsManager = adsManager as IRewardedAdsManager;

        _rewardedAdsManager.OnReward += OnReward;
    }

    private void OnReward(int amount)
    {
        _rewardCounter++;

        if (RewardedCounterWindow != null)
        {
            RewardedCounterWindow.SetActive(true);
            RewardedCounterText.text = $"Count: {_rewardCounter}";
        }
    }
}
