using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        Debug.Log("Cargando escena: " + sceneName);
        SceneManager.LoadScene(sceneName);
    }
    public void VolverAlMenuPrincipal()
    {
        SceneManager.LoadScene("Scenes/menuInicio");
    }

}
