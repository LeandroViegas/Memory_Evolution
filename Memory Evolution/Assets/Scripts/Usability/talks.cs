using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class talks : MonoBehaviour
{

    public Falas[] falas;
    int[] tempTalked;
    public int[] toTalk;
    string frase = "";
    float delayToExec = 0f;
    bool animTop = false;
    public bool falando = false;
    float pos = 0;
    Image personagemImg;
    Text personagemText;
    public Personagens[] personagens;
    float eixoY;
    float eixoX;
    public int personagem;
    RectTransform rectTransform;
    Text texto;

    public class Falas
    {
        public string fala;
        public int personagem;
        public int talked;

        public Falas(string fala, int personagem, int talked)
        {
            this.fala = fala;
            this.personagem = personagem;
            this.talked = talked;
        }
    }

    [System.Serializable]
    public class Personagens
    {
        public Sprite personagemPic;
        public string PersonagemName;

    }

    // Use this for initialization
    void Start()
    {
        personagemImg = transform.Find("personagem").GetComponent<Image>();
        personagemText = transform.Find("PlayerName").GetComponent<Text>();
        falas = new[] {
            new Falas("Depois de duas horas de trabalho foi muito bom tomar esse copo de água.", 0, 0),
            new Falas("Bom, melhor voltar ao trabalho", 0, 0),
        };
        toTalk = new int[100];
        for (int i = 0; i < toTalk.Length; i++)
            toTalk[i] = -1;
        tempTalked = new int[100];
        for (int i = 0; i < tempTalked.Length; i++)
            tempTalked[i] = -1;
        rectTransform = GetComponent<RectTransform>();
        texto = transform.Find("frase").gameObject.GetComponent<Text>();
        eixoX = -1 * rectTransform.rect.width / 2;
        eixoY = -1 * rectTransform.rect.height / 2;
    }

    // Up4date is called once per frame
    void Update()
    {
        if (falando)
        {
            personagemImg.sprite = personagens[personagem].personagemPic;
            personagemText.text = personagens[personagem].PersonagemName;
        }
            
        bool found = false;
        int thePos = 0;
        if (delayToExec > 0)
            delayToExec -= Time.deltaTime;
        if (delayToExec <= 0)
        {
            if (falando && eixoY >= rectTransform.rect.height / 2)
            {
                if (frase.Length >= 0)
                {
                    pos += Time.deltaTime * 40f;
                    if (Convert.ToInt32(pos) < frase.Length)
                        texto.text = frase.ToString().Substring(0, Convert.ToInt32(pos));
                    else
                    {
                        thePos = 0;
                        found = false;
                        while (thePos < toTalk.Length && !found)
                        {
                            if (toTalk[thePos] >= 0)
                            {
                                frase = falas[toTalk[thePos]].fala;
                                personagem = falas[toTalk[thePos]].personagem;
                                int thePos2 = 0;
                                bool found2 = false;
                                while (thePos2 < tempTalked.Length && !found2)
                                {
                                    if (tempTalked[thePos2] < 0)
                                    {
                                        tempTalked[thePos2] = toTalk[thePos];
                                        found2 = true;
                                    }
                                    thePos2++;
                                }
                                toTalk[thePos] = -1;
                                pos = 0;
                                found = true;
                                delayToExec = 3f;
                            }
                            thePos++;
                        }
                        if (!found)
                        {
                            falando = false;
                            StartCoroutine(animBottom(2));
                        }
                    }
                }
            }
            if (!falando)
            {
                thePos = 0;
                found = false;
                while (thePos < toTalk.Length && !found)
                {
                    if (toTalk[thePos] >= 0)
                    {
                        frase = falas[toTalk[thePos]].fala;
                        personagem = falas[toTalk[thePos]].personagem;
                        int thePos2 = 0;
                        bool found2 = false;
                        while (thePos2 < tempTalked.Length && !found2)
                        {
                            if (tempTalked[thePos2] < 0)
                            {
                                tempTalked[thePos2] = toTalk[thePos];
                                found2 = true;
                            }
                            thePos2++;
                        }
                        toTalk[thePos] = -1;
                        pos = 0;
                        animTop = true;
                        falando = true;
                        found = true;
                    }
                    thePos++;
                }
            }
        }


        if (animTop)
        {
            if (eixoY < rectTransform.rect.height / 2)
                eixoY += Time.deltaTime * rectTransform.rect.height * 2 * 2;
            else
                eixoY = rectTransform.rect.height / 2;
        }
        if (!animTop)
        {
            if (eixoY > -1 * rectTransform.rect.height / 2)
                eixoY -= Time.deltaTime * rectTransform.rect.height * 2 * 2;
            else
                eixoY = -1 * rectTransform.rect.height / 2;
        }
        rectTransform.anchoredPosition = new Vector2(eixoX, eixoY);
        if (falando)
            animTop = true;
    }

    public void Falar(int fala)
    {
        int thePos = 0;
        bool found = false;
        while (thePos < toTalk.Length && !found)
        {
            if (toTalk[thePos] < 0)
            {
                toTalk[thePos] = fala;
                found = true;
            }
            thePos++;
        }
    }


    IEnumerator animBottom(int time)
    {

        yield return new WaitForSeconds(time);
        pos = 0;
        texto.text = "";
        animTop = false;
        for (int i = 0; i < tempTalked.Length; i++)
            if (tempTalked[i] > -1)
                falas[tempTalked[i]].talked += 1;
        for (int i = 0; i < tempTalked.Length; i++)
            tempTalked[i] = -1;
    }
}
