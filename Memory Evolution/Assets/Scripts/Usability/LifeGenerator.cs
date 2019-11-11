using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeGenerator : MonoBehaviour {

    BoxCollider2D boxCol;
    public GameObject life;
    public float timer = 5f;
	// Use this for initialization
	void Start () {
        boxCol = GetComponent<BoxCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            Instantiate(life, new Vector3(Random.Range(transform.position.x - (boxCol.size.x / 2), transform.position.x + (boxCol.size.x / 2)), Random.Range(transform.position.y - (boxCol.size.y / 2), transform.position.y + (boxCol.size.y / 2)), 0f), Quaternion.identity);
            timer = 5f;
        }
	}
}
