using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trovão : MonoBehaviour {

    public GameObject raio;
    float time;
	// Use this for initialization
	void Start () {
        time = Random.Range(5f,8f);
	}
	
	// Update is called once per frame
	void Update () {
        if(time > 0)
            time -= Time.deltaTime;
        if(time <= 0)
        {
            GameObject raioObject = Instantiate(raio,transform);
            raioObject.GetComponent<SpriteRenderer>().sortingOrder = -32766;
            time = Random.Range(5f, 8f);
            Destroy(raioObject, 0.5f);
        }
	}
}
