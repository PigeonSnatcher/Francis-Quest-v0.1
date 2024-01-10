using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundedScript : MonoBehaviour
{
    public bool grounded = true;
    // Start is called before the first frame update
    private void OnTriggerStay2D(Collider2D other)
    {
        grounded = true;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        grounded = false;
    }
}
