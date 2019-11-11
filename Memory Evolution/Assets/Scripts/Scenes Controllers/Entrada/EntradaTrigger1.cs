using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EntradaTrigger1 : MonoBehaviour
{

    public GameObject Raio;
    bool aumentar = false;
    float size = 0f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (aumentar && size < 30)
        {
            size += Time.deltaTime * 30f;
            GetComponent<SpriteRenderer>().size = new Vector2(size, size);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (FindObjectOfType<talks>().falas[1].talked > 0)
        {
            Instantiate(Raio, transform);
            Instantiate(Raio, transform);
            aumentar = true;
            FindObjectOfType<EntradaController>().trigger1 = true;
            StartCoroutine(Delay(2));
        }

    }

    IEnumerator Delay(int time)
    {
        FindObjectOfType<PlayerController>().GetComponent<Datas>().principais.inControl = false;
        FindObjectOfType<PlayerController>().GetComponent<Animator>().SetBool("walk", false);
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene("Rua");
    }
}
