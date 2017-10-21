using UnityEngine;
using System.Collections;

public class box : MonoBehaviour {
	
    //script da caixa que o player 1 pode levantar

	bool segurando = false;
	public Rigidbody2D myRB;
	
	void OnTriggerStay2D (Collider2D col) {
		
        //se colidir com o objeto do player e o jogador apertar a letra E e o objeto não já estiver sendo segurado
		if (col.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.E) && !segurando) {
            
			Transform holder = col.gameObject.transform.Find("holder"); //objeto vazio posicionado na frente do player que simula a posicao onde a caixa vai ficar
			transform.parent =  holder; //coloca a caixa como filha do player 1
			myRB.isKinematic = true; //muda o sistema de interação física da caixa fazendo ela ser um objeto estático (nao sofre efeitos da fisica, nao tem peso etc)
			segurando = true;
			transform.position = new Vector3(holder.position.x,holder.position.y,holder.position.z); //move a caixa para a posição do objeto pai

		}
        
    }
	
	void Update () {
        

        //se o jogador apertar a letra C e está segurando o objeto ele solta
        if (Input.GetKeyDown(KeyCode.C) && segurando) {
            
			this.transform.parent = null; //faz a caixa não ter nenhum objeto pai
			this.myRB.isKinematic = false; //muda o sistema físico da caixa de volta para dinâmico
            segurando = false;


        }
	}

}