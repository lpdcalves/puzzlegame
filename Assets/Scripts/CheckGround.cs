using UnityEngine;
using System.Collections;

public class CheckGround : MonoBehaviour {


    
    PlayerController playerController;      

    void Awake()
    {

        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

      
    }
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Jumpable")
        {
            playerController.grounded = true;

            
           
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Jumpable" )
        {
            playerController.grounded = false;

            
           
        }
    }
}

