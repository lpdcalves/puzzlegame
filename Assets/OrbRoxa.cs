using UnityEngine;
using System.Collections;

public class OrbRoxa : MonoBehaviour {

	bool segurando = false;
	string quemTaSegurando = "";

	void OnTriggerEnter2D (Collider2D col) {

		if ((col.gameObject.tag == "Player2" || col.gameObject.tag == "Player") && !segurando) {

			Transform holder = col.gameObject.transform.FindChild("holder");
			transform.parent =  holder;
			segurando = true;
			transform.position = new Vector3(holder.position.x,holder.position.y,holder.position.z);
			quemTaSegurando = col.tag;

			
		}
	}

	void Update () {

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
}


//VAI SE FUDEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEERRRRRRRRRRRRRRRRRRRRRRRRRRRRRRR