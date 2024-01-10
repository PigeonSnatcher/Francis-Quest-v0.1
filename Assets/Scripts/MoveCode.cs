using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCode : MonoBehaviour
{
    public GroundedScript groundedScript;
    float movementSpeed = 5f;
    float jumpSpeed = 500f;
    Rigidbody2D rb;
    Animator anim;
    public SpriteRenderer renderer;
    public bool movementEnabled = true;
    private void Start()
    {
        rb = GetComponent < Rigidbody2D > ();
        anim = GetComponent<Animator>();
        renderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if (movementEnabled)
        {
            rb.gravityScale = 2.1f;
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.position += Vector3.left * movementSpeed * Time.deltaTime;
                anim.SetBool("running", true);
                renderer.flipX = false;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.position += Vector3.right * movementSpeed * Time.deltaTime;
                anim.SetBool("running", true);
                renderer.flipX = true;
            }
            else
            {
                anim.SetBool("running", false);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                if (groundedScript.grounded)
                {
                    movementSpeed = 3f;
                }
            }
            if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                movementSpeed = 6f;
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (groundedScript.grounded)
                {
                    rb.AddForce(Vector3.up * jumpSpeed);
                }
            }
        }
    }
}
