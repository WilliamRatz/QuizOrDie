using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class questionScript : MonoBehaviour
{
    public GameObject[] portals;
    private GameObject[] answerSteps;
    public int rightAnswer = 0;
    private TextMeshPro textMesh;

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
        for (int i = 0; i<answerSteps.Length; ++i)
        { 
            if(answerSteps[i].transform.position.y <= -1.75)
            {
                Debug.Log(answerSteps[i].transform.position.y);
                if(i == rightAnswer)
                {
                    textMesh.text = "Right";
                    enablePortals();
                }
                else
                {
                    textMesh.text = "Wrong";
                }
                textMesh.text += "\nAnswer: " + answerSteps[rightAnswer].GetComponentInChildren<TextMeshPro>().text;
                turnOffAllTriggers();
                return;
            }
        }
    }

    void turnOffAllTriggers()
    {
        foreach(GameObject answer in answerSteps)
        {
            answer.transform.Find("collider").gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }
    void enablePortals()
    {
        foreach (GameObject portal in portals)
        {
            portal.GetComponent<portal>().portable= true;
        }
    }

    public void setupQuestion(string[] questionAndAnswer)
    {
        Debug.Log(questionAndAnswer.Length);
        textMesh.text = questionAndAnswer[0];
        answerSteps[0].GetComponentInChildren<TextMeshPro>().text = questionAndAnswer[1];
        answerSteps[1].GetComponentInChildren<TextMeshPro>().text = questionAndAnswer[2];
        answerSteps[2].GetComponentInChildren<TextMeshPro>().text = questionAndAnswer[3];
        answerSteps[3].GetComponentInChildren<TextMeshPro>().text = questionAndAnswer[4];
    }
}
