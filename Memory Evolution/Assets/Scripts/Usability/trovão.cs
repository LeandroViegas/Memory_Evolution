using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trovão : MonoBehaviour {

    public GameObject raio;
    float time;
	// Use this for initialization
	void Start () {
        time = Random.Range(5f,10f);
	}
	
	// Update is called once per frame
	void Update () {
        if(time > 0)
            time -= Time.deltaTime;
        if(time <= 0)
        {
            GameObject raioObject = Instantiate(raio,transform);
            Destroy(raioObject, 0.5f);
            time = Random.Range(10f, 20f);
        }
	}
}
