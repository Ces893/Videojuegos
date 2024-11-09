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
    public Animator animator;
    //private GameData gData;
    //private GameDataRepository gDataRepository;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
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
            animator.SetTrigger("Muerte");
            StartCoroutine(EjecutarMuerte());
        }
        //gDataRepository.SaveGame(gData);
        canvas.DesactivarVida(vidas);
    }

    private IEnumerator EjecutarMuerte()
    {
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

        SceneManager.LoadScene("MENOP");
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
