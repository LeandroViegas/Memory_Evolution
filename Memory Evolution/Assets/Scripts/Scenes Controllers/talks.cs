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

    public GameObject textures;
    public GameObject screen;
    float eixoY = 3f;

    // Use this for initialization
    void Start()
    {
        eixoY = screen.transform.lossyScale.y - textures.transform.lossyScale.y;
        Debug.Log(eixoY);
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
            if (eixoY <= screen.transform.lossyScale.y)
                eixoY += Time.deltaTime * 5f;
        if (!animTop)
            if (eixoY >=  screen.transform.lossyScale.y - textures.transform.lossyScale.y)
                eixoY -= Time.deltaTime * 5f;

        textures.transform.localPosition = new Vector2(textures.transform.lossyScale.x - screen.transform.lossyScale.x, eixoY);
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
