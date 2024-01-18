using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace SYM
{
    public class UI_Manager : MonoBehaviour
    {
        #region Variables
        [Space(10)]
        [Header("PlayerControls")]
        public CanvasGroup PlayerControls;
        public GameObject moveJoystick, runButton, jumpButton, trackPad, lookJoystick;
        public bool useLookJoystick;
        //[Space(10)]
        //[Header("PlayerCarControls")]     // CAR CODE DRIVE
        //public GameObject carControls;
        [Space(10)]
        [Header("Hint System")]
        [Space(10)]
        public GameObject hintPanel;
        public TextMeshProUGUI hintText;
        [Space(10)]
        [Header("Action & Loading")]
        public Button actionButton;
        public GameObject loadingPanel;
        [Space(10)]
        [Header("Gameplay Panels")]
        public GameObject pausePanel;
        public GameObject completePanel;
        public GameObject failPanel; 
        public GameObject rewardNotAvailableDialogue;
        [SerializeField] string[] sceneAgainstModeNum;
        private float targetAlpha;
        private bool lerpFade = false;
        #endregion

        #region Singleton
        private static UI_Manager instance;
        public static UI_Manager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<UI_Manager>();
                    if (instance == null)
                    {
                        GameObject obj = new GameObject();
                        obj.name = typeof(UI_Manager).Name;
                        instance = obj.AddComponent<UI_Manager>();
                    }
                }
                return instance;
            }
        }

        void Awake()
        {
            if (instance == null)
            {
                instance = this as UI_Manager;
                //DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
        #endregion

        // Start is called before the first frame update
        void Start()
        {
            GameManager.Instance.InitBehaviour += OnInit;
        }
        private void OnInit()
        {
            if (useLookJoystick)
                _UseLookJoystick(true);

            ActionButtonState(false);
        }
        private void Update()
        {
            if (lerpFade) 
            {
                PlayerControls.alpha = Mathf.MoveTowards(PlayerControls.alpha, targetAlpha, 1*Time.deltaTime);
            }

            //if (fraction < 1)
            //{
            //    fraction += Time.deltaTime * speed;
            //    transform.position = Vector3.Lerp(startPos, endPos, fraction);
            //    transform.localRotation = Quaternion.Lerp(startRot, endRot, fraction);
            //}
        }
        public void _UseLookJoystick(bool val)
        {
            trackPad.SetActive(!val);
            lookJoystick.SetActive(val);
        }
        
        public void GameplayUIState(bool state)
        {
            int temp = BoolToInt(state);

            targetAlpha = temp;
            PlayerControls.blocksRaycasts = state;
            //PlayerControls.alpha = temp;
            lerpFade = true;

        }
        public void ActionButtonState(bool state) 
        {
            actionButton.gameObject.SetActive(state);
        }
        int BoolToInt(bool val)
        {
            if (val)
                return 1;
            else
                return 0;
        }
        public void JoystickandRun(bool state) 
        {
            moveJoystick.SetActive(state);
            runButton.SetActive(state);
        }
        //public void Drive(bool state)         // CAR CODE DRIVE
        //{
        //    moveJoystick.SetActive(!state);
        //    lookJoystick.SetActive(!state);
        //    runButton.SetActive(!state);
        //    carControls.SetActive(state);
        //}
        public void GiveHint(string str)
        {
            hintText.text = str;
            hintPanel.GetComponent<DOTweenAnimation>().DORestartAllById("hintOpenTween");
        }
        public void ShowLastHint() 
        {
            hintPanel.GetComponent<DOTweenAnimation>().DORestartAllById("hintOpenTween");
        }

        #region GameStates
        public void PauseGame(bool state) 
        {
            int val = BoolToInt(!state);
            pausePanel.SetActive(state);
            InstanceManager.Instance.GameplayMusicState(!state);
            GameManager.Instance.Timescale(val);
        }
        public void LevelComplete() 
        {
            completePanel.SetActive(true);
        }
        public void LevelFail() 
        {
            failPanel.SetActive(true);
        }
        public void GoToHome()
        {
            loadingPanel.SetActive(true);
            GameManager.Instance.Timescale(1);
            SceneManager.LoadScene("MainMenu");
        }
        public void RewardedAdNotAvailable() 
        {
            rewardNotAvailableDialogue.SetActive(true);
        }
        public void ResumeGame()
        {
            PauseGame(false);
        }
        public void RestartGame()
        {
            loadingPanel.SetActive(true);
            GameManager.Instance.Timescale(1);

            SceneManager.LoadScene(sceneAgainstModeNum[PlayerPrefs.GetInt("ModeSelected")]);
        }
        void LoadRandomLevel()
        {
            int rand = Random.Range(0, 10);
            PlayerPrefs.SetInt("SelectedLevel", rand);
            SceneManager.LoadScene(sceneAgainstModeNum[PlayerPrefs.GetInt("ModeSelected")]);
            Debug.Log("RANDOOOM LEVELEVLEVLELVEL!!!!!!!!!!!");
        }
        public void NextLevel()
        {
            if (PlayerPrefs.GetInt("Mode" + PlayerPrefs.GetInt("ModeSelected") + "UnlockedLevels") >= PlayerPrefs.GetInt("TotalLevels"))
            {
                LoadRandomLevel();
                return;
            }
            if ((PlayerPrefs.GetInt("SelectedLevel") + 1) == PlayerPrefs.GetInt("Mode" + PlayerPrefs.GetInt("ModeSelected") + "UnlockedLevels"))
            {
                PlayerPrefs.SetInt("Mode" + PlayerPrefs.GetInt("ModeSelected") + "UnlockedLevels", PlayerPrefs.GetInt("Mode" + PlayerPrefs.GetInt("ModeSelected") + "UnlockedLevels") + 1);
                PlayerPrefs.SetInt("SelectedLevel", (PlayerPrefs.GetInt("Mode" + PlayerPrefs.GetInt("ModeSelected") + "UnlockedLevels") - 1));
                print("Loading new level");
            }
            if ((PlayerPrefs.GetInt("SelectedLevel") + 1) < PlayerPrefs.GetInt("Mode" + PlayerPrefs.GetInt("ModeSelected") + "UnlockedLevels"))
            {
                PlayerPrefs.SetInt("SelectedLevel", (PlayerPrefs.GetInt("SelectedLevel") + 1));
                print("Loading next old level");
            }
            loadingPanel.gameObject.SetActive(true);
            SceneManager.LoadScene(sceneAgainstModeNum[PlayerPrefs.GetInt("ModeSelected", 0)]);
        }
        #endregion
    }
}
