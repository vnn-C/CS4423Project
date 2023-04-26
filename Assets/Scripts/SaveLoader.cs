using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SaveSystem.Initialize("default.bin");
        

    }

    // Update is called once per frame
    void SaveMusic(float master, float music, float sfx){
        SaveSystem.SetFloat("masterVol",master);
        SaveSystem.SetFloat("musicVol",music);
        SaveSystem.SetFloat("sfxVol",sfx);
        SaveSystem.SaveToDisk();
    }
}
