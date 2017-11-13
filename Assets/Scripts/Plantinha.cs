using UnityEngine;
using System.Collections;

public class Plantinha : MonoBehaviour {

	public Animator animator;

    //script da planta para pegar os orbs de água e luz e tornar filhos da planta para que eles fiquem flutuando em volta dela

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
}
