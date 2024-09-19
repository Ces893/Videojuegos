using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salto : MonoBehaviour
{
    public Rigidbody2D rbd;
    public float fuerza;

    // Sonido de salto
    public AudioClip sonidoSaltar;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        // Obtiene el componente de AudioSource
        audioSource = GetComponent<AudioSource>();
        
        // Configura el AudioSource si no está asignado
        if (audioSource == null)
        {
            Debug.LogError("AudioSource no encontrado en el objeto del jugador.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Añadir fuerza para el salto
            rbd.AddForce(Vector2.up * fuerza, ForceMode2D.Impulse);
            
            // Reproducir sonido de salto
            ReproducirSonido();
        }
    }

    // Método para reproducir el sonido de salto
    void ReproducirSonido()
    {
        if (audioSource != null && sonidoSaltar != null)
        {
            audioSource.clip = sonidoSaltar;
            audioSource.Play();
        }
    }
}
