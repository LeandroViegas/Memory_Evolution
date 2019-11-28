using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionRamac : MonoBehaviour {


    bool explosion = false;
    GameObject Enemy = null;
    float time = 0.5f;
    float timer = 0f;
    float radius  = 0;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Enemy != null && !explosion && time > 0f && timer < 2f)
        {
            Enemy.GetComponent<Actions>().Damage(10);
            explosion = true; 
        }
        time -= Time.deltaTime;
        timer += Time.deltaTime;
        radius += Time.deltaTime / 4.71f * 10f;
        GetComponent<CircleCollider2D>().radius = radius;
    }

     private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Datas>() != null)
            if (collision.GetComponent<Datas>().team.team1 == true)
                Enemy = collision.gameObject;                
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<Datas>() != null)
            if (collision.GetComponent<Datas>().team.team1 == true)
                Enemy = collision.gameObject;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Datas>() != null)
            if (collision.GetComponent<Datas>().team.team1 == true)
                Enemy = null;
    }
}
