using System;

public interface IRewardedAdsManager : IInterstitialAdsManager
{
    public Action<int> OnReward { get; set; }
}
