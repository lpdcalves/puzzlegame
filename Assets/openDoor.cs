using UnityEngine;
using System.Collections;

public class openDoor : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D col) {
		
		if (col.gameObject.tag == "orbRoxa") {
			
			Destroy(col.gameObject);
			Destroy(this.gameObject);
		}
	}
}
