using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float Speed = 2f;
    private Vector3 m_Movement;
    private Rigidbody m_Rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovementHanle();
    }

    void PlayerMovementHanle()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        m_Movement.Set(horizontal, 0f, vertical);
        m_Movement.Normalize();

        //m_Rigidbody.MovePosition(m_Rigidbody.position + m_Movement * Speed * Time.deltaTime);
        transform.Translate(m_Movement * Speed * Time.deltaTime);
    }
}
