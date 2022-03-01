using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody m_Rigidbody;
    private Animator m_Animator;

    [SerializeField]
    private Camera m_followCamera;

    [SerializeField]
    private float m_speed = 2f;
    [SerializeField]
    private float m_rotationSpeed = 10f;

    private bool isMove;


    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Animator = GetComponent<Animator>();
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

        Vector3 movementInput = Quaternion.Euler(0, m_followCamera.transform.eulerAngles.y, 0) * new Vector3(horizontal, 0, vertical);
        Vector3 movementDirection = movementInput.normalized;

        m_Rigidbody.MovePosition(m_Rigidbody.position + movementDirection * m_speed * Time.deltaTime);

        if (movementDirection != Vector3.zero)
        {
            Quaternion desiredRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, m_rotationSpeed * Time.deltaTime);
            isMove = true;
        }
        else
        {
            isMove = false;
        }

        m_Animator.SetBool("IsMove", isMove);
    }
}
