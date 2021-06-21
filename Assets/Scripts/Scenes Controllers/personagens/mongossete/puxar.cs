using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puxar : MonoBehaviour
{


    public GameObject person;
    public bool add;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (person)
        {
            if (add)
            {
                if (person.transform.position.x < transform.position.x + 2f)
                    person.transform.position = new Vector3(person.transform.position.x + (10f * Time.deltaTime), person.transform.position.y, person.transform.position.z);
                else
                {
                    person.GetComponent<Datas>().principais.inControl = true;
                    person = null;
                }
            }
            else
            {
                if (person.transform.position.x > transform.position.x - 2f)
                    person.transform.position = new Vector3(person.transform.position.x - (10f * Time.deltaTime), person.transform.position.y, person.transform.position.z);
                else
                {
                    person.GetComponent<Datas>().principais.inControl = true;
                    person = null;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Datas>())
            if (collision.GetComponent<Datas>().team.player)
            {
                person = collision.gameObject;
                person.GetComponent<Datas>().principais.inControl = false;
                if (person.transform.position.x > GetComponentInParent<Transform>().position.x)
                    add = false;
            }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<Datas>())
            if (collision.GetComponent<Datas>().team.player)
            {
                person = collision.gameObject;
                person.GetComponent<Datas>().principais.inControl = false;
                if (person.transform.position.x > GetComponentInParent<Transform>().position.x)
                    add = false;
            }
    }
}
