using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 10;
    public bool timerIsRunning = false;
    
    [SerializeField]
    private TextMeshProUGUI firstMinute;

    [SerializeField]
    private TextMeshProUGUI secondMin;
    [SerializeField]
    private TextMeshProUGUI seperator;
    [SerializeField]
    private TextMeshProUGUI firstSec;
    [SerializeField]
    private TextMeshProUGUI secondSec;
    
    private float timeStart = 0;
    private float timer;
    private float flashTimer;
    private float flashDuration = 1f;
    [SerializeField]
    private bool countDown = true;
    private float timeDuration = 3000f;


    void Start()
    {
        // Starts the timer automatically

        timerIsRunning = true;
        ResetTimer();
    }

    void Update()
    {

           if(countDown && timer > 0 ){

                timer -= Time.deltaTime;
                UpdateTimer(timer);
            }else if(!countDown && timer < timeDuration){
                timer += Time.deltaTime;
                UpdateTimer(timer);

            }else{
                Flash();
            }
            
    }
            

/*
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
            }
        }
    }
*/
    public void ResetTimer(){
        if(countDown){
            timer = timeDuration;
        }else{
       timer= 0;
        }
        SetTextDisplay(true);
    }

    public void UpdateTimer(float time){
        float minute = Mathf.FloorToInt(time/60);
        float seconds = Mathf.FloorToInt(time %60);

        string currentTime = string.Format("{00:00}{1:00}", minute, seconds);
        firstMinute.text =  currentTime[0].ToString();
        secondMin.text =  currentTime[1].ToString();

    
       
        firstSec.text =  currentTime[2].ToString();
        secondSec.text =  currentTime[3].ToString();
        
        
        
    }

    public void Re(){
       firstMinute.text =  "0";
        secondMin.text =  "0";

    
       
        firstSec.text =  "0";
        secondSec.text =  "0";
    }

    public void Flash(){
        if(timer != 0){
            timer = 0;
            UpdateTimer(timer);
        }

        if(flashTimer <=0){
            flashTimer = flashDuration;
            }else if(flashTimer >= flashDuration /2){
                flashTimer -= Time.deltaTime;
                SetTextDisplay(false);
            }else{
                flashTimer -= Time.deltaTime;
                SetTextDisplay(false);
            }
        
    }

    private void SetTextDisplay(bool enabled){
       firstMinute.enabled = enabled;
        secondMin.enabled = enabled;
        firstSec.enabled = enabled;
        secondSec.enabled = enabled;
    }
    
}