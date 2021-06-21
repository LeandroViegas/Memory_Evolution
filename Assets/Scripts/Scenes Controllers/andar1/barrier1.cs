using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barrier1 : MonoBehaviour {

    bool x = false;
	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        CardGenerator cardG = FindObjectOfType<CardGenerator>();
        if (cardG.vivo <= 0 && cardG.generatedCards >= cardG.maxCards && !x)
        {
            gameObject.SetActive(false);
            x = true;
        }
            
    }
}
