using System;


public class AppLovinRewardedAdsManager : IRewardedAdsManager
{
    private MaxSdk.AdInfo _currentAdInfo = null;

    public Action OnLoaded { get; set; }
    public Action OnClosed { get; set; }
    public Action<int> OnReward { get; set; }

    public void SetCallbacks()
    {
        MaxSdkCallbacks.Rewarded.OnAdLoadedEvent += OnRewardedLoadedEvent;
        MaxSdkCallbacks.Rewarded.OnAdLoadFailedEvent += OnRewardedFailedEvent;
        MaxSdkCallbacks.Rewarded.OnAdDisplayFailedEvent += OnRewardedFailedToDisplayEvent;
        MaxSdkCallbacks.Rewarded.OnAdDisplayedEvent += OnRewardedDisplayedEvent;
        MaxSdkCallbacks.Rewarded.OnAdClickedEvent += OnRewardedClickedEvent;
        MaxSdkCallbacks.Rewarded.OnAdHiddenEvent += OnRewardedDismissedEvent;
        MaxSdkCallbacks.Rewarded.OnAdReceivedRewardEvent += OnRewardedReceivedRewardEvent;
        MaxSdkCallbacks.Rewarded.OnAdRevenuePaidEvent += OnRewardedRevenuePaidEvent;
    }


    public void Load(string id)
    {
        MaxSdk.LoadRewardedAd(id);
    }

    public bool IsLoaded(string id)
    {
        return MaxSdk.IsRewardedAdReady(id);
    }

    public string GetNetworkName(string id)
    {
        if (_currentAdInfo != null)
        {
            return _currentAdInfo.NetworkName;
        }
        else return null;
    }

    public void Show(string id)
    {
        MaxSdk.ShowRewardedAd(id);
    }

    private void OnRewardedLoadedEvent(string id, MaxSdkBase.AdInfo info)
    {
        Console.WriteLine("Rewarded loaded");
        _currentAdInfo = info;

        OnLoaded?.Invoke();
    }

    private void OnRewardedFailedEvent(string id, MaxSdkBase.ErrorInfo error)
    {
        Console.WriteLine("Rewarded failed to load with error code: " + error.Code);
    }

    private void OnRewardedFailedToDisplayEvent(string id, MaxSdkBase.ErrorInfo error, MaxSdkBase.AdInfo info)
    {
        Console.WriteLine("Rewarded failed to display with error code: " + error.Code);
    }

    private void OnRewardedDisplayedEvent(string id, MaxSdkBase.AdInfo info)
    {
        Console.WriteLine($"Rewarded watched");
    }

    private void OnRewardedClickedEvent(string id, MaxSdkBase.AdInfo info)
    {
        Console.WriteLine($"Rewarded clicked");
    }

    private void OnRewardedDismissedEvent(string id, MaxSdkBase.AdInfo info)
    {
        Console.WriteLine("Rewarded closed");

        OnClosed?.Invoke();
    }

    private void OnRewardedReceivedRewardEvent(string id, MaxSdkBase.Reward reward, MaxSdkBase.AdInfo info)
    {
        Console.WriteLine($"Rewarded received reward");

        OnReward?.Invoke(reward.Amount);
    }

    private void OnRewardedRevenuePaidEvent(string id, MaxSdkBase.AdInfo info)
    {
        Console.WriteLine($"Rewarded revenue paid");
    }

    

    
}
