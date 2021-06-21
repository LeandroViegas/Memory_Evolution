using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barrier3 : MonoBehaviour {

    bool x = false;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MongosseteGenerator mongos = FindObjectOfType<MongosseteGenerator>();
        if (mongos.vivo <= 0 && mongos.generatedMongossetes >= mongos.maxMongossetes && !x)
        {
            gameObject.SetActive(false);
            x = true;
        }

    }
}
