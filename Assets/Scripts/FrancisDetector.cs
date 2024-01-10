using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrancisDetector : MonoBehaviour
{
    EnemyMove moveCode;
    public GameObject player;
    //public bool 
    //public Vector2 castdirection = Vector2.right;
    // Start is called before the first frame update
    FrancisDetectorListener francisDetectorListener;
    void Start()
    {
        moveCode = GetComponent<EnemyMove>();
        francisDetectorListener = GetComponent<FrancisDetectorListener>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D detection = Physics2D.Raycast(transform.position, moveCode.facingLeft ? Vector2.left : Vector2.right, 1.5f);
        Debug.DrawRay(transform.position, moveCode.facingLeft ? Vector2.left : Vector2.right);
        //shout out to vs tooltips
        if (detection.collider != null && detection.collider.gameObject.name == player.name)
        {
            //Debug.Log("OMGS IS THAT FRANCES I BETER SWING MY SWORD MWEHEHEHEEH");
            francisDetectorListener.OnFrancisDetected();
        }
    }
}
