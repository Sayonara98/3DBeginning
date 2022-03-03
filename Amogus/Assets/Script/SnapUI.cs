using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collide");
        if (collision.gameObject.name == gameObject.name)
        {
            Debug.Log("Snap");
            collision.gameObject.GetComponent<DragUI>().setMatch(true);
            collision.gameObject.transform.position = gameObject.transform.position;
        }
    }
}
