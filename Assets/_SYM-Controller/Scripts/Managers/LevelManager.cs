using SYM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public LevelClass[] levels;
    private GameObject player;
    private int selectedLevel;

    #region Singleton
    private static LevelManager instance;
    public static LevelManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<LevelManager>();
                if (instance == null)
                {
                    GameObject obj = new GameObject();
                    obj.name = typeof(LevelManager).Name;
                    instance = obj.AddComponent<LevelManager>();
                }
            }
            return instance;
        }
    }

    void Awake()
    {
        DeactivateAllLevels();
        if (instance == null)
        {
            instance = this as LevelManager;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion
    private void Start()
    {
        UI_Manager.Instance.loadingPanel.SetActive(true);
        GameManager.Instance.InitBehaviour += Init;
    }
    private void DeactivateAllLevels()
    {
        for (int i = 0; i < levels.Length; i++)
        {
            levels[i].level.gameObject.SetActive(false);
        }
    }
    public void Init()
    {
        selectedLevel = PlayerPrefs.GetInt("SelectedLevel", 0);
        player = GameManager.Instance.player.gameObject;
        LoadSelectedLevel(selectedLevel);
        UI_Manager.Instance.loadingPanel.SetActive(false);
        //FbAnalytics.Instance.LogEvent("UserStarted_LevelNo_" + selectedLevel);
    }
    
    void LoadSelectedLevel(int lvl) 
    {
        for (int i = 0; i < levels.Length; i++)
        {
            levels[i].level.gameObject.SetActive(false);

            if(levels[i].index == lvl) 
            {
                levels[i].level.gameObject.SetActive(true);
                AlignPlayer(levels[i].level.position); 
                player.GetComponent<CharacterController>().enabled = true;
                if (levels[i].level.OnInit != null) levels[i].level.OnInit.Invoke();
            }
        }
    }
    void AlignPlayer(Transform t) 
    {
        player.transform.localPosition = t.localPosition;
        player.transform.localRotation = t.localRotation;
    }

    //void SetCarPosition(Transform t) 
    //{
    //    if (t == null) 
    //    {
    //        playerCar.SetActive(false);
    //        return;
    //    }

    //    playerCar.transform.localPosition = t.localPosition;
    //    playerCar.transform.localRotation = t.localRotation;
    //}
    public void _LevelFail() 
    {
        UI_Manager.Instance.LevelFail();
        //FbAnalytics.Instance.LogEvent("level_no_" + selectedLevel+"_Failed");
        if (levels[selectedLevel].level.OnLevelFail != null) levels[selectedLevel].level.OnLevelFail.Invoke();
    }
    public void _LevelComplete() 
    {
        UI_Manager.Instance.LevelComplete();
        //FbAnalytics.Instance.LogEvent("level_no_" + selectedLevel+"_completed");
        
        if (levels[selectedLevel].level.OnLevelComplete != null) levels[selectedLevel].level.OnLevelComplete.Invoke();
    }
}
