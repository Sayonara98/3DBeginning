using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Numpad : MonoBehaviour
{
    private Button[] keyboard;
    private string m_sInputCode;
    // Start is called before the first frame update
    void Start()
    {
        keyboard = new Button[transform.childCount];
        for (int i = 0; i < keyboard.Length; i++)
        {
            keyboard[i] = transform.GetChild(i).gameObject.GetComponent<Button>();
            keyboard[i].name = i.ToString();
            Button key = keyboard[i];
            keyboard[i].onClick.AddListener(() => OnClickButton(key.name));
        }
    }

    private void OnClickButton(string code)
    {
        m_sInputCode += code;
        Debug.Log(m_sInputCode);
    }

    public string getInput()
    {
        return m_sInputCode;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
