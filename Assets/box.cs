using UnityEngine;
using System.Collections;

public class box : MonoBehaviour {
	
	bool segurando = false;
	public Rigidbody2D myRB;
	
	void OnTriggerStay2D (Collider2D col) {
		
		if (col.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.E)) {

			Transform holder = col.gameObject.transform.FindChild("holder");
			transform.parent =  holder;
			myRB.isKinematic = true;
			segurando = true;
			transform.position = new Vector3(holder.position.x,holder.position.y,holder.position.z);
			
		}
	}
	
	void Update () {
		
		if (segurando) {
			
			if (Input.GetKeyDown (Controller.dropBob)) {
				
				this.transform.parent = null;
				this.myRB.isKinematic = false;

			}


			}
		}

}