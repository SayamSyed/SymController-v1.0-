using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SYM
{
    public class GameManager : MonoBehaviour
    {
        public delegate void InitAllBehaviour();
        public event InitAllBehaviour InitBehaviour;
        #region Variables
        public Animator player;
        public GameObject playerMesh;
        //public GameObject playerCar; // CAR CODE DRIVE
        public bool isInitialized = false;
        #endregion


        #region Singleton
        private static GameManager instance;
        public static GameManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<GameManager>();
                    if (instance == null)
                    {
                        GameObject obj = new GameObject();
                        obj.name = typeof(GameManager).Name;
                        instance = obj.AddComponent<GameManager>();
                    }
                }
                return instance;
            }
        }

        void Awake()
        {
            if (instance == null)
            {
                instance = this as GameManager;
            }
            else
            {
                Destroy(gameObject);
            }
        }
        #endregion
        private void Start()
        {
            player.GetComponent<CharacterController>().enabled = false;
            isInitialized = true;
            //InitBehaviour();
            StartCoroutine(InitScriptBehavious());
            GameConstants.BackFromGameplay = true;
        }
        IEnumerator InitScriptBehavious() 
        {
            yield return new WaitForSeconds(1f);
            InitBehaviour();
        }
        public void Timescale(int val)
        {
            Time.timeScale = val;
        }
        public void SkipLevel() 
        {
            InstanceManager.Instance.SkipLevel();
        }
        public void TeleportPlayer(Transform t)
        {
            StartCoroutine(TeleportPlr(t));
        }
        IEnumerator TeleportPlr(Transform t) 
        {
            player.GetComponent<CharacterController>().enabled = false;
            yield return new WaitForSeconds(.5f);
            player.gameObject.transform.localPosition = t.localPosition;
            player.GetComponent<CharacterController>().enabled = true;
            player.gameObject.transform.localRotation = t.localRotation;
            Debug.Log("PLAYER TELEPORTED to: " + t.localPosition);
        }
        public void LerpToTransform(Transform t) 
        {
            player.GetComponent<SymFx>().LerpToTransform(t);
        }

        //public void Drive(bool state) // CAR CODE DRIVE
        //{
        //    playerMesh.SetActive(!state);
        //    playerCar.SetActive(state);
        //    UI_Manager.Instance.Drive(state);
        //    CameraManager.Instance.Drive(state);
        //}

        #region GSS Ads
        public void ShowInterstitial()
        {
            //GSSAdsManager.ShowInterstitialAd();
        }
        public void ShowBanner()
        {
            //GSSAdsManager.ShowBannerAd(GoogleMobileAds.Api.AdSize.SmartBanner, GoogleMobileAds.Api.AdPosition.Top);
        }
        public void ShowBigBanner()
        {
            //GSSAdsManager.ShowRectBanner(GoogleMobileAds.Api.AdSize.MediumRectangle, GoogleMobileAds.Api.AdPosition.BottomRight);
        }
        public void RewardedSkipLevel() 
        {
            //GSSAdsManager.ShowRewardedAd(SkipLevel, null);
        }

        public void HideBigBanner() 
        {
            //GSSAdsManager.HideLargeBanner();
        }
        public void HideBanner()
        {
            //GSSAdsManager.HideBannerAd();
        }
        public void RewardedNADialogue() 
        {
            UI_Manager.Instance.RewardedAdNotAvailable();
        }
        #endregion

    }
}