using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCalc : MonoBehaviour
{
    // Start is called before the first frame update
    public static int finalScore = 0;
    static int BoosterStruck = -1;
    static int StopperStruck = -1;
    static int RampStruck = -1;
    static int distanceScore = -1;
    static int speedScore = -1;
    public Text boosterS;
    public Text stopperS;
    public Text rampS;
    public Text distanceBonus;
    public Text speedBonus;
    public Text totalScore;
    static bool startBooster = false;
    static bool startStopper = false;
    static bool startRamp = false;
    static bool startDistance = false;
    static bool startSpeed = false;
    static bool end = false;
    public static int i = 0;
    public AudioSource scoreSound;

    void Start()
    {
        Debug.Log("Starting Score");
        //ScoreCalculator();
        startBooster = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(startBooster == true){
        
            //boosterS.text = "Boosters hit: " + i.ToString();
            //i+=1;
            scoreSound.Play();
            int check = incrementScore(boosterS, BoosterStruck, "Boosters hit: ");
            if(check == 0){
                startBooster = false;
                startStopper = true;
                scoreSound.Stop();
            }
        }

        if(startStopper == true){
            scoreSound.Play();
            int check = decrementScore(stopperS, StopperStruck, "Stoppers hit: ");
            if(check == 0){
                startStopper = false;
                startRamp = true;
                scoreSound.Stop();
            }
        }

        if(startRamp == true){
            scoreSound.Play();
            int check = incrementScore(rampS, RampStruck, "Ramps hit: ");
            if(check == 0){
                startRamp = false;
                startDistance = true;
                scoreSound.Stop();
            }
        }

        if(startDistance == true){
            scoreSound.Play();
            int check = incrementScore(distanceBonus, distanceScore, "Distance traveled: ");
            if(check == 0){
                startDistance = false;
                startSpeed = true;
                scoreSound.Stop();
            }
        }

        if(startSpeed == true){
            scoreSound.Play();
            int check = incrementScore(speedBonus, speedScore, "Final speed: ");
            if(check == 0){
                startSpeed = false;
                end = true;
                scoreSound.Stop();
            }
        }
        if(end == true){
            scoreSound.Play();
            int check = incrementScore(totalScore, finalScore, "Final score: ");
            if(check == 0){
                end = false;
                scoreSound.Stop();
            }
        }

    }

    int incrementScore(Text t, int s, string f){
        if(s == 0){
            t.text = f + "0";
            
            
            i = 0;
            return 0;
        }
        else if(s > 0 && i < s){
            t.text = f + i.ToString();
            i+=100;
            
            
        }
        else{
            t.text = f + i.ToString();
            i = 0;
            return 0;
        }

        //Debug.Log("Exit increment");
        return 1;
    }

    int decrementScore(Text t, int s, string f){
        if(s == 0){
            t.text = f + "0";
            
            
            i = 0;
            return 0;
        }
        else if(i > s){
            t.text = f + i.ToString();
            i-=100;
        }
        else{
            t.text = f + i.ToString();
            i = 0;
            return 0;
        }

        return 1;
    }

    public static void ScoreCalculator(){
        BoosterStruck = 100 * RolyPolyScript.boosterHit;
        StopperStruck = -200 * RolyPolyScript.stopperHit;
        RampStruck = 250 * RolyPolyScript.rampHit;
        distanceScore = 10 * (int)Mathf.Ceil(GameSpeed.origDistance) - (int)Mathf.Ceil(GameSpeed.curDistance);
        speedScore = 500 * (int)Mathf.Ceil(GameSpeed.finalSpeed);
        finalScore = BoosterStruck + StopperStruck + RampStruck + distanceScore + speedScore;
        Debug.Log(BoosterStruck + StopperStruck + RampStruck + distanceScore + speedScore);

    }

    public static void displayScore(){
        Debug.Log("Displaying score");
        startBooster = true;
        
        
    }
}
