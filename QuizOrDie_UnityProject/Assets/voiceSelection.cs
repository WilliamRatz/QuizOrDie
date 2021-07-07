using System;
using System.Linq;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;

public enum Answer
{
    None,
    True,
    False,
}

public class voiceSelection : MonoBehaviour
{
    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, Action> actions = new Dictionary<string, Action>();
    public int questionAnswer = -1;
    public Answer answer = Answer.None;
    public static String answerText = "";

    // Start is called before the first frame update
    void Start()
    {
        actions.Add("carrot", rightAnswer);
        actions.Add("apple", wrongAnswer);
        actions.Add("banana", wrongAnswer);
        actions.Add("lemon", wrongAnswer);

        actions.Add("thirteen", rightAnswer);
        actions.Add("seven", wrongAnswer);
        actions.Add("fifteen", wrongAnswer);
        actions.Add("twenty", wrongAnswer);

        actions.Add("penis", rightAnswer);
        actions.Add("toe", wrongAnswer);
        actions.Add("finger", wrongAnswer);
        actions.Add("ear", wrongAnswer);

        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray(), ConfidenceLevel.Medium);
        keywordRecognizer.OnPhraseRecognized += OnPhraseRecognized;
        keywordRecognizer.Start();
    }
    void Update()
    {
        Debug.Log(answerText);
    }

    private void OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        answerText = args.text;

        if(answerText == "carrot" || answerText == "apple" || answerText == "banana" || answerText == "lemon")
        {
            questionAnswer = 0;
        }else if (answerText == "penis" || answerText == "toe" || answerText == "finger" || answerText == "ear")
        {
            questionAnswer = 1;
        }
        else if (answerText == "seven" || answerText == "thirteen" || answerText == "fifteen" || answerText == "twenty")
        {
            questionAnswer = 2;
        }
        actions[args.text].Invoke();
    }
    public void resetAnswer()
    {
        answer = Answer.None;
    }
    private void wrongAnswer()
    {
        answer = Answer.False;
        Debug.Log("Wrong answer");
    }
    private void rightAnswer()
    {
        answer = Answer.True;
        Debug.Log("Wrong answer");
    }


}
