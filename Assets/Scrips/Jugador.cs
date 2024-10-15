using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    public float speedCaminar;
    private float movimiento;
    public float fuerzaSalto;
    public LayerMask capaSuelo;
    public float fuerzaGolpe;

    private Rigidbody2D rigidbody2D;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;

    private bool recibeDaño;

    // Sonido de caminar
    public AudioClip sonidoCaminar;
    private AudioSource audioSource;

    //Escaleras
    [SerializeField] private float velocidadEscalar;
    private float gravedadInit;
    private bool escalando;
    private Vector2 input;

    private bool sonidoEnReproduccion = false;  // Flag para evitar solapamientos de sonido

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
        audioSource = GetComponent<AudioSource>();// Obtiene el componente de sonido
        gravedadInit = rigidbody2D.gravityScale;

        // Asegúrate de que el AudioSource esté configurado
        if (audioSource == null)
        {
            Debug.LogError("AudioSource no encontrado en el objeto del jugador.");
        }
        else
        {
            audioSource.clip = sonidoCaminar;  // Configura el clip al inicio
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!recibeDaño)
            movimiento = Input.GetAxis("Horizontal") * speedCaminar;
        input.y = Input.GetAxis("Vertical");
        rigidbody2D.velocity = new Vector2(movimiento, rigidbody2D.velocity.y);

        // Reproduce el sonido de caminar solo si el personaje está en movimiento
        if (movimiento != 0)
        {
            animator.SetBool("Caminando", true);
            spriteRenderer.flipX = movimiento < 0;
            
            // Reproduce el sonido de caminar si no está en reproducción
            if (!sonidoEnReproduccion)
            {
                ReproducirSonido();
            }
        }
        else
        {
            animator.SetBool("Caminando", false);
            // Detiene el sonido de caminar cuando el personaje no se mueve
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
                sonidoEnReproduccion = false;  // Actualiza el flag
            }
        }

        if (Math.Abs(rigidbody2D.velocity.y) > Mathf.Epsilon)
        {
            animator.SetFloat("VelocidadY", Mathf.Sign(rigidbody2D.velocity.y));
        }
        else {
            animator.SetFloat("VelocidadY", 0);
        }

        ProcesarSalto();
        Escalar();
        animator.SetBool("Recibedamage", recibeDaño);
    }

    void ProcesarSalto()
    {
        if (Input.GetKeyDown(KeyCode.Space) && EstaenSuelo() && !recibeDaño)
        {
            rigidbody2D.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
        }

        animator.SetBool("EnSuelo", EstaenSuelo());
    }

    bool EstaenSuelo()
    {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(boxCollider.bounds.center, new Vector2(boxCollider.bounds.size.x, boxCollider.bounds.size.y), 0f, Vector2.down, 0.2f, capaSuelo);
        return raycastHit2D.collider != null;
    }

    public void DañoRecibido(Vector2 direccion)
    {
        if (!recibeDaño) {
            recibeDaño = true;
            Vector2 rebore = new Vector2(transform.position.x - direccion.x, 0.5f).normalized;
            rigidbody2D.AddForce(rebore* fuerzaGolpe, ForceMode2D.Impulse);
        }
    }

    public void DesactivaDaño()
    {
        recibeDaño = false;
        rigidbody2D.velocity = Vector2.zero;
    }


    // Método para reproducir sonido
    void ReproducirSonido()
    {
        if (audioSource != null && !audioSource.isPlaying)
        {
            audioSource.Play();
            sonidoEnReproduccion = true;  // Actualiza el flag
        }
    }

    private void Escalar() {
        if ((input.y != 0 || escalando) && (boxCollider.IsTouchingLayers(LayerMask.GetMask("Escaleras"))))
        {
            Vector2 velocidadSubida = new Vector2(rigidbody2D.velocity.x, input.y * velocidadEscalar);
            rigidbody2D.velocity = velocidadSubida;
            rigidbody2D.gravityScale = 0;
            escalando = true;
        }
        else {
            rigidbody2D.gravityScale = gravedadInit;
            escalando = false;
        }

        animator.SetBool("Escalando",escalando);
    }
}
