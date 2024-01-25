using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public float rotationSpeed = 2.0f;

    private Vector3 offset;

    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    void LateUpdate()
    {
        float horizontalInput = Mouse.current.delta.x.ReadValue() * rotationSpeed;

        Quaternion rotation = Quaternion.Euler(0, horizontalInput, 0);
        offset = rotation * offset;
        transform.position = player.transform.position + offset;

        transform.LookAt(player.transform.position);
    }
}

