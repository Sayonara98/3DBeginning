using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StoreArtifacts : MonoBehaviour
{
    private float m_pairCount;
    private Quest quest;

    private void Start()
    {
        m_pairCount = 0;
        quest = GameObject.Find("Quest").transform.Find(gameObject.name).gameObject.GetComponent<Quest>();
    }

    private void Update()
    {
        if (m_pairCount == 4 && quest.isQuestActive())
        {
            quest.CompleteQuest();
            Debug.Log("Complete");
        }
    }

    public void oneMorePairMatch()
    {
        m_pairCount++;
        Debug.Log("Amazing");
    }    
}
