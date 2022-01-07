using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Transform cameraTransform;
    [SerializeField]
    private Transform modelTransform;
    [SerializeField]
    private float Speed = 2f;
    [SerializeField]
    private float RotateSpeed = 720f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovementHanle();

        if (Input.GetKey(KeyCode.R))
        {
            modelTransform.transform.Rotate(0f, 10f * Time.deltaTime, 0f, Space.World);
            Debug.Log("forward: " + cameraTransform.transform.rotation);
            Debug.Log("amogus: " + modelTransform.transform.rotation);
        }
    }

    void PlayerMovementHanle()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 forward = cameraTransform.transform.forward;
        Vector3 right = cameraTransform.transform.right;

        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();

        Vector3 desiredMoveDirection = forward * vertical + right * horizontal;
        desiredMoveDirection.Normalize();

        transform.Translate(desiredMoveDirection * Speed * Time.deltaTime);

        if (desiredMoveDirection != Vector3.zero)
        {
            Quaternion desiredRotataDirection = Quaternion.LookRotation(desiredMoveDirection, Vector3.up);
            //modelTransform.rotation = Quaternion.RotateTowards(modelTransform.rotation, desiredRotataDirection, RotateSpeed * Time.deltaTime);
            Vector3 newDirection = Vector3.RotateTowards(modelTransform.forward, desiredMoveDirection, RotateSpeed * Time.deltaTime, 0.0f);
            Debug.DrawRay(modelTransform.position, newDirection, Color.red);
            modelTransform.rotation = Quaternion.LookRotation(newDirection);
            modelTransform.transform.Rotate(-90, 0, 0);
        }
    }
}
