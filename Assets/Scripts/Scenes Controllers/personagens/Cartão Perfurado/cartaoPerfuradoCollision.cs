using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cartaoPerfuradoCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), GetComponentInParent<Collider2D>());
        if (collision.gameObject.GetComponent<Datas>() != null)
            if (!collision.gameObject.GetComponent<Datas>().collision.collision)
                Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collision.gameObject.GetComponent<Collider2D>());
        if(collision.gameObject.GetComponent<cartaoPerfuradoCollision>() != null)
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collision.gameObject.GetComponent<Collider2D>());
    }
}
