using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingMove : MonoBehaviour
{
    public float velocidad = 1f;
    public float distancia = 5f;
    private Vector3 posicionInicial;

    void Start()
    {
        posicionInicial = transform.position;
    }

    void Update()
    {
        float desplazamiento = Mathf.PingPong(Time.time * velocidad, distancia * 2) - distancia;

        transform.position = new Vector3(posicionInicial.x + desplazamiento, posicionInicial.y, posicionInicial.z);
    }
}
