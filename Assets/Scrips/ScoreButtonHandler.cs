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
        GameManager.Instance.ResetMonedas();
        SceneManager.LoadScene("menuInicio"); // Cambia a la escena de inicio
    }

}
