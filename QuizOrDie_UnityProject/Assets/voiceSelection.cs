using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;


public class voiceSelection : MonoBehaviour
{
    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, Action> actions = new Dictionary<string, Action>();

    // Start is called before the first frame update
    void Start()
    {
        actions.Add("help", voiceHelp);
        actions.Add("nice", voiceNice);

        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += recognizedSpeech;
        keywordRecognizer.Start();
        Debug.Log(keywordRecognizer.IsRunning);
    }

    private void recognizedSpeech(PhraseRecognizedEventArgs speech)
    {
        Debug.Log(speech.text);
        actions[speech.text].Invoke();
    }
    private void voiceHelp()
    {
        Debug.Log("HELP!!");
    }
    private void voiceNice()
    {
        Debug.Log("Nice");
    }


}
