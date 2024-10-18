using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRotation : MonoBehaviour
{
    public float rotationSpeed = 100f; // Velocidad de rotación ajustable

    void Update()
    {
        // Rota la moneda alrededor de su eje Y
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }
}
