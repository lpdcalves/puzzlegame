using UnityEngine;
using System.Collections;

public class SolAgua : MonoBehaviour {
	
	public Vector3 target;
	public float speed;
	public bool usou = false;
	bool segurando = false;
	string quemTaSegurando;

	void Update () {

		if (usou) {
			transform.localPosition = Vector3.Lerp (transform.localPosition, target, 2);
		}

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
	}

	void OnTriggerEnter2D (Collider2D col) {

		if ((col.gameObject.tag == "Player2" || col.gameObject.tag == "Player") && !usou && !segurando) {
			
			Transform holder = col.gameObject.transform.Find("holder");
			transform.parent =  holder;
			segurando = true;
			transform.position = new Vector3(holder.position.x,holder.position.y,holder.position.z);
			quemTaSegurando = col.tag;
			
			
		}
	}
}
