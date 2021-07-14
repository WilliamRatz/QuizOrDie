using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Timer : MonoBehaviour
{
    public GameObject textDisplay;
    public int timeLeft=50;
    public bool cdown =false;
    public static bool startGame = false;
  

    void Start()
    {
        if (timeLeft > 59)
        {
            textDisplay.GetComponent<Text>().text = ((int)(timeLeft / 60)).ToString();

            if (timeLeft < 10)
            {
                textDisplay.GetComponent<Text>().text += ":0" + timeLeft % 60;
            }
            else
            {
                textDisplay.GetComponent<Text>().text += ":" + timeLeft % 60;
            }
        }
        else
        {
            if (timeLeft % 60 < 10)
            {
                textDisplay.GetComponent<Text>().text = "0:0" + timeLeft % 60;
            }
            else
            {
                textDisplay.GetComponent<Text>().text = "0:" + timeLeft % 60;
            }
        }
    }

    void Update(){
        if (!startGame)
            return;


        if (cdown==false && timeLeft>0){
            StartCoroutine(TimerTake());
        }else if(timeLeft==0){
         
         SceneManager.LoadScene("YouLost");}
    }

    IEnumerator TimerTake()
    {
        cdown=true;
        yield return new WaitForSeconds(1);
        timeLeft -=1;

        if(timeLeft > 59)
        {
            textDisplay.GetComponent<Text>().text = ((int)(timeLeft/60)).ToString();

            if (timeLeft < 10)
            {
                textDisplay.GetComponent<Text>().text += ":0" + timeLeft%60;
            }
            else{
                textDisplay.GetComponent<Text>().text += ":" + timeLeft % 60;
            }
        }
        else
        {
            if (timeLeft < 10)
            {
                textDisplay.GetComponent<Text>().text += ":0" + timeLeft % 60;
            }
            else
            {
                textDisplay.GetComponent<Text>().text += ":" + timeLeft % 60;
            }
        }
        
        cdown=false;
    }

}
  