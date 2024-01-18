using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SYM
{
    public class TimelineManager : MonoBehaviour
    {
        #region Variables
        #endregion

        #region Singleton
        private static TimelineManager instance;
        public static TimelineManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<TimelineManager>();
                    if (instance == null)
                    {
                        GameObject obj = new GameObject();
                        obj.name = typeof(TimelineManager).Name;
                        instance = obj.AddComponent<TimelineManager>();
                    }
                }
                return instance;
            }
        }

        void Awake()
        {
            if (instance == null)
            {
                instance = this as TimelineManager;
                //DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
        #endregion

        public void TimelineState(bool state) 
        {
            UI_Manager.Instance.GameplayUIState(!state);
        }
    }
}
