using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

namespace SYM
{
    public class CameraManager : MonoBehaviour
    {
        #region Variables
        public CinemachineBrain brain;
        //public GameObject carCamera; // CAR CODE DRIVE
        #endregion

        #region Singleton
        private static CameraManager instance;
        public static CameraManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<CameraManager>();
                    if (instance == null)
                    {
                        GameObject obj = new GameObject();
                        obj.name = typeof(CameraManager).Name;
                        instance = obj.AddComponent<CameraManager>();
                    }
                }
                return instance;
            }
        }

        void Awake()
        {
            if (instance == null)
            {
                instance = this as CameraManager;
                //DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
        #endregion

        //public void Drive(bool state)  // CAR CODE DRIVE
        //{
        //    carCamera.SetActive(state);
        //}

       
    }
}
