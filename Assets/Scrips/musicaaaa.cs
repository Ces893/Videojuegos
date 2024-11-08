using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class musicaaaa : MonoBehaviour
{
   [SerializeField]private AudioMixer audioMixer;
   public void ControlMusica (float sliderMusica)
   {
       audioMixer.SetFloat("musica", Mathf.Log10(sliderMusica)*20);
   }
   
}
