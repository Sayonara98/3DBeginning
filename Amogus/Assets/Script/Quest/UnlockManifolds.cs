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
        int[] array = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        Shuffle(array);

        button = new Button[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            button[i] = transform.GetChild(i).gameObject.GetComponentInChildren<Button>();
            button[i].GetComponentInChildren<Text>().text = array[i].ToString();
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
        if (m_currentNumber == transform.childCount + 1 && quest.isQuestActive())
        {
            quest.CompleteQuest();
        }
    }

    // Fisher - Yates algorithm
    void Shuffle(int[] array)
    {
        int n = array.Length;
        while (n > 1)
        {
            int k = Random.Range(1, n--);
            int temp = array[n];
            array[n] = array[k];
            array[k] = temp;
        }
    }
    void OnClickButton(Button btn)
    {
        if (!m_isClickWrongNumber)
        {
            if (int.Parse(btn.GetComponentInChildren<Text>().text) == m_currentNumber)
            {
                btn.image.color = Color.green;
                m_currentNumber++;
            }
            else if (btn.image.color != Color.green)
            {
                m_isClickWrongNumber = true;
                m_currentNumber = 1;
                resetAllButton();
            }
        }
    }

    void resetAllButton()
    {
        StartCoroutine(FlashRed(1f));
    }

    private IEnumerator FlashRed(float duration)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            button[i].image.color = Color.red;
        }
        yield return new WaitForSeconds(duration);
        for (int i = 0; i < transform.childCount; i++)
        {
            button[i].image.color = Color.white;
        }
        m_isClickWrongNumber = false;
    }
}
