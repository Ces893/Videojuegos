using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicial : MonoBehaviour
{
   public void Jugar(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
   }
   public void Salir(){
        Debug.Log("Salir...");
        #if UNITY_EDITOR
        // Si estamos en el editor, simplemente detener la reproducción
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        // Si estamos en una build, salir del juego
        Application.Quit();
        #endif
   }
}
