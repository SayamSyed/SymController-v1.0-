using SYM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSymController : MonoBehaviour
{
    public GameObject Enviornment;
    //public GameObject loading;
    public bool Testing = true;

    private void Awake()
    {
        SceneManager.LoadSceneAsync("SymController", LoadSceneMode.Additive);
        BGM();
        Enviornment.SetActive(true);

        StartCoroutine(LoadControllerAsync());
    }

    IEnumerator LoadControllerAsync() 
    {

        yield break;
    }
    private void BGM()
    {
        if (Testing)
            return;

        GameObject bgm = GameObject.FindGameObjectWithTag("BGM");
        bgm.GetComponent<AudioSource>().volume = 0;
    }
    public void _LoadScene(string str) { SceneManager.LoadScene(str); }

}
