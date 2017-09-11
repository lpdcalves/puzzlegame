using UnityEngine;
using System.Collections;

public class ArtificialGravity : MonoBehaviour {
	
	void Update () {

		this.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, -9.8f), ForceMode2D.Force);
	}
}
