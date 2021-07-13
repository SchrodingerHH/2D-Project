using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;
using System.Linq;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] AudioMixerGroup masterMixer;
    [SerializeField] GameObject soundPanel;
    bool menuActive = false;

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape) && menuActive==false)
        {
            soundPanel.SetActive(true);
            menuActive = true;
            Time.timeScale = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && menuActive==true)
        {
            soundPanel.SetActive(false);
            menuActive = false;
            Time.timeScale = 1;
        }
    }

    public void VolumeChange(float volume)
    {
        masterMixer.audioMixer.SetFloat("MasterVolume",volume);
    }



}
