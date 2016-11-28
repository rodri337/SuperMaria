using UnityEngine;
using System.Collections;

public class EnemyHeadController : MonoBehaviour {

    public GameObject enemyParent;

    // Use this for initialization
    void Start ()
    {
        this.transform.parent = enemyParent.transform;//Make the enemy its parent
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))//if the top of the head of the enemy is hit
        {
            this.transform.parent.gameObject.SetActive(false);//the parent enemy dies
            
        }

       
   }

    
}

