using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Audio : MonoBehaviour
{
    [SerializeField] private AudioMixer music;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider musicSlider2;

    public void SetMusicVolume()
    {
        float volume = musicSlider.value;
        float volume2 = musicSlider2.value;
        music.SetFloat("music", Mathf.Log10(volume) * 20);
        music.SetFloat("effects", Mathf.Log10(volume2) * 20);
    }

    /*public void Music(float sliderMusic)
    {
        music.SetFloat("music", Mathf.Log10(sliderMusic) * 20);
    }*/
}
