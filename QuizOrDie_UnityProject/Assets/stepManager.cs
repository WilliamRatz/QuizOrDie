using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stepManager : MonoBehaviour
{
    private float speed = 0.002f;

    void OnTriggerStay(Collider c)
    {
        this.transform.parent.gameObject.transform.position -= Vector3.up * speed;
    }
}
