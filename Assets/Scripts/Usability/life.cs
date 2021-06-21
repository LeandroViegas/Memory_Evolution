using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class life : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Datas>() != null)
            if (collision.gameObject.GetComponent<Datas>().team.player == true)
            {
                collision.gameObject.GetComponent<Datas>().principais.health += 20;
                Destroy(gameObject);
            }
                
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Datas>() != null)
            if (collision.gameObject.GetComponent<Datas>().team.player == true)
            {
                collision.gameObject.GetComponent<Datas>().principais.health += 20;
                Destroy(gameObject);
            }
                
    }
}
