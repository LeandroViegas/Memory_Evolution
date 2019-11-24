using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyPanel : MonoBehaviour
{

    Text vivos;
    Text mortos;

    // Use this for initialization
    void Start()
    {
        vivos = transform.Find("vivos").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        Andar1Controller andar1 = FindObjectOfType<Andar1Controller>();
        vivos.text = "Inimigos restantes  " + andar1.inimigosVivos.ToString();
        /*
        CardGenerator cardG = FindObjectOfType<CardGenerator>();
        vivos.text = "Inimigos restantes  " + (cardG.maxCards - cardG.generatedCards + cardG.vivo).ToString();
        */
    }
}
