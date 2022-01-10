using System;

public interface IAdInitializer
{
    public void Initialize(string key);

    public Action OnInitialized { get; set; }
}

public class AppLovinInitializer : IAdInitializer
{
    public Action OnInitialized { get; set; }

    public void Initialize(string key)
    {
        MaxSdkCallbacks.OnSdkInitializedEvent += Initialized;

        MaxSdk.SetSdkKey(key);
        MaxSdk.InitializeSdk();

    }

    private void Initialized(MaxSdk.SdkConfiguration config)
    {
        Console.WriteLine("MAX SDK Initialized");

        OnInitialized?.Invoke();
    }
}
