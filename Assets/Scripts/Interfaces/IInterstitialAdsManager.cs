using System;

public interface IInterstitialAdsManager
{
    public void SetCallbacks();

    public void Load(string id);

    public bool IsLoaded(string id);

    public void Show(string id);

    public string GetNetworkName(string id);

    public Action OnLoaded { get; set; }

    public Action OnClosed { get; set; }
}
