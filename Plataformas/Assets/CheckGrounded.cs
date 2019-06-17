using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGrounded : MonoBehaviour
{

    private PlayerController player;
    
    void Start()
    {
        player = GetComponentInParent<PlayerController>();
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            player.grounded = true;    
        }
    }
    
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            player.grounded = false;    
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
