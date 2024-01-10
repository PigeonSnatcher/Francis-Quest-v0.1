using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrancisDash : MonoBehaviour
{
    public MoveCode moveCode;
    public GroundedScript groundedScript;
    Rigidbody2D rb;
    float currentCooldown = 0f;
    float moveCooldown = 0f;
    float dashTimer = 0f;
    bool airdash = true;

    const float dashCooldown = 1f;
    const float maxDashTimer = 0.6f;
    const float maxMoveCooldown = 0.5f;

    bool canDash
    {
        get
        {
            return currentCooldown <= 0;
        }
    }
    bool isDashing
    {
        get
        {
            return dashTimer > 0;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        currentCooldown -= Time.deltaTime;
        dashTimer -= Time.deltaTime;
        moveCooldown -= Time.deltaTime;
        if (groundedScript.grounded)
        {
            airdash = true;
        }
        if (moveCooldown > 0)
        {
            moveCode.movementEnabled = false;
        }
        else
        {
            moveCode.movementEnabled = true;
        }
        if (canDash)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                if (airdash)
                {

                    dashTimer = maxDashTimer;
                    //var isFacingLeft = !moveCode.renderer.flipX;
                    currentCooldown = dashCooldown;
                    moveCooldown = maxMoveCooldown;
                    airdash = false;
                }


            }
        }
        if (isDashing)
        {
            rb.velocity = new Vector2(0, 0);
            var isFacingLeft = !moveCode.renderer.flipX;
            var dashDirection = isFacingLeft ? Vector2.left : Vector2.right;
            transform.Translate(10f * Time.deltaTime * dashDirection);
            rb.gravityScale = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isDashing)
        {
            if (collision.gameObject.layer == 3)
            {
                collision.gameObject.SetActive(false);
            }
        }
    }
}
