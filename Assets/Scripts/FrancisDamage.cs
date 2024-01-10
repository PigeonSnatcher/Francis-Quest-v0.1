using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FrancisDamage : MonoBehaviour
{
    MoveCode moveCode;
    Rigidbody2D rb;
    public bool damageable
    {
        get
        {
            return iTimer <= 0;
        }
    }
    public bool armored = true;
    public float iTime;
    float iTimer = 0;

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveCode = GetComponent<MoveCode>();
    }

    public void OnDamage(Vector2 knockbackForce)
    {
        if (!damageable)
        {
            return;
        }
        if (armored)
        {
            armored = false;
            iTimer = iTime;
            rb.AddForce(knockbackForce, ForceMode2D.Impulse);
        }
        else
        {
            //gameObject.SetActive(false);
            Die();
        }
    }

    private void Update()
    {
        iTimer -= Time.deltaTime;
        moveCode.enabled = damageable;
    }

    public void Die()
    {
        Debug.Log("Is this hell");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
