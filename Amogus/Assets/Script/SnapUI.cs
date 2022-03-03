using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapUI : MonoBehaviour
{
    private GameObject QuestSystem;

    private GameObject StoreArtifacts;
    // Start is called before the first frame update
    void Start()
    {
        QuestSystem = GameObject.Find("QuestSystem").transform.gameObject;
        StoreArtifacts = QuestSystem.transform.Find("Store Artifacts").transform.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == gameObject.tag)
        {
            collision.gameObject.GetComponent<DragUI>().setMatch(true);
            collision.gameObject.transform.position = gameObject.transform.position;
            StoreArtifacts.GetComponent<StoreArtifacts>().oneMorePairMatch();
        }
    }
}
