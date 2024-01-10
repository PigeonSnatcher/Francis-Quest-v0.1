using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public GameObject francis;
    private float speed = 2f;
    public bool facingLeft = true;
    HurtBox hurtBox;
    public bool canMove = true;
    // Start is called before the first frame update
    void Start()
    {
        hurtBox = GetComponentInChildren<HurtBox>();
        hurtBox.gameObject.transform.localPosition = new Vector2(-0.64f, 0.14f);
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            if (facingLeft)
            {
                transform.position += Vector3.left * speed * Time.deltaTime;
            }
            else
            {
                transform.position += Vector3.right * speed * Time.deltaTime;
            }
            var rayHit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - 0f), facingLeft ? Vector2.left : Vector2.right, 1f);
            if (rayHit.collider != null && rayHit.collider.gameObject != francis)
            {
                facingLeft = !facingLeft;
                hurtBox.gameObject.transform.localPosition = new Vector2(-hurtBox.gameObject.transform.localPosition.x, hurtBox.gameObject.transform.localPosition.y);
            }
        }
    }
}
