using RootMotion.FinalIK;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SYM
{
    public class InteractionIK : MonoBehaviour
    {
        #region Variables
        public bool Manual = true;
        public bool isPlayer = true;

        public bool effectPosition = true;
        public bool effectRotation = true;

        public FullBodyBipedIK Body;

        public Transform rightHand, leftHand;
        public HandPoser rightHandPoser, leftHandPoser;
        public Transform rightHandPoseTransform, leftHandPoseTransform;

        private Vector3 DefaultPos;
        private Quaternion DefaultRot;

        public IK_MakeChild makeChild;
        #endregion

        private void Awake()
        {
            DefaultPos = transform.position;
            DefaultRot = transform.rotation;
        }
        private void Start()
        {
            if (!Manual)
                _SetIK(true);
        }

        public void _SetIK(bool state) 
        {
            if (isPlayer && !Body)
                Body = GameManager.Instance.player.GetComponentInChildren<FullBodyBipedIK>();

            int weight;

            if (state)
                weight = 1;
            else
                weight = 0;

            makeChild._MakeChild(state);

            if (leftHand) 
            {
                Body.solver.leftHandEffector.target = leftHand.transform;

                if (effectPosition)
                    Body.solver.leftHandEffector.positionWeight = weight;

                if (effectRotation)
                    Body.solver.leftHandEffector.rotationWeight = weight;
            }

            if (rightHand)
            {
                Body.solver.rightHandEffector.target = rightHand.transform;

                if (effectPosition)
                    Body.solver.rightHandEffector.positionWeight = weight;

                if (effectRotation)
                    Body.solver.rightHandEffector.rotationWeight = weight;
            }

            if (leftHandPoser) 
            {
                if (state)
                    leftHandPoser.poseRoot = leftHandPoseTransform;
                else
                    leftHandPoser.poseRoot = null;

                leftHandPoser.enabled = state;
            }

            if (rightHandPoser)
            {
                if (state)
                    rightHandPoser.poseRoot = rightHandPoseTransform;
                else
                    rightHandPoser.poseRoot = null;

                rightHandPoser.enabled = state;
            }

        }

        public void Reset()
        {
            _SetIK(false);

            transform.position = DefaultPos;
            transform.rotation = DefaultRot;
        }

    }
}
