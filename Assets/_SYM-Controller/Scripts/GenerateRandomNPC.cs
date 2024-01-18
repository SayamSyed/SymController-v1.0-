using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateRandomNPC : MonoBehaviour
{
    public List<ActionTriggerAI> npcList = new List<ActionTriggerAI>();
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GenerateNPC());
    }
    IEnumerator GenerateNPC() 
    {
        //activate a random npc
        int rand = Random.Range(0, npcList.Count);
        for (int i = 0; i < npcList.Count; i++)
        {
            npcList[i].gameObject.SetActive(false);
        }
        npcList[rand].gameObject.SetActive(true);
        yield return new WaitForSeconds(1.5f) ;
        npcList[rand].SetAction();
    }


}
