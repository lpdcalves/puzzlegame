using UnityEngine;
using System.Collections;

public class Plantinha : MonoBehaviour {

	public Animator animator;

	void OnTriggerEnter2D (Collider2D col) {

		if (col.tag == "Sol") {

			col.transform.parent = this.gameObject.transform;
			col.transform.localPosition = new Vector3 (0.1f, 0.2f);
			animator.SetBool ("sol", true);
			col.GetComponent<SolAgua>().usou = true;
		}

		if (col.tag == "Agua") {
			
			col.transform.parent = this.gameObject.transform;
			col.transform.localPosition = new Vector3 (-0.1f, 0.2f); 
			animator.SetBool ("agua", true);
			col.GetComponent<SolAgua>().usou = true;
		}
	}
}
