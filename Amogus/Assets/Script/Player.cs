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
            m_currentQuest.GetComponent<Quest>().ActiveQuest();
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        if (m_isDoingQuest && m_currentQuest.GetComponent<Quest>().IsQuestComplete())
        {
            StartCoroutine(CompleteQuest(2f));
            
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Quest")
        {
            m_currentQuest = collision.gameObject;
            if (m_currentQuest.GetComponent<Quest>().IsQuestComplete() == false && m_isDoingQuest == false)
            {
                EnterQuest();
            }
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Quest")
        {
            ExitQuest();
            m_isDoingQuest = false;
            m_isOnQuestRange = false;
        }
    }

    public void EnterQuest()
    {
        QuestSystem.transform.Find("InteractTextGuild").gameObject.SetActive(true);
        m_isOnQuestRange = true;
    }

    public void ExitQuest()
    {
        QuestSystem.transform.Find("InteractTextGuild").gameObject.SetActive(false);
        if (m_currentQuest)
        {
            m_currentQuest.GetComponent<Quest>().DeactiveQuest();
        }
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private IEnumerator CompleteQuest(float fadeInSec)
    {
        QuestSystem.transform.Find("CompleteText").gameObject.SetActive(true);
        ExitQuest();
        yield return new WaitForSeconds(fadeInSec);
        QuestSystem.transform.Find("CompleteText").gameObject.SetActive(false);
    }
}
