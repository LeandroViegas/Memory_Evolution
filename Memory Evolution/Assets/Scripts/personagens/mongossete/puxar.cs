using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puxar : MonoBehaviour
{


    public GameObject person;
    public Animator animator;
    public bool add;
    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
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

        if(animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            gameObject.SetActive(false);
            animator.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Datas>().team.player)
        {
            person = collision.gameObject;
            person.GetComponent<Datas>().principais.inControl = false;
            if (person.transform.position.x > transform.position.x)
                add = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<Datas>().team.player)
        {
            person = collision.gameObject;
            person.GetComponent<Datas>().principais.inControl = false;
            if (person.transform.position.x > transform.position.x)
                add = false;
        }
    }

    public void socar()
    {
        gameObject.SetActive(true);
    }
}
