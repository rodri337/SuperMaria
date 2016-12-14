using UnityEngine;
using System.Collections;

public class MagicController : MonoBehaviour
{
    private float speed;//speed of the bullet
    private Vector2 direction;//follows the player
    private bool isReady;//true when bullet has direction of target
	// Use this for initialization
    void Awake()
    {
        speed = 5f;
        isReady = false;
    }
	void Start () {
	
	}
    public void SetDirection(Vector2 dir)
    {
        direction = dir.normalized;
        isReady = true;

    }
	
	// Update is called once per frame
	void Update ()
    {
	    if(isReady)
        {
            Vector2 pos = transform.position;//temp position to save old position of bullet
            pos += direction * speed * Time.deltaTime;// getting the bullet to move toward target a little bit
            transform.position = pos;// make it move

            //if the bullet is out of view of the scene it gets destroyed
            Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
            Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

            if((transform.position.x<min.x) || (transform.position.x>max.x)||
               (transform.position.y < min.y) || (transform.position.y>max.y))
            {
                Destroy(gameObject);

            }
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))//if the top of the head of the enemy is hit
        {
            other.gameObject.SetActive(false);//the parent enemy dies
            Application.LoadLevel(Application.loadedLevel);
        }
  
    }

}
