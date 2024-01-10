using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySwing : MonoBehaviour, FrancisDetectorListener
{
    public float attackTime;
    float attackTimer = 0f;
    public float dmgTimeStart;
    public float dmgTimeEnd;
    HurtBox hurtBox;

    EnemyMove enemyMove;
    bool swinging
    {
        get {
            return attackTimer > 0f;
        }
    }
    public void OnFrancisDetected()
    {
        //Debug.Log("I C U");
        if (attackTimer <= 0)
        {
            attackTimer = attackTime;
            enemyMove.canMove = false;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        hurtBox = GetComponentInChildren<HurtBox>();
        enemyMove = GetComponent<EnemyMove>();
    }

    // Update is called once per frame
    void Update()
    {
        attackTimer -= Time.deltaTime;
        if (attackTimer < dmgTimeStart)
        {
            //Debug.Log("top 10 hurbox moments");
            hurtBox.gameObject.SetActive(true);
        }
        if (attackTimer < dmgTimeEnd)
        {
            hurtBox.gameObject.SetActive(false);
        }
        if (attackTimer < 0)
        {
            enemyMove.canMove = true;
        }
    }
}
