using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisqueteBullet : MonoBehaviour {

    public bool available;
    // Use this for initialization
    void Start () {
        available = true;
	}
	
	// Update is called once per frame
	void Update () {
        transform.eulerAngles = new Vector3(1f,1f, (transform.eulerAngles.z + (1f * 4000 * Time.deltaTime)) );
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Datas>() != null && available)
        {
            if (collision.GetComponent<Datas>().team.player)
            {
                if (collision.GetComponent<Actions>() != null)
                {
                    collision.GetComponent<Actions>().Damage(20);
                    available = false;
                    Destroy(gameObject, 0.09f);
                }
            }
            if (collision.GetComponent<Datas>().collision.collision)
                Destroy(gameObject, 0.09f);
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<Datas>() != null && available)
        {
            if (collision.GetComponent<Datas>().team.player)
            {
                if (collision.GetComponent<Actions>() != null)
                {
                    collision.GetComponent<Actions>().Damage(20);
                    available = false;
                    Destroy(gameObject, 0.09f);
                }
            }
            if (collision.GetComponent<Datas>().collision.collision)
                Destroy(gameObject, 0.09f);
        }
    }
}
