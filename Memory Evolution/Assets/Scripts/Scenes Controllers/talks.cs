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
    float eixoY;
    float height;
    public GameObject biggest;
    public float smallest;
    public GameObject texture;

    // Use this for initialization
    void Start()
    {
        height = biggest.transform.lossyScale.y;
        eixoY = -1 * height;
    }

    // Up4date is called once per frame
    void Update()
    {
        if (falando && eixoY >= 0)
            if (frase.Length >= 0)
            {
                if (Convert.ToInt32(pos) < frase.Length)
                {
                    pos += Time.deltaTime * 40f;
                    gameObject.GetComponent<UnityEngine.UI.Text>().text = frase.ToString().Substring(0, Convert.ToInt32(pos));
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
            if (eixoY >= -1 * height)
                eixoY -= Time.deltaTime * 5f;
        texture.transform.localPosition = new Vector2(0, eixoY);
        Debug.Log(texture.transform.lossyScale.y);
        if (eixoY < 0 && !animTop)
        {
            gameObject.GetComponent<UnityEngine.UI.Text>().text = "";
            falando = false;
        }
    }

    public void Falar(string fala)
    {
        frase = fala;
        animTop = true;
        falando = true;
    }

    IEnumerator animBottom(int time)
    {
        yield return new WaitForSeconds(time);
        pos = 0;
        gameObject.GetComponent<UnityEngine.UI.Text>().text = "";
        animTop = false;
    }
}
