using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoEPlataforma : MonoBehaviour
{
    [SerializeField] private float velocidad;
    [SerializeField] private Transform controlSuelo;
    [SerializeField] private float distancia;
    [SerializeField] private bool movimientoDerecha;
    private Rigidbody2D rigidbody2d;

    private void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        RaycastHit2D infoSuelo = Physics2D.Raycast(controlSuelo.position, Vector2.down, distancia);
        rigidbody2d.velocity = new Vector2(velocidad, rigidbody2d.velocity.y);

        if (infoSuelo == false)
        {
            Girar();
        }
    }

    private void Girar()
    {
        movimientoDerecha = !movimientoDerecha;
        transform.eulerAngles = new Vector3 (0, transform.eulerAngles.y + 180, 0);
        velocidad *= -1;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(controlSuelo.transform.position, controlSuelo.transform.position + Vector3.down * distancia);
    }
}
