using UnityEngine;
using System.Collections;

public class CheckGround2 : MonoBehaviour {

    // mesma coisa do checkGround só que esse é para o player 2
    PlayerController2 playerController2;    
    void Awake()
    {
            playerController2 = GameObject.FindGameObjectWithTag("Player2").GetComponent<PlayerController2>();           
      
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Jumpable")
        {           
            playerController2.grounded = true;
           
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Jumpable")
        {
           playerController2.grounded = false;
        }
    }
}

