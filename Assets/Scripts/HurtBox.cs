using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtBox : MonoBehaviour
{
    public GameObject francis;
    EnemyMove enemyMove;
    // Start is called before the first frame update
    void Start()
    {
        enemyMove = GetComponentInParent<EnemyMove>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject == francis)
        {
            francis.GetComponent<FrancisDamage>().OnDamage(new Vector2(enemyMove.facingLeft ? -10:10,5));
        }
    }
}
