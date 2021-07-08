using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;
public class questionScript : MonoBehaviour
{
    public bool lastStage = false;
    public GameObject[] portals;
    private GameObject[] answerSteps;
    public int rightAnswer = 0;
    public int stage = 0;
    private TextMeshPro textMesh;
    private bool done = false;
    private bool voiceAnswered = false;
    void Start()
    {
        textMesh = GetComponent<TextMeshPro>();
        answerSteps = new GameObject[] { this.transform.GetChild(0).gameObject,
                                         this.transform.GetChild(1).gameObject,
                                         this.transform.GetChild(2).gameObject,
                                         this.transform.GetChild(3).gameObject };
    }
    // Update is called once per frame
    void Update()
    {
        if (done)
            return;

        //check speach
        voiceRecognition();
        if (voiceAnswered)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                if (voiceAnswerTrue())
                {
                    wonQuestion();
                    turnOffAllTriggers();
                    return;
                }
                else
                {
                    looseScreen();
                    return;
                }
            }
        }

        //check blocks
        for (int i = 0; i < answerSteps.Length; ++i)
        {
            if (answerSteps[i].GetComponentInChildren<stepManager>().movement <= -0.6)
            {
                if (i == rightAnswer)
                {
                    wonQuestion();
                }
                else
                {
                    looseScreen();
                }

                textMesh.text += "\nAnswer: " + answerSteps[rightAnswer].GetComponentInChildren<TextMeshPro>().text;
                turnOffAllTriggers();
                return;
            }
        }
    }

    private void voiceRecognition()
    {
        if (validAnswer())
        {
            if (stage != 2)
            {
                for (int i = 0; i < answerSteps.Length; ++i)
                {
                    if (answerSteps[i].GetComponentInChildren<TextMeshPro>().text == voiceSelection.answerText)
                    {
                        answerSteps[i].GetComponentInChildren<TextMeshPro>().color = new Color(255, 0, 0);
                        voiceAnswered = true;
                    }
                    else
                    {
                        answerSteps[i].GetComponentInChildren<TextMeshPro>().color = new Color(255, 255, 255);
                    }
                }
            }
            else
            {
                for (int i = 0; i < answerSteps.Length; ++i)
                {
                    if (answerSteps[i].GetComponentInChildren<TextMeshPro>().text == "13" && voiceSelection.answerText == "thirteen" ||
                        answerSteps[i].GetComponentInChildren<TextMeshPro>().text == "7" && voiceSelection.answerText == "seven" ||
                        answerSteps[i].GetComponentInChildren<TextMeshPro>().text == "15" && voiceSelection.answerText == "fifteen" ||
                        answerSteps[i].GetComponentInChildren<TextMeshPro>().text == "20" && voiceSelection.answerText == "twenty")
                    {
                        answerSteps[i].GetComponentInChildren<TextMeshPro>().color = new Color(255, 0, 0);
                        voiceAnswered = true;
                    }
                    else
                    {
                        answerSteps[i].GetComponentInChildren<TextMeshPro>().color = new Color(255, 255, 255);
                    }
                }
            }
        }

    }

    private void wonQuestion()
    {
        textMesh.text = "Right";
        if (lastStage)
        {
            winScreen();
        }
        else
        {
            enablePortals();
            GameObject.Find("VoiceRecognizer").GetComponent<voiceSelection>().resetAnswer();
        }
    }

    private bool validAnswer()
    {
        return (GameObject.Find("VoiceRecognizer").GetComponent<voiceSelection>().answer == Answer.False ||
                GameObject.Find("VoiceRecognizer").GetComponent<voiceSelection>().answer == Answer.True) &&
                GameObject.Find("VoiceRecognizer").GetComponent<voiceSelection>().questionAnswer == stage;
    }

    private bool voiceAnswerTrue()
    {
        return GameObject.Find("VoiceRecognizer").GetComponent<voiceSelection>().answer == Answer.True &&
                 GameObject.Find("VoiceRecognizer").GetComponent<voiceSelection>().questionAnswer == stage;
    }

    void turnOffAllTriggers()
    {
        foreach (GameObject answer in answerSteps)
        {
            answer.transform.Find("collider").gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }
    void enablePortals()
    {
        done = true;
        foreach (GameObject portal in portals)
        {
            portal.GetComponent<portal>().portable = true;
        }
    }

    void looseScreen()
    {
        done = true;
        textMesh.text = "Wrong";
        SceneManager.LoadScene("YouLost");
    }
    private void winScreen()
    {
        done = true;
        SceneManager.LoadScene("YouWon");
    }
}
