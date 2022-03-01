using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerCameraHandle : MonoBehaviour
{
    [SerializeField]
    private Transform m_target;
    [SerializeField]
    private float m_distanceFromTarget = 3.0f;
    [SerializeField]
    private float RotationSpeed = 1;

    private Vector3 m_currentRotation;
    private Vector3 m_smoothVelocity = Vector3.zero;
    [SerializeField]
    private float m_smoothTime = 0.2f;

    private float m_rotationY;
    private float m_rotationX;

    [SerializeField]
    private Vector2 m_rotationXMinMax = new Vector2(-40, 40);

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        CameraControl();
    }

    void CameraControl()
    {
        float mouseX = Input.GetAxis("Mouse X") * RotationSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * RotationSpeed;

        m_rotationX -= mouseY;
        m_rotationY += mouseX;

        m_rotationX = Mathf.Clamp(m_rotationX, m_rotationXMinMax.x, m_rotationXMinMax.y);

        Vector3 nextRotation = new Vector3(m_rotationX, m_rotationY);

        m_currentRotation = Vector3.SmoothDamp(m_currentRotation, nextRotation, ref m_smoothVelocity, m_smoothTime);
        transform.localEulerAngles = m_currentRotation;

        transform.position = m_target.position - transform.forward * m_distanceFromTarget;
    }
}
