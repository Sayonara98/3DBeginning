using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    private bool m_isQuestComplete;
    private GameObject QuestSystem;
    private GameObject m_Quest;
    private bool m_isQuestActive;

    void Start()
    {
        m_isQuestComplete = false;
        m_isQuestActive = false;
        gameObject.tag = "Quest";
        QuestSystem = GameObject.Find("QuestSystem");
        m_Quest = QuestSystem.transform.Find(gameObject.name).gameObject;
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
        if (m_Quest)
        {
            m_Quest.SetActive(true);
            m_isQuestActive = true;
        }
    }

    public void DeactiveQuest()
    {
        if (m_Quest)
        {
            m_Quest.SetActive(false);
            m_isQuestActive = false;
        }
    }

    public bool isQuestActive()
    {
        return m_isQuestActive;
    }    
}
