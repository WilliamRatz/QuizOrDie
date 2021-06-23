using System;
using System.Linq;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;


public class voiceSelection : MonoBehaviour
{
    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, Action> actions = new Dictionary<string, Action>();
    private AudioSource test;

    // Start is called before the first frame update
    void Start()
    {
        actions.Add("help", voiceHelp);
        actions.Add("nice", voiceNice);

        
        test = GetComponent<AudioSource>();
        test.clip = Microphone.Start(Microphone.devices[0].ToString(), true, 10, AudioSettings.outputSampleRate);
        while(!(Microphone.GetPosition(null) > 0)) {}
        test.Play();
        
        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray(), ConfidenceLevel.Medium);
        keywordRecognizer.OnPhraseRecognized += OnPhraseRecognized;
        keywordRecognizer.Start();
    }
    void Update()
    {
        Debug.Log(keywordRecognizer.IsRunning);
        Debug.Log(Microphone.devices[0]);
    }

    private void OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        Debug.Log(args.text);
        Debug.Log("aftasd");
        actions[args.text].Invoke();
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
