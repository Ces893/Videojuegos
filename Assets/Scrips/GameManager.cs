using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public Canvas canvas;
    private int vidas = 3;

    public void Awake()
    {
        if (Instance == null) { 
            Instance = this;
        }
        else
        {
            Debug.Log("Error");
        }
    }

    public void perderVida() { 
        vidas -= 1;
        if (vidas == 0) {
            SceneManager.LoadScene(2);
        }
        canvas.DesactivarVida(vidas);
    }

    public bool RecuperarVida() {
        if (vidas == 3) { return false; }
        canvas.ActivarVida(vidas);
        vidas += 1;
        return true;
    }
}
