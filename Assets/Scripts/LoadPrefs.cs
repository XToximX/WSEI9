using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LoadPrefs : MonoBehaviour
{
    [Header("general settings")]
    [SerializeField] private bool canUse = false;
    [SerializeField] private MenuController menuController;

    [Header("volume")]
    //[SerializeField] private TMP_Text volumeTextValue = null;
    //[SerializeField] private Slider volumeSlider = null;

    [Header("Brightness")]
    [SerializeField] private Slider brightnessSlider = null;
    [SerializeField] private TMP_Text brightnessTextValue = null;

    [Header("Graphic settings")]
    [SerializeField] private TMP_Dropdown qualityDropdown;
    [SerializeField] private Toggle fullScreenToggle;

    [Header("sensitivity")]
    [SerializeField] private TMP_Text ControllerSenTextValue = null;
    [SerializeField] private Slider controllerSenSlider = null;

    private void Awake()
    {
        if(canUse)
        {
            /*if (PlayerPrefs.HasKey("masterVolume"))
            {
                float localVolume = PlayerPrefs.GetFloat("masterVolume");

                volumeTextValue.text = localVolume.ToString("0.0");
                volumeSlider.value = localVolume;
                AudioListener.volume = localVolume;
            }
            else
            {
                menuController.resetButton("Audio");
            }*/

            if (PlayerPrefs.HasKey("masterQuality"))
            {
                int localQuality = PlayerPrefs.GetInt("masterQuality");
                qualityDropdown.value = localQuality;
                QualitySettings.SetQualityLevel(localQuality);
            }
            if (PlayerPrefs.HasKey("masterFullScreen"))
            {
                int localFullScreen = PlayerPrefs.GetInt("masterFullScreen");

                if(localFullScreen == 1)
                {
                    Screen.fullScreen = true;
                    fullScreenToggle.isOn = true;
                }
                else
                {
                    Screen.fullScreen = false;
                    fullScreenToggle.isOn = false;
                }
            }

            if (PlayerPrefs.HasKey("masterBrightness"))
            {
                float localBrightness = PlayerPrefs.GetFloat("masterBrightness");

                brightnessTextValue.text = localBrightness.ToString("0.0");
                brightnessSlider.value = localBrightness;
            }
            if (PlayerPrefs.HasKey("masterSen"))
            {
                float localSensitivity = PlayerPrefs.GetFloat("masterSen");

                ControllerSenTextValue.text = localSensitivity.ToString("0");
                controllerSenSlider.value = localSensitivity;
                menuController.mainControllerSen = Mathf.RoundToInt(localSensitivity);
            }
        }
    }
}
