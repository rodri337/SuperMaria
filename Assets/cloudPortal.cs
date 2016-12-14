using UnityEngine;
using System.Collections;

public class cloudPortal : MonoBehaviour {

    public string final =  "Battle";


	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))//if the top of the head of the enemy is hit
        {
            other.gameObject.SetActive(false);//the parent enemy dies
            Application.LoadLevel(final);
        }

    }

}
