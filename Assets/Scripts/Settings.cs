using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine;


public class Settings : MonoBehaviour
{
    public static Settings singleton;

    public AudioMixer audioMixer;
    public Text qualityText;
    public Dropdown resolutionDropDown;
    public Slider masterSlider;
    public Slider soundSlider;
    public Slider musicSlider;
    public Toggle isFullscreen;

    Resolution[] resolutions;

    private int quality;

    void Awake()
    {
        singleton = this;
    }

    void Start() // Used to initialize saved settings
    {
        resolutions = Screen.resolutions;
        resolutionDropDown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = (int)PlayerSave.singleton.setting_resolutionIndex;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropDown.AddOptions(options);
        resolutionDropDown.value = currentResolutionIndex;
        resolutionDropDown.RefreshShownValue();

        LoadSettings();

    }

    public void LoadSettings()
    {
        // Load Quality Settings
        quality = (int)PlayerSave.singleton.setting_quality;
        QualitySettings.SetQualityLevel(quality);
        SetQualityText();

        // Load Audio Volumes
        float volume = PlayerSave.singleton.setting_masterVolume;
        SetMasterVolume(volume);
        masterSlider.value = volume;
        volume = PlayerSave.singleton.setting_soundVolume;
        SetSoundVolume(volume);
        soundSlider.value = volume;
        volume = PlayerSave.singleton.setting_musicVolume;
        SetMusicVolume(volume);
        musicSlider.value = volume;

        //Load FullScreen
        if ((int)PlayerSave.singleton.setting_isFullscreen == 1)
        {
            isFullscreen.isOn = true;
        }
        else
        {
            isFullscreen.isOn = false;
        }

        //Set Resolution
        resolutions = Screen.resolutions;

        resolutionDropDown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = (int)PlayerSave.singleton.setting_resolutionIndex;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropDown.AddOptions(options);
        resolutionDropDown.value = currentResolutionIndex;
        resolutionDropDown.RefreshShownValue();

        SetResolution((int)PlayerSave.singleton.setting_resolutionIndex);
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        PlayerSave.singleton.setting_resolutionIndex = resolutionIndex;
    }

    public void SetMasterVolume(float volume)
    {
        audioMixer.SetFloat("masterVolume", volume);
        PlayerSave.singleton.setting_masterVolume = volume;
    }

    public void SetSoundVolume(float volume)
    {
        audioMixer.SetFloat("soundVolume", volume);
        PlayerSave.singleton.setting_soundVolume = volume;
    }

    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("musicVolume", volume);
        PlayerSave.singleton.setting_musicVolume = volume;
    }

    public void LowerQuality()
    {
        if (quality == 0)
        {
            Debug.Log("Lowest setting ...");
        }
        else
        {
            PlayerSave.singleton.setting_quality--;
            quality = (int)PlayerSave.singleton.setting_quality;
            QualitySettings.SetQualityLevel(quality);

            SetQualityText();
        }

    }

    public void HigherQuality()
    {
        if (quality == 2)
        {
            Debug.Log("Highest setting ...");
        }
        else
        {
            PlayerSave.singleton.setting_quality++;
            quality = (int)PlayerSave.singleton.setting_quality;
            QualitySettings.SetQualityLevel(quality);

            SetQualityText();
        }

    }

    void SetQualityText()
    {
        if (quality == 0)
        {
            qualityText.text = "Current: Low";
        }
        else if (quality == 1)
        {
            qualityText.text = "Current: Medium";
        }
        else
        {
            qualityText.text = "Current: Heigh";
        }
    }

    public void SetFullScreen(bool isFullscreen)
    {
        if (isFullscreen == true)
        { PlayerSave.singleton.setting_isFullscreen = 1; }
        else
        { PlayerSave.singleton.setting_isFullscreen = 0; }

        Screen.fullScreen = isFullscreen;
    }

}
