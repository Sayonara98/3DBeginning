using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    private bool m_isQuestComplete;
    private GameObject QuestSystem;
    private GameObject m_Quest;

    void Start()
    {
        m_isQuestComplete = false;
        gameObject.tag = "Quest";
        QuestSystem = GameObject.Find("QuestSystem");
        Debug.Log("name: " + gameObject.name);
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
        }
    }

    public void DeactiveQuest()
    {
        if (m_Quest)
        {
            m_Quest.SetActive(false);
        }
    }
}
