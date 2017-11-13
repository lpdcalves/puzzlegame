using UnityEngine;
using System.Collections;
using System;

public class CheckGround2 : MonoBehaviour {

    // mesma coisa do checkGround só que esse é para o player 2
    PlayerController2 playerController2;

    public string[] tagsPulaveis = { "Jumpable", "Box", };

    void Awake()
    {
            playerController2 = GameObject.FindGameObjectWithTag("Player2").GetComponent<PlayerController2>();           
      
    }
    void OnTriggerStay2D(Collider2D col)
    {
        if (Array.IndexOf(tagsPulaveis, col.gameObject.tag) >= 0)
        {           
            playerController2.grounded = true;
           
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (Array.IndexOf(tagsPulaveis, col.gameObject.tag) >= 0)
        {
           playerController2.grounded = false;
        }
    }
}

