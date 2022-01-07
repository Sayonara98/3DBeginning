using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerCameraHandle : MonoBehaviour
{
    public Transform Tartget;
    public Transform Player;
    [SerializeField]
    private float RotationSpeed = 1;

    float m_MouseX;
    float m_MouseY;

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
        m_MouseX += Input.GetAxis("Mouse X") * RotationSpeed;
        m_MouseY -= Input.GetAxis("Mouse Y") * RotationSpeed;
        m_MouseY = Mathf.Clamp(m_MouseY, -35, 60);

        transform.LookAt(Tartget);

        Tartget.rotation = Quaternion.Euler(m_MouseY, m_MouseX, 0);
    }
}
