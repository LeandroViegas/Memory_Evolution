using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class socar : MonoBehaviour {

    // Use this for initialization
    public Animator animator;

    void Start () {
        animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            gameObject.SetActive(false);
            animator.enabled = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<Datas>())
            if(collision.gameObject.GetComponent<Datas>().team.player == true)
                collision.gameObject.GetComponent<Datas>().principais.health -= 40;
    }
}
