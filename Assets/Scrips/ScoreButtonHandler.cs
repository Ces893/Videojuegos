using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreButtonHandler : MonoBehaviour
{
    public void RepetirEscena()
    {
        GameManager.Instance.ResetMonedas();
        SceneManager.LoadScene("escena 2"); // Repite la escena 2
        
    }

    public void IrAMenuInicio()
    {
        SceneManager.LoadScene("menuInicio"); // Cambia a la escena de inicio
    }
    public void ReiniciarEscena2()
{
    GameManager.Instance.ResetMonedas();
    SceneManager.LoadScene("nombre_de_la_escena_2"); // Cambia "nombre_de_la_escena_2" por el nombre real de tu escena
}
}
