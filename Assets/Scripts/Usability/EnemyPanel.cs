using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyPanel : MonoBehaviour
{

    Text vivos;
    Text vidas;

    // Use this for initialization
    void Start()
    {
        vivos = transform.Find("vivos").GetComponent<Text>();
        vidas = transform.Find("vidas").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        Andar1Controller andar1 = FindObjectOfType<Andar1Controller>();
        if (andar1.inimigosVivos == 1)
            vivos.text = andar1.inimigosVivos.ToString() + " Inimigo restante";
        if (andar1.inimigosVivos > 1)
            vivos.text = andar1.inimigosVivos.ToString() + " Inimigos restantes";
        if (andar1.inimigosVivos == 0)
            vivos.text = "Sem inimigos restantes";

        if (andar1.vidas == 1)
            vidas.text = andar1.vidas.ToString() + " vida restante";
        if (andar1.vidas > 1)
            vidas.text = andar1.vidas.ToString() + " vidas restantes";
        if (andar1.vidas == 0)
            vidas.text = "Sem vidas";
        /*
        CardGenerator cardG = FindObjectOfType<CardGenerator>();
        vivos.text = "Inimigos restantes  " + (cardG.maxCards - cardG.generatedCards + cardG.vivo).ToString();
        */
    }
}
