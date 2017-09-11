using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

	public GameObject target;
	public Animator targetAnimator;

	private SpriteRenderer spriteRenderer;

	public Sprite nonPressedButton;
	public Sprite pressedButton;

	private string quemSubiu = "";

	void Awake() {

		spriteRenderer = gameObject.GetComponent<SpriteRenderer> ();
		targetAnimator = target.GetComponent<Animator>();
	}
	void OnTriggerEnter2D (Collider2D col) {

		if ((col.gameObject.tag == "Player" || col.gameObject.tag == "Box" || col.gameObject.tag == "Player2") && quemSubiu == "") {

			Acction(1);
			spriteRenderer.sprite = pressedButton;
			quemSubiu = col.gameObject.tag;
		}
	}

	void OnTriggerExit2D (Collider2D col) {
		if (col.gameObject.tag == quemSubiu) {
			Acction(2);
			spriteRenderer.sprite = nonPressedButton;
			quemSubiu = "";
		}
	}

	void Acction (int key) {
		if(target.gameObject.tag == "porta" && key == 1) {
			//faz açao numero 1 da porta, por enquanto desativar
			target.SetActive(false);
		}
		if(target.gameObject.tag == "porta" && key == 2) {
			//faz açao numero 1 da porta, por enquanto desativar
			target.SetActive(true);
		}
		if(target.gameObject.tag == "mola" && key == 1) {
			//faz açao numero 1 da mola que e subir
			targetAnimator.SetBool("subindo", true);
		}
		if(target.gameObject.tag == "mola" && key == 2) {
			//faz açao numero 2 da mola que e descer
			targetAnimator.SetBool("descendo", true);
		}
	}
}
