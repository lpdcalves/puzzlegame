using UnityEngine;
using System.Collections;

public class PlayerController2 : MonoBehaviour {


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
        if (Input.GetKeyDown(Controller.jump2) && (grounded))
        {

            myRigidBody2D.AddForce(new Vector2(0, forcaPulo), ForceMode2D.Impulse);
            myRigidBody2D.gravityScale = 3;
            animationPlayer2.SetBool("jump",true);


        }
        else
        {
            animationPlayer2.SetBool("jump", false);
        }
        
        if (Input.GetKey(Controller.walkLeft2))
        { //Se o A(Ele chama o script Controls que é estatico) for apertado ele vai ativar a animação de correr.
            animator.SetBool("walking", true);
            transform.Translate(new Vector3(-velocidade * Time.deltaTime, 0, 0));
            if (right)
            {
                Flip();
            }

        }

        else if (Input.GetKey(Controller.walkRight2))
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
            animator.SetBool("walking", false);
        }


    }

    private void Flip()
    {
        // Troca pra onde o player ta olhando.
        right = !right;
        // Vira o player .
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }


}