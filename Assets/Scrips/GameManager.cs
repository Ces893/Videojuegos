using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public Canvas canvas;
    private int vidas = 3;
    public int MonedasTotales { get { return monedas; } }
    private int monedas = 0;
    //private GameData gData;
    //private GameDataRepository gDataRepository;
    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            //gDataRepository = new GameDataRepository();
            //gData = gDataRepository.LoadGame();
        }
        else
        {
            Debug.Log("Error");
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
        Debug.Log(monedas);
    }
}
