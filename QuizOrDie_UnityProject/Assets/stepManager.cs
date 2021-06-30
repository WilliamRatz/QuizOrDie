using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stepManager : MonoBehaviour
{
    private float speed = 0.002f;
    public float movement = 0f;

    void OnTriggerStay(Collider c)
    {
        movement -= speed;
        this.transform.parent.gameObject.transform.position -= Vector3.up * speed;
    }
}
