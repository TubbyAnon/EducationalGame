using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class OptionMenu : MonoBehaviour {

    public AudioMixer audiomix;
    public Dropdown resolutionDropdown;


    Resolution[] resolutions;

    private void Start()
    {
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();
        int curentRes = 0;
        for ( int i = 0; i < resolutions.Length; i ++ )
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);


            if ((resolutions[i].width  == Screen.currentResolution.width) &&
                (resolutions[i].height == Screen.currentResolution.height))
            {
                curentRes = i;
            }
        }
         



        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = curentRes;
        resolutionDropdown.RefreshShownValue();

    }

    public void setResolution(int resIndex)
    {
        Resolution resolution = resolutions[resIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);


    }

    public void ChangeVolume(float volume)
    {
        audiomix.SetFloat("volume", volume);
    }

    public void ChangeQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void FullScreen(bool full)
    {
        Screen.fullScreen = full;
    }
}
