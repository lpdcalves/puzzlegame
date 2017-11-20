using UnityEngine;
using System.Collections;

public class OrbRoxa : MonoBehaviour {

    //script dos orbs roxos (chaves para portas)

	bool segurando = false;
	string quemTaSegurando = "";
    public Transform holder;
    private BoxCollider2D col;
    //private SpriteRenderer renderer;

    private void Start()
    {
        col = gameObject.GetComponent<BoxCollider2D>();
        //renderer = gameObject.GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D (Collider2D col) {

        //verifica se não tem ninguem segurando a orb, se não tiver ele coloca ela como filha do Holder do player 
        //O holder é um objeto invisível que fica flutuando na frente do player. Só serve para dar posição de onde as orbs/caixas vão ficar

		if ((col.gameObject.tag == "Player2" || col.gameObject.tag == "Player") && !segurando) {

			Transform holder = col.gameObject.transform.Find("holder");
			transform.parent =  holder;
			segurando = true;
			transform.position = new Vector3(holder.position.x,holder.position.y,holder.position.z);
			quemTaSegurando = col.tag;

			
		}
	}

	void Update () {
        //verifica se a orb tá sendo segurada, se estiver verifica quem está segurando e se a respectiva tecla desse player for apertada ele solta a orb

        if (segurando) {

			if (quemTaSegurando == "Player" && Input.GetKeyDown (Controller.dropBob)) {

				this.transform.parent = null;
				segurando = false;
			}

			if (quemTaSegurando == "Player2" && Input.GetKeyDown (Controller.dropJoe)) {
				
				this.transform.parent = null;
				segurando = false;
			}
		}        

        if (holder)
        {
            if (holder.tag == "placa" && (holder.GetComponent<Animator>().GetBool("hiding") == true))
            {
                col.enabled = false;
                //renderer.enabled = false;
                Debug.Log("false");
            }

            if (holder.tag == "placa" && (holder.GetComponent<Animator>().GetBool("hiding") == false))
            {
                col.enabled = true;
                //renderer.enabled = true;
                Debug.Log("true");
            }
        }
    }
}