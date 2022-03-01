using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    private bool m_isQuestComplete;

    void Start()
    {
        m_isQuestComplete = false;
    }

    public bool IsQuestComplete()
    {
        return m_isQuestComplete;
    }
}
