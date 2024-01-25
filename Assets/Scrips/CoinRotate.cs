using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRotate : MonoBehaviour
{
    public float speed = 1f;

    void Update()
    {
        transform.Rotate(Vector3.forward, speed);
    }
}
