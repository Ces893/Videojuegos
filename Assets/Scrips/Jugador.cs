using System.Collections;
using System.Collections.Generic;
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

    private bool puedeMoverse = true;
    private bool recibeDaño;

    // Sonido de caminar
    public AudioClip sonidoCaminar;
    private AudioSource audioSource;

    private bool sonidoEnReproduccion = false;  // Flag para evitar solapamientos de sonido

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
        audioSource = GetComponent<AudioSource>();  // Obtiene el componente de sonido

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
        if (!puedeMoverse) return;

        movimiento = Input.GetAxis("Horizontal") * speedCaminar;
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

        ProcesarSalto();
        animator.SetBool("Recibedaño", recibeDaño);
    }

    void ProcesarSalto()
    {
        if (Input.GetKeyDown(KeyCode.Space) && EstaenSuelo())
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

    public void DañoRecibido()
    {
        if (!recibeDaño)
        {
            puedeMoverse = false;
            recibeDaño = true;

            Vector2 direccionGolpe;

            if (rigidbody2D.velocity.x > 0)
            {
                direccionGolpe = new Vector2(-1, 1);
            }
            else { direccionGolpe = new Vector2(1, 1); }

            rigidbody2D.AddForce(direccionGolpe * fuerzaGolpe);

            StartCoroutine(EsperarActividadMovimiento());
        }
    }

    public void DesactivaDaño()
    {
        recibeDaño = false;
        rigidbody2D.velocity = Vector2.zero;
    }

    IEnumerator EsperarActividadMovimiento()
    {
        yield return new WaitForSeconds(0.1f);

        while (!EstaenSuelo())
        {
            yield return null;
        }
        puedeMoverse = true;
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
}
