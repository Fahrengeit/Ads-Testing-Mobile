using System;

public class AppLovinInterstitialAdsManager : IInterstitialAdsManager
{
    private MaxSdk.AdInfo _currentAdInfo = null;

    public Action OnLoaded { get; set; }
    public Action OnClosed { get; set; }

    public void SetCallbacks()
    {
        MaxSdkCallbacks.Interstitial.OnAdLoadedEvent += OnInterstitialLoadedEvent;
        MaxSdkCallbacks.Interstitial.OnAdLoadFailedEvent += OnInterstitialFailedEvent;
        MaxSdkCallbacks.Interstitial.OnAdDisplayFailedEvent += OnInterstitialFailedToDisplayEvent;
        MaxSdkCallbacks.Interstitial.OnAdHiddenEvent += OnInterstitialDismissedEvent;
        MaxSdkCallbacks.Interstitial.OnAdRevenuePaidEvent += OnInterstitialRevenuePaidEvent;
        MaxSdkCallbacks.Interstitial.OnAdDisplayedEvent += OnInterstitialDisplayedEvent;
        MaxSdkCallbacks.Interstitial.OnAdClickedEvent += OnInterstitialClickedEvent;
    }


    public void Load(string id)
    {
        MaxSdk.LoadInterstitial(id);
    }

    public bool IsLoaded(string id)
    {
        return MaxSdk.IsInterstitialReady(id);
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
        MaxSdk.ShowInterstitial(id);
    }

    private void OnInterstitialLoadedEvent(string id, MaxSdkBase.AdInfo info)
    {
        Console.WriteLine("Interstitial loaded");
        _currentAdInfo = info;

        OnLoaded?.Invoke();
    }

    private void OnInterstitialFailedEvent(string id, MaxSdkBase.ErrorInfo error)
    {
        Console.WriteLine("Interstitial failed to load with error code: " + error.Code);
    }

    private void OnInterstitialFailedToDisplayEvent(string id, MaxSdkBase.ErrorInfo error, MaxSdkBase.AdInfo info)
    {
        Console.WriteLine("Interstitial failed to display with error code: " + error.Code);
    }

    private void OnInterstitialDismissedEvent(string id, MaxSdkBase.AdInfo info)
    {
        Console.WriteLine("Interstitial closed");

        OnClosed?.Invoke();
    }

    private void OnInterstitialRevenuePaidEvent(string id, MaxSdkBase.AdInfo info)
    {
        Console.WriteLine($"Interstitial revenue paid");
    }

    private void OnInterstitialDisplayedEvent(string id, MaxSdkBase.AdInfo info)
    {
        Console.WriteLine($"Interstitial watched");
    }

    private void OnInterstitialClickedEvent(string id, MaxSdkBase.AdInfo info)
    {
        Console.WriteLine($"Interstitial clicked");
    }
}
