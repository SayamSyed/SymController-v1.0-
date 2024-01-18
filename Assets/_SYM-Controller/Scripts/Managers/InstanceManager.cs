using UnityEngine;

namespace SYM { 
public class InstanceManager : MonoBehaviour
{
        [SerializeField] AudioSource gameplayMusic;
        #region Singleton
    private static InstanceManager instance;
    public static InstanceManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<InstanceManager>();
                if (instance == null)
                {
                    GameObject obj = new GameObject();
                    obj.name = typeof(InstanceManager).Name;
                    instance = obj.AddComponent<InstanceManager>();
                }
            }
            return instance;
        }
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this as InstanceManager;
            //DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
        #endregion
        
        int num = 0;

        public void GiveHint(string str) 
        {
            UI_Manager.Instance.GiveHint(str);
        }
        public void LerpToTransform(Transform t)
        {
            GameManager.Instance.LerpToTransform(t);
        }
        public void GameplayMusicState(bool state) 
        {
            int temp = BoolToInt(state);
            gameplayMusic.volume = temp;  
        }
        int BoolToInt(bool val) 
        {
            if(val)
                return 1;
            else
                return 0;
        }
        //public void Drive(bool state)         // CAR CODE DRIVE
        //{
        //    GameManager.Instance.Drive(state);
        //}
        public void SetAction(string str) 
        {
            GameManager.Instance.player.GetComponent<ActionTrigger>().SetAction(str);
        }
        public void SkipLevel() 
        {
            LevelManager.Instance._LevelComplete();
        }
        public void JoystickandRun(bool state)
        {
            UI_Manager.Instance.JoystickandRun(state);
        }
        public void ShowPFX(int i) 
        {
            ParticlesFX_Manager.Instance.ShowPFX(i); 
        }
        public void TeleportPlayer(Transform t) 
        {
            GameManager.Instance.TeleportPlayer(t);
        }
    }
}
