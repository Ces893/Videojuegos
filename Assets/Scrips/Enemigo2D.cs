using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo2D : MonoBehaviour
{
    public Animator animator;             
    public float rangoDeVision = 5f;       
    public string tagJugador = "Player";   
    private bool isAttacking = false;

    private Rigidbody2D rigidbody2;
    [SerializeField] private float vida;

    private void Start()
    {
        rigidbody2 = GetComponent<Rigidbody2D>();
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
    }

    private void Update()
    {
        DetectarJugador();
    }

    public void TomarDaño(float daño)
    {
        vida -= daño;
        if (vida <= 0)
        {
            Muerte();
        }
    }

    private void Muerte()
    {
        animator.SetTrigger("Muerte");
        // Obtiene la duración de la animación "Muerte"
        float tiempoMuerte = animator.GetCurrentAnimatorStateInfo(0).length;

        // Llama a DestruirEnemigo después de la duración de la animación
        Invoke("DestruirEnemigo", tiempoMuerte);
    }

    private void DestruirEnemigo()
    {
        Destroy(gameObject);
    }

    private void DetectarJugador()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, rangoDeVision);

        // Verifica si se detecta al jugador y el enemigo no está ya atacando
        if (hit.collider != null && hit.collider.CompareTag(tagJugador) && !isAttacking)
        {
            IniciarAtaque(hit.collider);
        }
        else if (hit.collider == null || !hit.collider.CompareTag(tagJugador))
        {
            // Si el jugador sale del rango de visión, el enemigo vuelve a caminar
            animator.SetBool("Caminando", true);
            isAttacking = false;
        }
    }

    private void IniciarAtaque(Collider2D jugadorCollider)
    {
        isAttacking = true;
        animator.SetTrigger("Atacar"); // Activa la animación de ataque

        // Calcula la dirección del empuje del jugador
        Vector2 direccion = (jugadorCollider.transform.position - transform.position).normalized;

        // Aplica daño al jugador, si el componente Jugador existe
        Jugador jugador = jugadorCollider.GetComponent<Jugador>();
        if (jugador != null)
        {
            jugador.DañoRecibido(direccion);
        }

        // Llama a perderVida en GameManager si existe
        if (GameManager.Instance != null)
        {
            GameManager.Instance.perderVida();
        }
        else
        {
            Debug.LogWarning("GameManager no encontrado. Asegúrate de que existe una instancia.");
        }
    }

    // Método que se llama al final de la animación de ataque
    public void OnAttackAnimationEnd()
    {
        // Permite que el enemigo vuelva a caminar después de atacar
        isAttacking = false;
        animator.SetBool("Caminando", true);
    }

    // Gizmo para visualizar el rango de visión del enemigo
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + transform.right * rangoDeVision);
    }
}
