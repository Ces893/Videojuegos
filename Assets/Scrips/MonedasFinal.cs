using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para cambiar de escena

public class MonedasFinal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica si el objeto que colisiona tiene la etiqueta "Player"
        if (collision.CompareTag("Player"))
        {
            // Cambia a la escena final
            GameController.Instance.CompleteLevel(); // Asegúrate de tener el método en GameController
        }
    }
}
