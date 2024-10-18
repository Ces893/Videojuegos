using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager1 : MonoBehaviour
{
    public static GameManager1 instance;

    public int coinCount = 0;
    public TextMeshProUGUI coinText; // Texto solo para la cantidad de monedas

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddCoin()
    {
        coinCount++;
        coinText.text = coinCount.ToString(); // Actualiza solo la cantidad de monedas
    }
}
