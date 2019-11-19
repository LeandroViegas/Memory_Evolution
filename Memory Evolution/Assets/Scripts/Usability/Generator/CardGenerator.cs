using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardGenerator : MonoBehaviour {

    List<ObjectGenerator> childs;
    float timer = 5f;
	// Use this for initialization
	void Start () {
        childs = new List<ObjectGenerator>();
        for (int i = 0; i < transform.childCount; i++)
        {
            childs.Add(transform.GetChild(i).GetComponent<ObjectGenerator>());
        }
    }

    /* && FindObjectsOfType<life>().Length < 3 && FindObjectOfType<cardGenerator>().generated < FindObjectOfType<cardGenerator>().maxGenerate*/

    // Update is called once per frame
    void Update () {
        if(timer > 0)
            timer -= Time.deltaTime;
        else
            timer = 0;
        
	}


}
