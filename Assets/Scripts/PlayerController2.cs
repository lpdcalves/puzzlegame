using UnityEngine;
using System.Collections;

public class PlayerController2 : MonoBehaviour {

    //declara atributos importantes para a movimentação do player2
    private bool right = true;
    public float velocidade = 1f;
    public Rigidbody2D myRigidBody2D;
    public Animator animator;
    public float forcaPulo;

    public bool grounded;

    public Animator animationPlayer2;

	public BoxCollider2D boxCollider;

	void Start () {

		Physics2D.IgnoreCollision (GetComponent<BoxCollider2D> (), boxCollider);
	}

    void Update()
    {
		Physics2D.IgnoreCollision (GetComponent<BoxCollider2D> (), boxCollider);

        //se o jogador apertar a tecla W e o personagem estiver num chão pulável dá play na animação e faz ele pular
        if (Input.GetKeyDown(KeyCode.UpArrow) && (grounded))
        {

            myRigidBody2D.AddForce(new Vector2(0, forcaPulo), ForceMode2D.Impulse);
            myRigidBody2D.gravityScale = 3;
            animationPlayer2.SetBool("jump",true);

        }
        else
        {
            animationPlayer2.SetBool("jump", false); //garante que animação de pulo não vai estar ativa enquanto ele está no chão
        }

        //anda para a esquerda se apertar a seta da esquerda
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            animator.SetBool("walking", true);
            transform.Translate(new Vector3(-velocidade * Time.deltaTime, 0, 0));

            if (right)
            {
                Flip();
            }

        }

        //anda para a direita se apertar a seta da direita
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            animator.SetBool("walking", true);
            transform.Translate(new Vector3(velocidade * Time.deltaTime, 0, 0));

            if (!right)
            {
                Flip();
            }
        }

        else
        {
            animator.SetBool("walking", false); //evita que a animação de andar esteja ativa com o boneco parado
        }


    }

    private void Flip()
    {
        // Troca pra onde o player ta olhando.
        right = !right;
        // Vira o player.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }


}