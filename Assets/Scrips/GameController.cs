using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }

    // Variables para almacenar resultados
    public int totalDamage;  // Total de daño hecho
    public float totalTime;   // Tiempo total de la partida
    public int totalCoins;    // Total de monedas recolectadas

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Mantener entre escenas
        }
        else
        {
            Destroy(gameObject);
        }
        

    }

    public void CompleteLevel()
    {
        SceneManager.LoadScene("score"); // Asegúrate de que el nombre coincide exactamente
    }

    // Métodos para actualizar los resultados
    public void AddDamage(int damage)
    {
        totalDamage += damage;
    }

    public void AddTime(float time)
    {
        totalTime += time;
    }
    private void Update()
    {
        // Acumula el tiempo de juego en cada frame
        totalTime += Time.deltaTime;
    }
           
    public void AddCoin(int coins)
    {
        totalCoins += coins;
        Debug.Log("Monedas actuales: " + totalCoins); // Agrega esto para verificar en consola
    }

}
