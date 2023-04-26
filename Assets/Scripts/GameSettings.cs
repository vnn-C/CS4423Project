using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class GameSettings : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider masterVol;
    public Slider sfxVol;
    public Slider musicVol;

    // Start is called before the first frame update
    void Start()
    {
        
        setVolume("masterVol", PlayerPrefs.GetFloat("masterVol", (float)0.5));
        setVolume("musicVol", PlayerPrefs.GetFloat("musicVol", (float)0.5));
        setVolume("sfxVol", PlayerPrefs.GetFloat("sfxVol", (float)0.5));
        masterVol.value = PlayerPrefs.GetFloat("masterVol", (float)0.5);
        musicVol.value = PlayerPrefs.GetFloat("musicVol", (float)0.5);
        sfxVol.value = PlayerPrefs.GetFloat("sfxVol", (float)0.5);
    }

    // Update is called once per frame
    public void setMaster(){
        setVolume("masterVol", masterVol.value);
    }
    public void setMusic(){
        setVolume("musicVol", musicVol.value);
    }
    public void setSFX(){
        setVolume("sfxVol", sfxVol.value);
    }

    void setVolume(string name, float value){
        float vol = Mathf.Log10(value) * 20;
        if(value == 0){
            vol = -80;
        }
        audioMixer.SetFloat(name,vol);
        PlayerPrefs.SetFloat(name,value);
    }
}
