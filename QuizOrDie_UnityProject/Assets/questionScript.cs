using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class questionScript : MonoBehaviour
{
    public GameObject[] portals;
    public GameObject[] answerSteps;
    public int rightAnswer = 0;
    private TextMeshPro textMesh;

    void Start()
    {
        textMesh = GetComponent<TextMeshPro>();
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
}
