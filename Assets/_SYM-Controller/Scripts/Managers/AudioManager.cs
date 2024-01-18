using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SYM
{
    public class AudioManager : MonoBehaviour
    {
        #region Variables
        private AudioSource audiosos;
        #endregion

        #region Singleton
        private static AudioManager instance;
        public static AudioManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<AudioManager>();
                    if (instance == null)
                    {
                        GameObject obj = new GameObject();
                        obj.name = typeof(AudioManager).Name;
                        instance = obj.AddComponent<AudioManager>();
                    }
                }
                return instance;
            }
        }

        void Awake()
        {

            if (instance == null)
            {
                instance = this as AudioManager;
            }
            else
            {
                Destroy(gameObject);
            }
        }
        #endregion

        void Init()
        {
            audiosos = GetComponent<AudioSource>();
        }
        // Start is called before the first frame update
        void Start()
        {
            GameManager.Instance.InitBehaviour += Init;

        }

        public void PlayClip(AudioClip clip)
        {
            audiosos.PlayOneShot(clip);
        }
    }
}
