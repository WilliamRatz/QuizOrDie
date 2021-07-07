using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControler : MonoBehaviour
{
    public float maxLeftX;
    public float maxRightX;
    public float[] YPos;
    public static int counter = 0;

    // Update is called once per frame
    private void Start()
    {
        counter = 0;
    }
    void Update()
    {
        transform.localPosition = new Vector3(0, transform.localPosition.y, transform.localPosition.z);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, maxLeftX,maxRightX), YPos[counter], transform.position.z);
    }
}