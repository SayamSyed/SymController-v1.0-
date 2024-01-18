using RootMotion.FinalIK;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SYM {

    public class IK_MakeChild : MonoBehaviour
    {
        private Animator playerAnim;
        public bool makeChild, makeChildOfBone;
        public HumanBodyBones bone;

        public void _MakeChild(bool state)
        {
            if (!state)
            {
                UnchildGameobject();
                return;
            }
            playerAnim = GameManager.Instance.player;

            if (makeChild)
                transform.parent = playerAnim.transform;

            if (makeChildOfBone)
                transform.parent = playerAnim.GetBoneTransform(bone).transform;

            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
        }
        private void UnchildGameobject()
        {
            transform.parent = null;
        }

    } 
}
