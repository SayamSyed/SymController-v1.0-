using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ModeSelection : MonoBehaviour
{
    public GameObject loading;

    public void ModeNum(int num)
    {
        loading.SetActive(true);
        PlayerPrefs.SetInt("ModeSelected", num);
        PlayerPrefs.Save();
        StartCoroutine("LoadLevelSelection");
    }
    public void LoadMiniGame() 
    {
        loading.SetActive(true);
        SceneManager.LoadScene(("MiniGameplay"));
    }
    IEnumerator LoadLevelSelection() 
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(("LevelSelection"));
    }
    public void BackButton() 
    {
        SceneManager.LoadScene("CharacterSelection");
    }
    public void NativeAdwithLink()
    {
        Application.OpenURL("https://play.google.com/store/apps/details?id=com.nag.crazy.goat.simulator");
    }
}
