using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class stepManager : MonoBehaviour
{
    [HideInInspector]
    public bool triggered = false;
    [HideInInspector]
    public string text;
    [HideInInspector]
    public TextMeshPro textObject;

    private void Start()
    {
        textObject = transform.GetChild(0).gameObject.GetComponent<TextMeshPro>();
        text = textObject.text;
    }

    void OnTriggerEnter(Collider c)
    {
        selectElement();
    }

    void OnTriggerExit(Collider c)
    {
        deselectElement();
    }

    public void selectElement()
    {
        transform.parent.GetComponent<questionScript>().deselectAll();
        GameObject.Find("VoiceRecognizer").GetComponent<voiceSelection>().answer = Answer.None;
        textObject.color = new Color(255, 0, 0);
        triggered = true;
    }

    public void deselectElement()
    {
        textObject.color = new Color(255, 255, 255);
        triggered = false;
    }
}
