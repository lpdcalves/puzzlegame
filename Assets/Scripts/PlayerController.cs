using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    //declara atributos importantes para a movimentação do player
    private bool right = true;
    public float velocidade = 1f;
    public Rigidbody2D myRigidBody2D;
    public Animator animator;
    public float forcaPulo;

    public bool grounded;

    public Animator animationPlayer;

    //função do unity que é chamada a cada frame
    void Update()
    {
        //se o jogador apertar a tecla W e o personagem estiver num chão pulável
        if (Input.GetKeyDown(KeyCode.W) && (grounded))
        {
            //dá play na animação de pulo e gera uma força no objeto para cima (faz ele pular)
            animationPlayer.SetBool("jump", true);
            myRigidBody2D.AddForce(new Vector2(0, forcaPulo), ForceMode2D.Impulse);
            //myRigidBody2D.gravityScale = 3;
        }

        else
        {
            animationPlayer.SetBool("jump", false); //garante que animação de pulo não vai estar ativa enquanto ele está no chão
        }
        
        if (Input.GetKey(KeyCode.A))
        { //Se o A(Ele chama o script Controls que é estatico) for apertado ele vai ativar a animação de correr. 
          //script controlls desativado temporariamente porque estava instável no executável e substituido pelo getkey
            
            //dá play na animação de andar e "translada" o objeto para a esquerda
            animator.SetBool("walking", true);
            transform.Translate(new Vector3(-velocidade * Time.deltaTime, 0, 0));

            //se quando o jogador for andar para a esquerda o boneco estiver olhando para a direita aciona a função de virar ele
            if (right)
            {
                Flip();
            }
        }


        else if (Input.GetKey(KeyCode.D))
        {
            
            //dá play na animação de andar e "translada" o objeto para a direita
            animator.SetBool("walking", true);
            transform.Translate(new Vector3(velocidade * Time.deltaTime, 0, 0));

            //se quando o jogador for andar para a direita o boneco estiver olhando para a esquerda aciona a função de virar ele
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

