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

    [System.Serializable]
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
        public string PersonagemName;
        public Sprite personagemPic;
    }

    // Use this for initialization
    void Start()
    {
        personagemImg = transform.Find("personagem").GetComponent<Image>();
        personagemText = transform.Find("PlayerName").GetComponent<Text>();
        falas = new[] {
            new Falas("Depois de duas horas de trabalho foi muito bom tomar esse copo de água.  ", 0, 0), //0
            new Falas("Bom, melhor voltar ao trabalho  ", 0, 0), //1
            new Falas("Huurr, Droga onde estou? depois daquele trovão vim parar aqui, como?  ", 0, 0), //2
            new Falas("E por quê está tudo tão antigo?  ", 0, 0), //3
            new Falas("Olá, eu sou sheila e vou te ajudar nessa aventura  ", 1, 0),  //4
            new Falas("O que? que aventura? quem é você? onde estou?  ", 0, 0),  //5
            new Falas("Calma, calmaaaa vou te explicar tudo.  ", 1, 0),  //6
            new Falas("Você se teletransportou para a década de 40 após do trovão que te atingiu.  ", 1, 0),  //7
            new Falas("Oqueee? mas por que isso aconteceu comigo?  ", 0, 0), //8,
            new Falas("UÈÈÈ!!! como eu vou saber?  ", 1, 0),  //9
            new Falas("ironia do destino sei lá ou coisa parecida.  ", 1, 0),  //10
            new Falas("Não tem como explicar oque aconteceu eu só to aqui pra te ajudar...  ", 1, 0),  //11
            new Falas("Ata beleza muuito obrigado!!!  ", 0, 0),  //12
            new Falas("Por nada" , 1, 0),  //13
            new Falas("Entre naquele prédio laranja e tente encontrar as peças que se perderam do seu computador  ", 1, 0),  //14
            new Falas("para que então você possa sair daqui. A cada andar você encontrará varios inimigos diferentes  ", 1, 0),  //15
            new Falas(" toma aqui está um poder mágico para que você possa se defender desses inimigos.  ", 1, 0),  //16
            new Falas("hahahaha, foda!!!  ", 0, 0),  //17
            new Falas("Agora entre no prédio e lá te darei mais informações sobre seus inimigos habilidades, força e tals só vai la men. ", 1, 0),  //18
            new Falas("Espere só tem uma coisa que não entendi ainda, porque tenho que procurar peças de computador?  ", 0, 0),  //19
            new Falas("Ai minha placa mãe é por isso que eu quero extermina a raça humana. ", 1, 0),  //20
            new Falas("Ta ok, vamos la. ", 1, 0),  //21
            new Falas("Após o trovão ter atingido seu computador ele te teletransportou para cá também. ", 1, 0),  //22
            new Falas("essas peças estão dentro deste prédio e em décadas diferentes.  ", 1, 0),  //23
            new Falas("a cada andar as décadas mudam e seus inimigos também.  ", 1, 0),  //24
            new Falas("eles vão ficando mais poderosos e mais difíceis de eliminar e são exatamente três códigos e sem elas você não sai daqui.  ", 1, 0),  //25
            new Falas("por quê é preciso arrumar seu computador. ", 1, 0),  //26
            new Falas("então chegue até o fim com as três peças pois seu computador estará te esperando lá. ", 1, 0),  //27
            new Falas("entendeu agora verme humano? ", 1, 0),  //28
            new Falas("Entendi ok!!? ", 0, 0),  //29
            new Falas("Na primeira sala estão os cartões perfurados eram o meio de incluir dados e comandos nas máquinas  ", 1, 0),  //30
            new Falas("A habilidade deles são saltos que te causam dano    ", 1, 0),  //31
            new Falas("Então apenas desvie desses saltos e use o poder mágico que te dei para destrui-los.  ", 1, 0),  //32
            new Falas("O que foi isso? Eu morri? ", 0, 0),  //33
            new Falas("kkkk tava assistindo minha novela e até esqueci de te avisar que tem bombas surpresas por ai tome cuidado com isso também.  ", 1, 0),  //34
            new Falas("'_'  OK! ", 0, 0),  //35
            new Falas("Na segunda sala foram inseridos os mongossetes  ", 1, 0),  //36
            new Falas("Eles são baseados nas fitas cassetes, um padrão de fita magnética para gravação de áudio.  ", 1, 0),  //37
            new Falas("A habilidade deles são puxar com suas fitas magnéticas e dar socos com um dano considerável  ", 1, 0),  //38
            new Falas("Mantenha distância deles e você conseguira mata-los.  ", 1, 0),  //39
            new Falas("Na terceira sala são os disquetes. é um tipo de disco de armazenamento magnético fino e flexível.  ", 1, 0),  //40
            new Falas("eles tem como habilidade atirar mines disquetes que te perfuram. tome cuidado!!!  ", 1, 0),  //41
            new Falas("Bom chegou a hora do Bóss, esse é o ramac foi um computador comercial desenvolvido pela IBM em 1960  ", 1, 0),  //42
            new Falas("Foi o primeiro que utilizou uma unidade de disco magnético com uma cabeça de leitura móvel  ", 1, 0),  //43
            new Falas("Ele tem como habilidade tacar bombas que podem te cegar por alguns segundos tome cuidado com isso. Boa sorte!!!  ", 1, 0),  //44
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
                    {
                        texto.text = frase.ToString().Substring(0, Convert.ToInt32(pos));
                        personagemImg.sprite = personagens[personagem].personagemPic;
                        personagemText.text = personagens[personagem].PersonagemName;
                        if(Convert.ToInt32(pos) >= frase.Length - 2)
                        {
                            for (int i = 0; i < tempTalked.Length; i++)
                                if (tempTalked[i] > -1)
                                    falas[tempTalked[i]].talked += 1;
                            for (int i = 0; i < tempTalked.Length; i++)
                                tempTalked[i] = -1;
                        }
                    }
                    /*
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
                                delayToExec = 4f;
                            }
                            thePos++;
                        }
                        if (!found)
                        {
                            falando = false;
                            StartCoroutine(animBottom(2));
                        }
                    }*/
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

    public void Pular()
    {
        int thePos = 0;
        bool found = false;
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
                delayToExec = 0f;
            }
            thePos++;
        }
        if (!found)
        {
            falando = false;
            StartCoroutine(animBottom(2));
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
