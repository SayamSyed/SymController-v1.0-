using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class Splash : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AdsInit();
        DOVirtual.DelayedCall(8f, () => { LoadGame(); });
    }

    void LoadGame() 
    {
        SceneManager.LoadScene("MainMenu");
    }
    void AdsInit() 
    {
        //GSSAdsManager.InitializeAds(true,() => { Debug.Log("Splash + Ads initialized"); });
    }

}
