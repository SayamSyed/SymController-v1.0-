using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

namespace SYM {
    public class TimelineController : MonoBehaviour
    {
        public PlayableDirector Director;

        public void PlayTimeline()
        {
            Director.Play();
            TimelineBindings();
        }
        public void TimelineBindings()
        {
            foreach (var playableAssetOutput in Director.playableAsset.outputs)
            {
                if (playableAssetOutput.streamName == "Camera")
                {
                    Director.SetGenericBinding(playableAssetOutput.sourceObject, CameraManager.Instance.brain);
                }
            }
        }


    }
}
