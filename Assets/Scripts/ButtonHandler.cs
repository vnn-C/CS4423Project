using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pauseLayer;
    public GameObject menu;

    public void startGame(){
        SceneManager.LoadScene("LevelSelector");
    }

    public void loadMainMenu(){
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    public void changeSettings(){
        SceneManager.LoadScene("Settings");
    }

    public void quitGame(){
        Application.Quit();
    }

    public void levelOne(){
        SceneManager.LoadScene("SampleScene");
    }

    public void levelTwo(){
        SceneManager.LoadScene("LevelTwo");
    }
    
    public void levelThree(){
        SceneManager.LoadScene("LevelThree");
    }
    public void resumeGame(){
        Time.timeScale = 1;
        pauseLayer.SetActive(false);
        menu.SetActive(false);
    } 
    public void loadInstructions(){
        SceneManager.LoadScene("GameInstructions");
    }
    
}
