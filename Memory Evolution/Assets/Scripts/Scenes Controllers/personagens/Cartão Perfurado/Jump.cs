using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{

    public GameObject sombra;
    public bool moveTop = false;
    public float distance = 0f;
    public float atackRemaining = 0f;

    // Use this for initialization
    void Start()
    {
        Transform ParentT = GetComponentInParent<Transform>();
        if (ParentT.Find("sombra"))
            sombra = ParentT.Find("sombra").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        sombra.GetComponent<SpriteRenderer>().sortingOrder = GetComponent<SpriteRenderer>().sortingOrder - 1;
        if (atackRemaining > 0)
            atackRemaining -= Time.deltaTime;
        if (distance > 0.8f)
        {
            moveTop = false;
        }
        if (distance < 0.4f)
        {
            moveTop = true;
        }
        if (moveTop)
            distance = distance + (Time.deltaTime * 2);
        if (!moveTop)
            distance = distance - (Time.deltaTime * 2);
        sombra.transform.localScale = new Vector3(distance * 2, sombra.transform.localScale.y);
        transform.localPosition = new Vector2(0.031f, (distance * 1.9f) - 0.8f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Datas>() != null)
            if (collision.GetComponent<Datas>().team.team1 == true)
                if (atackRemaining <= 0)
                {
                    if (GetComponentInParent<CartaoPerfuradoController>().inAtack)
                        collision.GetComponent<Actions>().Damage(15);
                    else
                        collision.GetComponent<Actions>().Damage(5);
                    atackRemaining = 0.5f;
                }
    }
}