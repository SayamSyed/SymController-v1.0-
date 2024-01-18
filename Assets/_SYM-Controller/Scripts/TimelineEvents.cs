using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SYM
{
    public class TimelineEvents : MonoBehaviour
    {
        public GameObject timelineAssets;
        public AudioSource gameplayMusic;

        public UnityEvent OnTimelinePlay, OnTimelineExit;

        private void OnEnable()
        {
            timelineAssets.SetActive(true);
            TimelineManager.Instance.TimelineState(true);
            GameManager.Instance.playerMesh.SetActive(false);

            if (gameplayMusic != null)
                gameplayMusic.mute=true;

            if (OnTimelinePlay != null)
                OnTimelinePlay.Invoke();
        }
        private void OnDisable()
        {
            timelineAssets.SetActive(false);
            TimelineManager.Instance.TimelineState(false);
            GameManager.Instance.playerMesh.SetActive(true);

            if (gameplayMusic != null)
                gameplayMusic.mute = false;

            if (OnTimelineExit != null) { OnTimelineExit.Invoke(); Debug.Log("TimelineExitEvent"); }
                
        }

    }
}