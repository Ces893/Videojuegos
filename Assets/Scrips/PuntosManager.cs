using UnityEngine;
using UnityEngine.UI;

public class PuntosManager : MonoBehaviour
{
    public int puntos = 0;  // Contador de puntos
    public Text puntosText;  // Referencia a un texto UI para mostrar los puntos

    // Método para agregar puntos
    public void AñadirPuntos(int cantidad)
    {
        puntos += cantidad;
        ActualizarUI();
    }

    // Método para actualizar el texto en la UI
    void ActualizarUI()
    {
        puntosText.text = "Puntos: " + puntos;
    }
}
