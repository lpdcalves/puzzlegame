using UnityEngine;
using System.Collections;

public class CheckGround : MonoBehaviour {


    
    PlayerController playerController;      

    
    void Awake()
    {

        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>(); //acha o player controller baseado na Tag do player

      
    }
    //função padrão do unity que é acionada enquanto o objeto que contem esse script estiver em colisão com outro que possua um colisor atribuido a ele
    void OnTriggerStay2D(Collider2D col)
    {
        //verifica se o objeto em contato tem a tag "pulável"
        if (col.gameObject.tag == "Jumpable")
        {
            playerController.grounded = true; //variável que determina se o player pode ou não pular
        }
    }
    //função padrão do unity que é acionada quando o objeto que contem esse script para de estar em colisão com outro objeto
    void OnTriggerExit2D(Collider2D col)
    {
        //checa se o objeto que ele deixou de encostar é "pulável"
        if (col.gameObject.tag == "Jumpable" )
        {
            playerController.grounded = false;
           
        }
    }
}

