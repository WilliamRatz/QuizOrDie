using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Timer : MonoBehaviour
{
    public GameObject textDisplay;
    public int timeLeft=80;
    public bool cdown =false;
    public int timeLeft2 = 20;
    public static bool startGame = false;
  

    void Start()
    {
         
       textDisplay.GetComponent<Text>().text ="01:"+ timeLeft2;
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
        timeLeft2 -=1;

        if(timeLeft<10){
            textDisplay.GetComponent<Text>().text ="00:0"+ timeLeft;
        }
        else if(timeLeft<60) {
        textDisplay.GetComponent<Text>().text ="00:"+ timeLeft;}
        else{
            textDisplay.GetComponent<Text>().text ="01:"+ timeLeft2;
        }
        
        cdown=false;
    }

}
  
