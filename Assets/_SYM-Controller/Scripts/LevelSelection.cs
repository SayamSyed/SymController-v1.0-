using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour
{
    public List<Modes> Modes = new List<Modes>();
    private Button[] allLevels;
    private GameObject[] locks;
    public Button startBtn,unlockLevels;
    public GameObject loading;
    private Modes currentMod;

    private void Start()
    {
        LoadModeXLevels();
        OnInit();
    }
    private void LoadModeXLevels() 
    {
        for (int i = 0; i < Modes.Count; i++)
        {
            Modes[i].parent.SetActive(false);
        }
        
        currentMod = Modes[PlayerPrefs.GetInt("ModeSelected",0)];
        currentMod.parent.SetActive(true);
        allLevels = null;
        allLevels = currentMod.allLevels;
        locks = null;
        locks = currentMod.locks;
        print("Current mode selected is: "+ currentMod.modeNum);
    }
    public void OnInit()
    {
        //refreshes all prefs
        if (!PlayerPrefs.HasKey("Mode" + PlayerPrefs.GetInt("ModeSelected")+ "UnlockedLevels"))
        {
            PlayerPrefs.SetInt("Mode" + PlayerPrefs.GetInt("ModeSelected")+ "UnlockedLevels", 1);
            Debug.Log("Mode: "+ PlayerPrefs.GetInt("ModeSelected") + ": Levels Initialized!");
        }
        PlayerPrefs.SetInt("TotalLevels", allLevels.Length);

        //refreshes all levels
        for (int i = 0; i < allLevels.Length; i++)
        {
            allLevels[i].interactable = false;
            locks[i].SetActive(true);
        }
        for (int i = 0; i < PlayerPrefs.GetInt("Mode" + PlayerPrefs.GetInt("ModeSelected")+ "UnlockedLevels"); i++)
        {
            allLevels[i].interactable = true;
            locks[i].SetActive(false);
        }

        startBtn.interactable = false;
    }

    public void SelectLevel(int num)
    {
        PlayerPrefs.SetInt("SelectedLevel", num);
        PlayerPrefs.Save();

        for (int i = 0; i < allLevels.Length; i++)
        {
            allLevels[i].GetComponent<DOTweenAnimation>().DOPauseAllById("selected");
        }
        allLevels[num].GetComponent<DOTweenAnimation>().DORestartById("selected");

        startBtn.GetComponent<DOTweenAnimation>().DORestartById("shake");
        startBtn.interactable = true;
    }

    public void LoadScene() 
    {
        StartCoroutine(LoadSceneWithName());
    }
    IEnumerator LoadSceneWithName() 
    {
        loading.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(currentMod.targetScene);
    }
    public void BackButton() 
    {
        SceneManager.LoadScene("ModeSelection");
    }
    public void LevelsPurchasedSuccess()
    {
        PlayerPrefs.SetInt("Mode0UnlockedLevels", 10);
        PlayerPrefs.SetInt("Mode1UnlockedLevels", 10);

        unlockLevels.gameObject.SetActive(false);
        OnInit();
    }

}
