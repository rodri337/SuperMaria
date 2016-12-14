using UnityEngine;
using System.Collections;

public class IceCreamBehavior : MonoBehaviour {

  
    private Vector2 position;
    public float amplitude = 0.5f;
    public float distance = 10f;
    public float verticalSpeed = 5f;
    public float horizontalSpeed = 1f;
    private float y;
    private float x;
    

    void Start()
    {
        y = transform.position.y;
        x = transform.position.x;
        

    }

    // Update is called once per frame
    void Update()
    {

        transform.position = new Vector2(x + distance * (Mathf.Sin(Time.time * horizontalSpeed)), y + amplitude * (Mathf.Sin(Time.time * verticalSpeed)));//make it bob and move left right
    }

    
}
