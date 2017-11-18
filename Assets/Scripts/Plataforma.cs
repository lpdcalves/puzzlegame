using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma : MonoBehaviour {

    private SpriteRenderer spriteRenderer;

    public Sprite plaformParada; //pega os sprites (imagens) para quando a plataforma está ou não em movimento
    public Sprite plaformMovendo;

    public bool movingRight = false;
    public bool movingLeft = false;

    public float leftBorder;
    public float rightBorder;

    private void Awake()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>(); //variavel que mudará o sprite do botão
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (movingRight && (this.gameObject.transform.position.x < rightBorder) )
        {
            spriteRenderer.sprite = plaformMovendo;
            transform.Translate(new Vector3(1f * Time.deltaTime, 0, 0));
        }
        else if (movingLeft && (this.gameObject.transform.position.x > leftBorder))
        {
            transform.Translate(new Vector3(-1f * Time.deltaTime, 0, 0));
            spriteRenderer.sprite = plaformMovendo;
        }
        else
        {
            spriteRenderer.sprite = plaformParada;
        }
    }
}
