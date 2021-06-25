using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class gameMaker : MonoBehaviour
{
    public GameObject[] questionObjects;
    string[,] questionsAndAnswers;
    int questionCount;

    // Start is called before the first frame update
    void Start()
    {
        //Load a text file (Assets/Resources/Questions.txt)
        TextAsset textFile = Resources.Load<TextAsset>("Questions");
        questionCount = textFile.ToString().Split('\n').Length;
        questionsAndAnswers = new string[questionCount, 5];
        splitTextToQuestions(textFile.ToString());
        chooseRandomeQuestions();
    }

    private void chooseRandomeQuestions()
    {
        List<int> choosenOnes = new List<int>();
        foreach (GameObject gO in questionObjects)
        {
            int choosen = Random.Range(0,choosenOnes.Count);
            while (choosenOnes.Contains(choosen))
                choosen = Random.Range(0, choosenOnes.Count);
            choosenOnes.Add(choosen);
            gO.GetComponent<questionScript>().setupQuestion(new string[]{questionsAndAnswers[choosen, 0], 
                                                                         questionsAndAnswers[choosen, 1], 
                                                                         questionsAndAnswers[choosen, 2], 
                                                                         questionsAndAnswers[choosen, 3], 
                                                                         questionsAndAnswers[choosen, 4], });
        }
    }

    // Update is called once per frame
    void splitTextToQuestions(string textFile)
    {
        for (int i = 0; i < questionCount; ++i)
        {
            questionsAndAnswers[i, 0] = textFile.Split('\n')[i].Split(';')[0];
            questionsAndAnswers[i, 1] = textFile.Split('\n')[i].Split(';')[1];
            questionsAndAnswers[i, 2] = textFile.Split('\n')[i].Split(';')[2];
            questionsAndAnswers[i, 3] = textFile.Split('\n')[i].Split(';')[3];
            questionsAndAnswers[i, 4] = textFile.Split('\n')[i].Split(';')[4];
           // questionsAndAnswers[i, 5] = textFile.Split('\n')[i].Split(';')[3];
            Debug.Log("Question: " + questionsAndAnswers[i,0]);
            Debug.Log("     Answers: " + questionsAndAnswers[i,1] + ", " + questionsAndAnswers[i, 2] + ", " + questionsAndAnswers[i, 3]  + ", " + questionsAndAnswers[i, 4]);
        }
    }
}
