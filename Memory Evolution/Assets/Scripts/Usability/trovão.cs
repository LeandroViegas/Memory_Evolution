using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trovão : MonoBehaviour {

    public GameObject raio;
    float time;
    public float minTime = 5f;
    public float maxTime = 8f;
	// Use this for initialization
	void Start () {
        time = Random.Range(minTime, maxTime);
	}
	
	// Update is called once per frame
	void Update () {
        if(time > 0)
            time -= Time.deltaTime;
        if(time <= 0)
        {
            GameObject raioObject = Instantiate(raio,transform);
            raioObject.GetComponent<SpriteRenderer>().sortingOrder = -32766;
            time = Random.Range(minTime, maxTime);
            Destroy(raioObject, 0.5f);
        }
	}
}
