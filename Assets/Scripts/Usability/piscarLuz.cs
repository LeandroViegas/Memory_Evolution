using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class piscarLuz : MonoBehaviour
{

    Light light1;
    float intensity = 0;
    bool up = false;
    // Use this for initialization
    void Start()
    {
        light1 = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (intensity <= 0f)
            up = true;
        if (intensity >= 25f)
            up = false;
        if (up)
            intensity += Time.deltaTime * 54f;
        if (!up)
            intensity -= Time.deltaTime * 54f;
        light1.intensity = intensity;

    }
}
