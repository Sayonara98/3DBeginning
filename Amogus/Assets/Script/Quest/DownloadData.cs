using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DownloadData : MonoBehaviour
{
    [SerializeField]
    private Button DownloadButton;
    [SerializeField]
    private Slider LoadingBar;
    [SerializeField]
    private Text LoadingPercent;

    private float m_fCurrentPercent;

    private Quest quest;

    // Start is called before the first frame update
    void Start()
    {
        DownloadButton.gameObject.SetActive(true);
        LoadingBar.gameObject.SetActive(false);
        LoadingBar.value = 0.0f;
        LoadingPercent.gameObject.SetActive(false);
        m_fCurrentPercent = 0.0f;

        // maybe I should use inheritance to avoid this piece of trash KEKW, I'm not sure
        quest = GameObject.Find("Quest").transform.Find(gameObject.name).gameObject.GetComponent<Quest>();
    }

    private void Update()
    {
        if (quest.IsQuestComplete() == false)
        {
            if (LoadingBar.value == 1.0f)
            {
                quest.CompleteQuest();
            }
            else if (LoadingBar.value <= m_fCurrentPercent)
            {
                LoadingBar.value += Time.deltaTime / 3;
                setLoadingBar(LoadingBar.value);
            }
        }
    }

    public void Download()
    {
        DownloadButton.gameObject.SetActive(false);
        LoadingBar.gameObject.SetActive(true);
        LoadingPercent.gameObject.SetActive(true);
        StartCoroutine(CopiumLoadingBar());
    }

    private IEnumerator CopiumLoadingBar()
    {
        m_fCurrentPercent = 0.1f;
        yield return new WaitForSeconds(2.0f);
        m_fCurrentPercent = 0.5f;
        yield return new WaitForSeconds(3.0f);
        m_fCurrentPercent = 0.8f;
        yield return new WaitForSeconds(1.0f);
        m_fCurrentPercent = 0.99f;
        yield return new WaitForSeconds(0.5f);
        m_fCurrentPercent = 1.0f;
    }

    private void setLoadingBar(float percent)
    {
        LoadingPercent.text = Mathf.Round(percent * 100).ToString() + "%";
    }
}
