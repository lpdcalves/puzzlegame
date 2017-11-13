using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mola : MonoBehaviour {

    private Animator animator;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

	}

    void OnTriggerStay2D(Collider2D col)
    {

        //se colidir com o objeto do player e a animação de subindo estiver ativa (equivalente a dizer que a mola está ativada)
        if ((col.gameObject.tag == "Player" || col.gameObject.tag == "Player2") && animator.GetBool("subindo"))
        {
            Rigidbody2D playerRB = col.gameObject.GetComponent<Rigidbody2D>(); // pega o rigidbody(componente que cuida das interações físicas) do player que entrou em contato com a mola
            playerRB.AddForce(new Vector2(0, 9), ForceMode2D.Impulse); //dá um impulso ao player para cima
            //playerRB.gravityScale = 3;
        }

    }
}
