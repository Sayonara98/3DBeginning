using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartReactor : MonoBehaviour
{
    private Quest quest;
    [SerializeField]
    private Numpad keyboard;

    private GameObject monitor;
    private GameObject[] pixel;

    private int[] m_iaCode;

    private int m_iCodeComplexity; // max is 9

    private int m_iCurrentProgress;
    private bool m_bIsWaitingInput;

    private string m_sCodeFromPlayer;

    // Start is called before the first frame update
    void Start()
    {
        m_iCodeComplexity = 5;
        m_iCurrentProgress = 1;
        m_bIsWaitingInput = false;
        m_sCodeFromPlayer = "";

        m_iaCode = new int[m_iCodeComplexity];

        genNewCode();

        monitor = transform.Find("Monitor").gameObject;
        pixel = new GameObject[monitor.transform.childCount];
        for (int i = 0; i < pixel.Length; i++)
        {
            pixel[i] = monitor.transform.GetChild(i).gameObject;
            pixel[i].name = i.ToString();
        }

        // maybe I should use inheritance to avoid this piece of trash KEKW, I'm not sure
        quest = GameObject.Find("Quest").transform.Find(gameObject.name).gameObject.GetComponent<Quest>();
    }

    // Update is called once per frame
    void Update()
    {
        if (quest.isQuestActive() && quest.IsQuestComplete() == false)
        {
            if (m_iCurrentProgress > m_iCodeComplexity)
            {
                quest.CompleteQuest();
            }
            else
            {
                if (m_bIsWaitingInput)
                {
                    if (keyboard.getInput() != null && keyboard.getInput() != m_sCodeFromPlayer)
                    {
                        if (checkCode())
                        {
                            if (m_sCodeFromPlayer.Length == m_iCurrentProgress && m_iCurrentProgress <= m_iCodeComplexity)
                            {
                                m_iCurrentProgress++;
                                m_bIsWaitingInput = false;
                                keyboard.ClearInputCode();
                            }
                        }
                        else
                        {
                            keyboard.AcessDenied();
                            keyboard.ClearInputCode();
                            genNewCode();
                            m_bIsWaitingInput = false;
                            m_iCurrentProgress = 1;
                        }
                    }
                }
                else
                {
                    displayCode();
                }
            }
        }
    }

    public void genNewCode()
    {
        int[] temp = new int[9] { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
        Shuffle(temp);
        for (int i = 0; i < m_iCodeComplexity; i++)
        {
            m_iaCode[i] = temp[Random.Range(i, 9)];
        }
    }

    public bool checkCode()
    {
        m_sCodeFromPlayer = keyboard.getInput();
        string currentCode = "";
        for (int i = 0; i < m_iCurrentProgress; i++)
        {
            currentCode += m_iaCode[i].ToString();
        }
        for (int i = 0; i < m_sCodeFromPlayer.Length; i++)
        {
            if (m_sCodeFromPlayer[i] != currentCode[i])
            {
                return false;
            }
        }
        return true;
    }

    private void displayCode()
    {
        for (int i = 0; i < m_iCurrentProgress; i++)
        {
            StartCoroutine(displaysingleCode(m_iaCode[i], i));
        }
        m_bIsWaitingInput = true;
    }

    private IEnumerator displaysingleCode(int code, int progress)
    {
        yield return new WaitForSeconds(1f + progress + 0.5f * progress);
        if (code < pixel.Length)
        {
            pixel[code].GetComponent<Image>().color = Color.green;
        }
        yield return new WaitForSeconds(0.5f);
        pixel[code].GetComponent<Image>().color = Color.black;
    }

    // this code duplicate with UnlockManifolds.cs, but now I'm lazy =))
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
}
