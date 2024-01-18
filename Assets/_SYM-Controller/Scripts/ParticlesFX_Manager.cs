using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesFX_Manager : MonoBehaviour
{
    #region Variables
    public GameObject[] PFX;
    #endregion

    #region Singleton
    private static ParticlesFX_Manager instance;
    public static ParticlesFX_Manager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<ParticlesFX_Manager>();
                if (instance == null)
                {
                    GameObject obj = new GameObject();
                    obj.name = typeof(ParticlesFX_Manager).Name;
                    instance = obj.AddComponent<ParticlesFX_Manager>();
                }
            }
            return instance;
        }
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this as ParticlesFX_Manager;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion

    void Start()
    {
        DisableAllPFX();
    }

    public void ShowPFX(int index) 
    {
        PFX[index].SetActive(true);
        DOVirtual.DelayedCall(5f, () => { DisableAllPFX(); });
    }
    void DisableAllPFX() 
    {
        for (int i = 0; i < PFX.Length; i++)
        {
            PFX[i].SetActive(false);
        }
    }
}
