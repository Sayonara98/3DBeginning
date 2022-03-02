using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Canvas QuestSystem;

    private GameObject m_currentQuest;

    private bool m_isDoingQuest;
    private bool m_isOnQuestRange;

    // Start is called before the first frame update
    void Start()
    {
        m_isDoingQuest = false;
        m_isOnQuestRange = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_isOnQuestRange == false)
        {
            ExitQuest();
        }
        else if (Input.GetKeyDown(KeyCode.F) && m_isDoingQuest == false)
        {
            m_isDoingQuest = true;
            QuestSystem.transform.Find("InteractTextGuild").gameObject.SetActive(false);
            QuestSystem.transform.Find("Unlock Manifolds").gameObject.SetActive(true);
            Debug.Log("Display Quest");
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Quest")
        {
            m_currentQuest = collision.gameObject;
            if (m_currentQuest.GetComponent<Quest>().IsQuestComplete() == false && m_isDoingQuest == false)
            {
                QuestSystem.transform.Find("InteractTextGuild").gameObject.SetActive(true);
                m_isOnQuestRange = true;
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Quest")
        {
            ExitQuest();
            m_isDoingQuest = false;
            m_isOnQuestRange = false;
        }
    }

    public void ExitQuest()
    {
        QuestSystem.transform.Find("InteractTextGuild").gameObject.SetActive(false);
        QuestSystem.transform.Find("Unlock Manifolds").gameObject.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
