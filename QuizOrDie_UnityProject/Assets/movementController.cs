using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementController : MonoBehaviour
{

    public float movementSpeed = 1;
    public float jumpIntensity = 2.5f;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    private bool jumpPossible = true;
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
        movement();
    }

    private void movement()
    {
        float h = Input.GetAxisRaw("Horizontal");

        if (Input.GetButton("Jump") && (rBody.velocity.y == 0 || jumpPossible))
        {
            rBody.velocity = Vector3.up * jumpIntensity;
            jumpPossible = false;
        }

        movementVector = new Vector3(h * movementSpeed, rBody.velocity.y, 0);
        //running
        rBody.velocity = movementVector;

        //jumping
        if (rBody.velocity.y < 0)
        {
            rBody.velocity += Vector3.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rBody.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rBody.velocity += Vector3.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        jumpPossible = true;
    }
}
