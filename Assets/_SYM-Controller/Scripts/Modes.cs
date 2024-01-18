using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Modes
{
    public int modeNum;
    public GameObject parent;
    [Tooltip("Exactly the name of scene to load from build menu")]
    public string targetScene;
    public Button[] allLevels;
    public GameObject[] locks;

}
