using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class socar : MonoBehaviour {

    // Use this for initialization
    public Animator animator;
    public float atack = 0f;

    void Start () {
        animator = GetComponent<Animator>();
        if (atack > 0f)
            atack -= Time.deltaTime;
    }
	
	// Update is called once per frame
	void Update () {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<Datas>())
            if(atack <= 0)
                if(collision.gameObject.GetComponent<Datas>().team.player == true)
                {
                    collision.gameObject.GetComponent<Datas>().principais.health -= 40;
                    atack = 1f;
                }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Datas>())
            if (atack <= 0)
                if (collision.gameObject.GetComponent<Datas>().team.player == true)
                {
                    collision.gameObject.GetComponent<Datas>().principais.health -= 40;
                    atack = 1f;
                }
    }
}
