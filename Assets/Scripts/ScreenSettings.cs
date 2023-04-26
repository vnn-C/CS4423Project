using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenSettings : MonoBehaviour
{
    public Dropdown screenDropdown;
    Resolution[] resolutions;
    public Toggle fullScreen;
    // Start is called before the first frame update
    void Start()
    {
        resolutions = Screen.resolutions;
        fullScreen.isOn = Screen.fullScreen;

        for(int i = 0; i<resolutions.Length; i++){
            string resString = resolutions[i].width.ToString() + "x" + resolutions[i].height.ToString();
            screenDropdown.options.Add(new Dropdown.OptionData(resString));

            if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height){
                screenDropdown.value = i;
            }
        }
    }

    // Update is called once per frame
    public void setResolution(){
        Screen.SetResolution(resolutions[screenDropdown.value].width, resolutions[screenDropdown.value].height, fullScreen.isOn);
    }
}
