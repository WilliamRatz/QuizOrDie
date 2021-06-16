using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementController : MonoBehaviour
{

    public float movementSpeed = 1;
    private Vector3 movementVector;

    private Rigidbody rBody;

    // Start is called before the first frame update
    private void Awake()
    {
        rBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");

        movementVector = new Vector3(h, 0, 0);

        movementVector = movementVector.normalized * movementSpeed * Time.deltaTime;
        rBody.MovePosition(transform.position + movementVector);
    }
}
