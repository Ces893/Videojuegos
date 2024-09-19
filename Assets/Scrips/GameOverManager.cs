using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    // Método que detecta cuando otro objeto entra en el área de trigger
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica si el objeto que entra en el área es el jugador
        if (other.CompareTag("Player"))
        {
            // Llama al método para terminar el juego
            GameOver();
        }
    }

    // Método para manejar el final del juego
    void GameOver()
    {
        Debug.Log("¡El jugador ha caído! Fin del juego.");
        // Aquí puedes añadir lógica para detener el juego o mostrar una pantalla de Game Over.
        // Ejemplo: Recargar la escena
        //SceneManager.LoadScene(SceneManager.GetActiveScene().SampleScene);
    }
}
