using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControler : MonoBehaviour
{
    public float maxLeftX;
    public float maxRightX;

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = new Vector3(0, transform.localPosition.y, transform.localPosition.z);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, maxLeftX,maxRightX), transform.position.y, transform.position.z);
    }
}
