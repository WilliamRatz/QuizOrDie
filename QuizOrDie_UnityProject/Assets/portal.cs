using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portal : MonoBehaviour
{
    public bool portable = false;
    public GameObject endPortal;

    void OnCollisionEnter(Collision collision)
    {
        if (!portable)
            return;


        Timer.startGame = true;
        ++CamControler.counter;

        if (collision.gameObject.layer == 6 /*Layer Player*/)
        {
            collision.gameObject.transform.position = endPortal.transform.position + transform.InverseTransformDirection(Vector3.right);
        }
    }
}
