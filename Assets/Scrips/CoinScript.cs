using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // Verifica si el jugador ha tocado la moneda
        {
            GameManager1.instance.AddCoin(); // Agrega una moneda al contador
            Destroy(gameObject); // Destruye la moneda
        }
    }
}
