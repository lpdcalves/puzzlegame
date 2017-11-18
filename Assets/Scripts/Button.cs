using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

	public GameObject target; //variável para possibilitar associar um objeto (porta, mola etc...) a esse script através do unity
	public Animator targetAnimator; //variável para pegar o Animator do nosso target

	private SpriteRenderer spriteRenderer;

    public bool MovesRight; //variável para saber se o meu botão move algum objeto para a direita
    public bool Single = true; //variável para saber se o meu botão faz parte de um conjunto com outro botão ou se ele só aciona um objeto

    public Sprite nonPressedButton; //pega os sprites (imagens) para quando o botão está e não está apertado
	public Sprite pressedButton;

	private string quemSubiu = ""; //variável para saber quem subiu no botão e só desativer quando esse alguem sair

	void Awake() {

		spriteRenderer = gameObject.GetComponent<SpriteRenderer> (); //variavel que mudará o sprite do botão
		targetAnimator = target.GetComponent<Animator>(); //animator do target para permitir acionar animações
	}
	void OnTriggerEnter2D (Collider2D col) {

        //se algum player, ou uma caixa, estiver em contado com o botão ele vai chamar a ação número 1

		if ((col.gameObject.tag == "Player" || col.gameObject.tag == "Box" || col.gameObject.tag == "Player2") && quemSubiu == "") {

			Acction(1);
			spriteRenderer.sprite = pressedButton; //chama o sprite do botão apertado
			quemSubiu = col.gameObject.tag; //define quem subiu para evitar que duas pessoas apertem o mesmo botão
		}
	}

	void OnTriggerExit2D (Collider2D col) {
		if (col.gameObject.tag == quemSubiu) {
			Acction(2);
			spriteRenderer.sprite = nonPressedButton; //chama o sprite do botão levantado
            quemSubiu = ""; //define quem subiu como nulo para que outro objeto possa apertar esse botão
        }
	}

	void Acction (int key) {
		if(target.gameObject.tag == "porta" && key == 1) {
			//faz açao numero 1 da porta, por enquanto desativar, mas posteriormente vai acionar a animação
			target.SetActive(false);
		}
		if(target.gameObject.tag == "porta" && key == 2) {
            //faz açao numero 1 da porta, por enquanto desativar, mas posteriormente vai acionar a animação
            target.SetActive(true);
		}
		if(target.gameObject.tag == "mola" && key == 1) {
			//faz açao numero 1 da mola que e subir

			targetAnimator.SetBool("subindo", true); //aciona o bool responsável por acionar a animação de subir (animação da mola ainda um pouco bugada)
            targetAnimator.SetBool("descendo", false);
        }

		if(target.gameObject.tag == "mola" && key == 2) {
			//faz açao numero 2 da mola que e descer
			targetAnimator.SetBool("descendo", true); //aciona o bool responsável por acionar a animação de subir
            targetAnimator.SetBool("subindo", false);
        }

        if (target.gameObject.tag == "plataforma" && key == 1 && !Single && MovesRight)
        {
            //faz mover plataforma para direita
            target.GetComponent<Plataforma>().movingRight = true;
        }

        if (target.gameObject.tag == "plataforma" && key == 2 && !Single && MovesRight)
        {
            //faz parar de mover a plataforma
            target.GetComponent<Plataforma>().movingRight = false;
        }

        if (target.gameObject.tag == "plataforma" && key == 1 && !Single && !MovesRight)
        {
            //faz mover plataforma para direita
            target.GetComponent<Plataforma>().movingLeft = true;
        }

        if (target.gameObject.tag == "plataforma" && key == 2 && !Single && !MovesRight)
        {
            //faz parar de mover a plataforma
            target.GetComponent<Plataforma>().movingLeft = false;
        }

        if (target.gameObject.tag == "placa" && key == 1)
        {
            //faz açao numero 1 da placa (abrir)

            targetAnimator.SetBool("hiding", false); //aciona o bool responsável por acionar a animação de abrir
        }

        if (target.gameObject.tag == "placa" && key == 2)
        {
            //faz açao numero 2 da placa (fechar)
            targetAnimator.SetBool("hiding", true); //aciona o bool responsável por acionar a animação de fechar
        }
    }
}
