using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Работа с интерфейсами
using UnityEngine.SceneManagement; //Работа со сценами
using UnityEngine.Audio; //Работа с аудио

public class Settings : MonoBehaviour
{
    public float volume = 0; //Громкость
    public int quality = 0; //Качество
    private bool isFullscreen; //Полноэкранный режим
    public AudioMixer audioMixer; //Регулятор громкости
    public Dropdown resolutionDropdown; //Список с разрешениями для игры
    private Resolution[] resolutions; //Список доступных разрешений
    private Resolution res;
    private int currResolutionIndex = 0; //Текущее разрешение
    
    void Start()
    {
        isFullscreen = true;
        //Screen.SetResolution(1280, 720, true, 60);
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        resolutions = Screen.resolutions;
        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);
            if (resolutions[i].width == Screen.currentResolution.width
                  && resolutions[i].height == Screen.currentResolution.height)
                currentResolutionIndex = i;
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void ChangeVolume(float val) //Изменение звука
    {
        volume = val;
    }

    public void ChangeResolution(int index) //Изменение разрешения
    {
        currResolutionIndex = index;
        Resolution res = resolutions[index];
        Screen.SetResolution(res.width, res.height, isFullscreen, 60);
    }

    public void ChangeFullscreenMode(bool index) //Включение или отключение полноэкранного режима
    {
        isFullscreen = index;
        Screen.fullScreen=index;
        //Screen.SetResolution(Screen.width, Screen.height, index, 60);
    }

    public void ChangeQuality(int index) //Изменение качества
    {
        quality = index;
    }
    public void SaveSettings(){
        //audioMixer.SetFloat("MasterVolume", volume); //Изменение уровня громкости
        //Screen.SetResolution(res.width, res.height, isFullscreen, 60);
    }
}

