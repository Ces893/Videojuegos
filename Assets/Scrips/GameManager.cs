using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public Canvas canvas;
    public TextMeshProUGUI coinText;
    private int vidas = 3;
    public int MonedasTotales { get { return monedas; } }
    public int TotalDamage { get { return totalDamage; } }
    private int monedas = 0;
    private int totalDamage = 0;
    public float tiempo;
    //private GameData gData;
    //private GameDataRepository gDataRepository;
    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            //gDataRepository = new GameDataRepository();
            //gData = gDataRepository.LoadGame();
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            Debug.Log("Error");
        }
    }

    public void AddDamage(int damage)
    {
        totalDamage += damage;
    }

    public int GetMonedasTotales()
    {
        return monedas;
    }

    public void CompleteLevel()
    {
        SceneManager.LoadScene("score");
    }
    private void Update()
    {
        tiempo += Time.deltaTime;
    }

    public int GetTotalDamage()
    {
        return totalDamage;
    }

    public void ResetMonedas()
    {
        monedas = 0;
        if (coinText != null)
        {
            coinText.text = ":0" + monedas.ToString();
        }
        else
        {
            Debug.LogWarning("coinText no está asignado en GameManager.");
        }
    }
    public void perderVida()
    {
        vidas -= 1;
        if (vidas == 0)
        {
            SceneManager.LoadScene(2);
        }
        //gDataRepository.SaveGame(gData);
        canvas.DesactivarVida(vidas);
    }
    public bool RecuperarVida()
    {
        if (vidas == 3) { return false; }
        canvas.ActivarVida(vidas);
        vidas += 1;
        //gDataRepository.SaveGame(gData);
        return true;
    }
    public void AddCoin(int valor)
    {
        monedas += valor;
        if (coinText != null)
        {
            coinText.text = ":0" + monedas.ToString();
        }
        else
        {
            Debug.LogWarning("coinText no está asignado en GameManager.");
        }
        Debug.Log(monedas);
    }
}
