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
        voiceSelection();

        if (Input.GetKeyDown(KeyCode.Return))
        {
            for (int i = 0; i < answerSteps.Length; ++i)
            {
                if (answerSteps[i].GetComponentInChildren<stepManager>().triggered == true)
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
    }

    private void voiceSelection()
    {
        if (validAnswer())
        {
            if (stage != 2)
            {
                for (int i = 0; i < answerSteps.Length; ++i)
                {
                    if (answerSteps[i].GetComponentInChildren<stepManager>().text == global::voiceSelection.answerText)
                    {
                        answerSteps[i].GetComponentInChildren<stepManager>().selectElement();
                    }
                    else
                    {
                        answerSteps[i].GetComponentInChildren<stepManager>().deselectElement();
                    }
                }
            }
            else
            {
                for (int i = 0; i < answerSteps.Length; ++i)
                {
                    if (answerSteps[i].GetComponentInChildren<stepManager>().text == "13" && global::voiceSelection.answerText == "thirteen" ||
                        answerSteps[i].GetComponentInChildren<stepManager>().text == "7" && global::voiceSelection.answerText == "seven" ||
                        answerSteps[i].GetComponentInChildren<stepManager>().text == "15" && global::voiceSelection.answerText == "fifteen" ||
                        answerSteps[i].GetComponentInChildren<stepManager>().text == "20" && global::voiceSelection.answerText == "twenty")
                    {
                        answerSteps[i].GetComponentInChildren<stepManager>().selectElement();
                    }
                    else
                    {
                        answerSteps[i].GetComponentInChildren<stepManager>().deselectElement();
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
    void turnOffAllTriggers()
    {
        foreach (GameObject answer in answerSteps)
        {
            answer.GetComponent<BoxCollider>().enabled = false;
        }
    }

    public void deselectAll()
    {
        foreach (GameObject answer in answerSteps)
        {
            answer.GetComponent<stepManager>().deselectElement();
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
