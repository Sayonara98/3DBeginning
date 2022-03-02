using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockManifolds : MonoBehaviour
{
    private Button[] button;

    private int m_currentNumber;

    private bool m_isClickWrongNumber;

    private Quest quest;

    // Start is called before the first frame update
    void Start()
    {
        button = new Button[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            button[i] = transform.GetChild(i).gameObject.GetComponentInChildren<Button>();
            button[i].GetComponentInChildren<Text>().text = (i + 1).ToString();
            button[i].image.color = Color.white;
            Button btn = button[i];
            button[i].onClick.AddListener(() => OnClickButton(btn));
        }

        m_currentNumber = 1;
        quest = GameObject.Find("Quest").transform.Find(gameObject.name).gameObject.GetComponent<Quest>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_isClickWrongNumber)
        {
            resetAllButton();
            m_isClickWrongNumber = false;
            m_currentNumber = 1;
        }

        if (m_currentNumber == transform.childCount + 1 && quest.IsQuestComplete() == false)
        {
            quest.CompleteQuest();
        }
    }

    void OnClickButton(Button btn)
    {
        if (int.Parse(btn.GetComponentInChildren<Text>().text) == m_currentNumber)
        {
            btn.image.color = Color.green;
            m_currentNumber++;
        }
        else if (btn.image.color != Color.green)
        {
            m_isClickWrongNumber = true;
        }
    }

    void resetAllButton()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            button[i].image.color = Color.white;
        }
    }
}
