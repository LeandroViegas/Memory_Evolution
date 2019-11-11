using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class doorScript : MonoBehaviour {

    Animation animation_;
	// Use this for initialization
	void Start () {
        animation_ = GetComponent<Animation>();
        animation_.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(FindObjectOfType<talks>().falas[1].talked > 0)
        {
            animation_.enabled = true;
            ChangeScene();
        }        
    }

    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(0.7f);
        SceneManager.LoadScene("Andar 1");
    }
}
