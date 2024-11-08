using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class ScoreDisplay : MonoBehaviour
{
    public TextMeshProUGUI monedasText;
    public TextMeshProUGUI dañoText;
    public TextMeshProUGUI tiempoText;

    private void Start()
    {
        // Actualiza el texto con los valores correspondientes
        UpdateScoreDisplay();
    }

    private void UpdateScoreDisplay()
    {
        // Muestra la cantidad de monedas, daño y tiempo
        monedasText.text = "Monedas: " + GameManager.Instance.GetMonedasTotales().ToString();
        dañoText.text = "Daño: " + GameManager.Instance.GetTotalDamage().ToString();

        tiempoText.text = "Tiempo: " + GameManager.Instance.tiempo.ToString("F2") + "s"; // Asegúrate de tener la propiedad 'tiempo' en GameManager
    }
    
}
