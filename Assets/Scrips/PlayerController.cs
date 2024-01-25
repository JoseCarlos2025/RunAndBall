using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;

    private float movementX;
    private float movementY;
    private bool isGrounded;
    private int count;

    public float speed = 5.0f;
    public float jumpForce = 2.0f;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    public GameObject winImgObject;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winTextObject.SetActive(false);
        winImgObject.SetActive(true);
    }

    void OnMove(InputValue movementValue)
    {
        winImgObject.SetActive(false);
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void OnJump(InputValue jumpValue)
    {
        Debug.Log("On Ground");
        if (isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void FixedUpdate()
    {
        float cameraRotationY = Camera.main.transform.eulerAngles.y;

        Vector3 movement = Quaternion.Euler(0, cameraRotationY, 0) * new Vector3(movementX, 0, movementY);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
        if (other.gameObject.CompareTag("Finish"))
        {
            winTextObject.SetActive(true);
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
    }
}

