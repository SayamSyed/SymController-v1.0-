using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour/*, InAppPurchasesCallBacks*/

{
    bool adsPurchase;
    void Start()
    {
        ShowBanner();
    }
    private void OnEnable()
    {
        GameObject bgm = GameObject.FindGameObjectWithTag("BGM");
        bgm.GetComponent<AudioSource>().volume = .25f;
        //StartCoroutine(SyncPurchases());
    }
    private void OnDisable()
    {
        //StopCoroutine(SyncPurchases());
    }

    public void LoadSelection() 
    {
        SceneManager.LoadScene("ModeSelection");
        //FbAnalytics.Instance.LogEvent("MainMenu_PlayBtnClick");
    }
    public void ShowInterstitial() 
    {
        //GSSAdsManager.ShowInterstitialAd();
    }
    void ShowBanner() 
    {
        //if (AppOpenAdManager.Instance.bannerShouldShow || GameConstants.BackFromGameplay) 
        //{
        //    GSSAdsManager.ShowBannerAd(GoogleMobileAds.Api.AdSize.SmartBanner, GoogleMobileAds.Api.AdPosition.Top); 
        //}
    }
    public void RateUs()
    {
        Application.OpenURL("https://play.google.com/store/apps/details?id=com.nag.high.school.summer.vacation.fun");
    }
    public void MoreApps()
    {
        Application.OpenURL("https://play.google.com/store/apps/dev?id=5492798222698967139");
    }
    public void RemoveAds() 
    {
        //InAppPurchases.PurchaseItem(InAppPurchases.instance.SKUS[0].ID, this);
    }

    //public bool PurchaseSuccessful(string id)
    //{
    //    if (id.Equals(InAppPurchases.instance.SKUS[0].ID))
    //    {
    //        adsPurchase = true;
    //        GSSAdsManager.removeAds();
    //    }
    //    return adsPurchase;
    //}

    //public void PurchaseFailed(string id)
    //{
    //    throw new System.NotImplementedException();
    //}

    //public IEnumerator SyncPurchases()
    //{
    //    while (true)
    //    {
    //        yield return new WaitForSeconds(10);
    //        Debug.Log("GSS Plugin Waiting for in app process!!!");
    //        if (InAppPurchases.IsInitialized())
    //        {
    //            InAppPurchases.instance.SyncCompletedPurchases(this);
    //            yield return null;
    //        }
    //    }
    //}
}
