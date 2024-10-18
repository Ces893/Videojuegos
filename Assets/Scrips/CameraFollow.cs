using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Player; // Referencia al Transform del personaje
    public Vector3 offset; // Offset de la cámara respecto al jugador
    public float smoothSpeed = 0.125f; // Velocidad de suavizado

    void LateUpdate()
    {
        // Determina la posición objetivo de la cámara
        Vector3 desiredPosition = Player.position + offset;

        // Interpola suavemente entre la posición actual y la deseada
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        
        // Asigna la nueva posición a la cámara
        transform.position = smoothedPosition;
    }
}
