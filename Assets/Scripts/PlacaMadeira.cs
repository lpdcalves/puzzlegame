using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacaMadeira : MonoBehaviour {

    public GameObject target; //alvo vai ser um orbe roxo
    public bool hiding = true; //variavel que é igual a variavel hiding do animator

    // Use this for initialization
    void Start ()
    {
        gameObject.GetComponent<Animator>().SetBool("hiding", true); //coloca hiding como true
    }
	
	// Update is called once per frame
	void Update () {

        hiding = gameObject.GetComponent<Animator>().GetBool("hiding");

        //se hiding = true (a placa estiver escondendo o orbe roxo) desabilita o objeto do orbe roxo
        if (hiding)
        {
            target.SetActive(false);
        }
        else
        {
            target.SetActive(true);
        }
	}
}
