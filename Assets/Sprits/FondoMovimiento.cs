using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FondoMovimiento : MonoBehaviour
{
    [SerializeField] private float parallaxMul;
    private Transform cameraTransform;
    private Vector3 preCameraPosition;
    
    void Start()
    {
        cameraTransform = Camera.main.transform;
        preCameraPosition = cameraTransform.position;
    }

    void LateUpdate()
    {
       float deltaX = (cameraTransform.position.x - preCameraPosition.x)* parallaxMul;
        transform.Translate(new Vector3(deltaX, 0, 0));
        preCameraPosition = cameraTransform.position;
    }

}
