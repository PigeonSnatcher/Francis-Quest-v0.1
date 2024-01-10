using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanScript : MonoBehaviour
{
    public float fanPower;
    public bool fanY;
    public bool fanX;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay(Collider other)
    {
        if (other.attachedRigidbody)
        {
            if (fanY)
            {
                other.attachedRigidbody.AddForce(Vector2.up * fanPower);
            }
            if (fanX)
            {
                other.attachedRigidbody.AddForce(new Vector2(1, 0) * fanPower);
            }
        }
    }
}