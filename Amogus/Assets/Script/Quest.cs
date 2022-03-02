using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    private bool m_isQuestComplete;
    private GameObject QuestSystem;

    void Start()
    {
        m_isQuestComplete = false;
        QuestSystem = GameObject.Find("QuestSystem");
    }

    public bool IsQuestComplete()
    {
        return m_isQuestComplete;
    }

    public void CompleteQuest()
    {
        m_isQuestComplete = true;
    }

    public void ActiveQuest()
    {
        QuestSystem.transform.Find(gameObject.name).gameObject.SetActive(true);
    }

    public void DeactiveQuest()
    {
        QuestSystem.transform.Find(gameObject.name).gameObject.SetActive(false);
    }
}
