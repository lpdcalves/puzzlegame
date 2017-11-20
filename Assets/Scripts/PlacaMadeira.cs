using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacaMadeira : MonoBehaviour {
    
    public bool hiding = true; //variavel que é igual a variavel hiding do animator

    // Use this for initialization
    void Start ()
    {
        gameObject.GetComponent<Animator>().SetBool("hiding", true); //coloca hiding como true
    }
	
	// Update is called once per frame
	void Update () {

        hiding = gameObject.GetComponent<Animator>().GetBool("hiding");

	}
}
