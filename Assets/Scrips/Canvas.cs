using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Canvas : MonoBehaviour
{
    public GameObject[] vidas;
    public TextMeshProUGUI TextMeshProUGUI;
    // Start is called before the first frame update
    void Start(){

    }
    // Update is called once per frame
    void Update(){
        TextMeshProUGUI.text = "Monedas : " + GameManager.Instance.MonedasTotales.ToString();
    }
    public void DesactivarVida(int indice){
        vidas[indice].SetActive(false);
    }
    public void ActivarVida(int indice){
        vidas[indice].SetActive(true);
    }

}
