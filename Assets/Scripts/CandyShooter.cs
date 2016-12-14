using UnityEngine;
using System.Collections;

public class CandyShooter : MonoBehaviour {

    public float speed=5f;//speed of the bullet
    private bool isReady;//true when awake
                         
    void Awake()
    {
        isReady = true;
    }
    void Start()
    {
       
    }
    
    // Update is called once per frame
    void Update()
    {
        if (isReady)
        {
           
            transform.position = new Vector2 (transform.position.x, transform.position.y+(Time.deltaTime*speed));// make it move
            
            //if the bullet is out of view of the scene it gets destroyed
            Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
            Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

            if ((transform.position.x < min.x) || (transform.position.x > max.x) ||
               (transform.position.y < min.y) || (transform.position.y > max.y))
            {
                Destroy(gameObject);

            }
        }
    }
}
