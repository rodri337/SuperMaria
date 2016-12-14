using UnityEngine;
using System.Collections;

public class MushroomController : MonoBehaviour {

   
    public float radius=2f;
    public float speed=2f;
    private Vector2 position;
    private float min;
    private float max;
    
    void Start ()
    {
        
        min = transform.position.x;
        max = transform.position.x + radius ;
    }
	
	// Update is called once per frame
	void Update ()
    {
        
        transform.position = new Vector2(Mathf.PingPong(Time.time * speed, max - min) + min, transform.position.y);//moves mushroom left right

           
    }





}
