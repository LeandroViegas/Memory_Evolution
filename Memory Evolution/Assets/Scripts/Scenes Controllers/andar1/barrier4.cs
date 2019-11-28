using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barrier4 : MonoBehaviour {

    bool x = false;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        DisqueteGenerator disquete = FindObjectOfType<DisqueteGenerator>();
        if (disquete.vivo <= 0 && disquete.generatedDisquetes >= disquete.maxDisquetes && !x)
        {
            gameObject.SetActive(false);
            x = true;
        }

    }
}
