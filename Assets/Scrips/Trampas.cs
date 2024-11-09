using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampas : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Vector2 direccion = new Vector2(transform.position.x, 0);
            collision.GetComponent<Jugador>().DañoRecibido(direccion);
            GameManager.Instance.perderVida();

            Debug.Log("El jugador ha activado una trampa y ha recibido daño.");
        }
    }
}
