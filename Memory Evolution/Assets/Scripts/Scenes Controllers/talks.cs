using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class talks : MonoBehaviour
{

    string frase = " ";
    public bool animTop = false;
    public bool falando = false;
    float pos = 0;
    public GameObject txt;
    public GameObject textures;
    float eixoY = 0f;

    // Use this for initialization
    void Start()
    {

    }

    // Up4date is called once per frame
    void Update()
    {
        if (falando && frase != null)
            if (frase.Length >= 0)
            {
                if (Convert.ToInt32(pos) < frase.Length)
                {
                    pos += Time.deltaTime * 40f;
                    txt.GetComponent<UnityEngine.UI.Text>().text = frase.ToString().Substring(0, Convert.ToInt32(pos));
                }
                else
                {
                    falando = false;
                    StartCoroutine(animBottom(2));
                }

                
            }
        if (animTop)
            if (eixoY <= 0)
                eixoY += Time.deltaTime * 5f;
        if (!animTop)
            if (eixoY >= -2.3f)
                eixoY -= Time.deltaTime * 5f;
        if (eixoY >= 0)
            falando = true;
        textures.transform.localPosition = new Vector2(0f, eixoY);
    }

    public void Falar(string fala)
    {
        frase = fala;
        animTop = true;
    }

    IEnumerator animBottom(int time)
    {
        yield return new WaitForSeconds(time);
        pos = 0;
        txt.GetComponent<UnityEngine.UI.Text>().text = "";
        animTop = false;

    }
}
