using UnityEngine;
using UnityEngine.SceneManagement; // Asegúrate de incluir esto para manejar escenas

public class MenuController : MonoBehaviour
{
    // Este método se llamará cuando el botón "Salir" sea presionado
    public void ExitGame()
    {
        #if UNITY_EDITOR
        // Si estamos en el editor, simplemente detener la reproducción
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        // Si estamos en una build, salir del juego
        Application.Quit();
        #endif
    }
}
