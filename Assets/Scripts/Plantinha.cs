using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Plantinha : MonoBehaviour {

	public Animator animator;

    //script da planta para pegar os orbs de água e luz e tornar filhos da planta para que eles fiquem flutuando em volta dela

    float timer = 0.0f; // contador

    void OnTriggerEnter2D (Collider2D col) {

		if (col.tag == "Sol") {

            //col.GetComponent<SolAgua>().usou = true;
            col.transform.parent = this.gameObject.transform;
			col.transform.localPosition = new Vector3 (0.1f, 0.2f);
			animator.SetBool ("sol", true);
		}

		if (col.tag == "Agua") {

            //col.GetComponent<SolAgua>().usou = true;
            col.transform.parent = this.gameObject.transform;
			col.transform.localPosition = new Vector3 (-0.1f, 0.2f); 
			animator.SetBool ("agua", true);
			
		}
	}

    private void Update()
    {
        if (animator.GetBool("sol") && animator.GetBool("agua")) //verifica se as variaveis agua e sol que controlam a animação da planta são true
        {
            timer += Time.deltaTime; //inicia um contador

            if (timer >= 5.0f) //se o contador for maior que 5 segundos
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //carrega o proximo nível usando o index do nível atual + 1
            }
        }
    }
}
