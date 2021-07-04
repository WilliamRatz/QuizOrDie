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
  

    void Start()
    {
       textDisplay.GetComponent<Text>().text ="00:"+ timeLeft;
    }

    void Update(){
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
        if(timeLeft<10){
            textDisplay.GetComponent<Text>().text ="00:0"+ timeLeft;
        }
        else{
        textDisplay.GetComponent<Text>().text ="00:"+ timeLeft;}
        cdown=false;
    }

}
  