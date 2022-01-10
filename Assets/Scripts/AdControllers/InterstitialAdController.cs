using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class InterstitialAdController : MonoBehaviour
{
    private IInterstitialAdsManager _adsManager;

    [SerializeField]
    private string AdUnitId;
    
    public Button LoadButton;
    public Text LoadStatus;
    public Button ShowButton;
    public Text ShowInfo;

    public GameObject StatusWindow;

    private void Awake()
    {
        if (LoadButton == null || LoadStatus == null || ShowButton == null || ShowInfo == null)
            throw new NullReferenceException("UI fields must be assigned");

        LoadButton.onClick.AddListener(LoadAd);
        ShowButton.onClick.AddListener(ShowAd);

        LoadButton.interactable = false;
        ShowButton.interactable = false;

        LoadStatus.text = "Not Loaded";
        ShowInfo.text = "No Ad";
    }

    public virtual void Initialize(IInterstitialAdsManager adsManager)
    {
        _adsManager = adsManager;
        _adsManager.SetCallbacks();
        _adsManager.OnLoaded += OnLoadedAd;
        _adsManager.OnClosed += OnClosedAd;
        LoadButton.interactable = true;
    }

    private void LoadAd()
    {
        LoadStatus.text = "Loading...";
        _adsManager.Load(AdUnitId);

        // For some reason in this version of SDK ads events don't work in Editor, that's why I have to check "Loaded" state in other way
#if UNITY_EDITOR
        StartCoroutine(LoadingAd(AdUnitId));
#endif
    }

    private IEnumerator LoadingAd(string id)
    {
        while (!_adsManager.IsLoaded(id))
        {
            yield return null;
        }

        OnLoadedAd();
    }

    private void OnLoadedAd()
    {
        LoadStatus.text = "Loaded";

        ShowButton.interactable = true;

        ShowInfo.text = _adsManager.GetNetworkName(AdUnitId) ?? "No Ad??";
    }

    private void ShowAd()
    {
        _adsManager.Show(AdUnitId);
    }

    private void OnClosedAd()
    {
        StatusWindow?.SetActive(true);
        ResetAd();
    }

    private void ResetAd()
    {
        ShowButton.interactable = false;
        LoadStatus.text = "Not Loaded";
        ShowInfo.text = "No Ad";
    }

}
