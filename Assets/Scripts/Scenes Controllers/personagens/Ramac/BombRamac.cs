using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombRamac : MonoBehaviour {

    public Vector2 target;
    public GameObject explosao;
    Rigidbody2D rg2d;

    // Use this for initialization
    void Start () {
        rg2d = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
		if((Vector2)transform.position == target)
        {
            Explosion();
        }
        else
        {
            rg2d.MovePosition(Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), target, Time.deltaTime * 8f));
        }
	}

    void Explosion()
    {
        GameObject esplosao1 = Instantiate(explosao, transform.position, transform.rotation);
        Destroy(gameObject);
        Destroy(esplosao1, 5f);
    }
}

