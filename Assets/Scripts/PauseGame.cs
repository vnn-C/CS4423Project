using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour
{
    public GameObject pauseLayer;
    public GameObject menu;
    public Text limitText;
    public int speedLimit;
    // Start is called before the first frame update
    void Start()
    {
        limitText.text = "Speed Limit: " + speedLimit.ToString();
    }

    // Update is called once per frame
    void FixedUpdate(){
        if(Input.GetKey(KeyCode.Escape) && Time.timeScale == 1){
                Time.timeScale = 0;
                pauseLayer.SetActive(true);
                menu.SetActive(true);

        }
    }

    void Update()
    {
        //if(Input.GetKey(KeyCode.Escape) && Time.timeScale == 0){
                //Time.timeScale = 1;
        //}
    }
}
