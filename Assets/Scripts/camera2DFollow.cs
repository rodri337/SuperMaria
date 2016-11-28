using UnityEngine;
using System.Collections;

public class camera2DFollow : MonoBehaviour {

    public Transform target; //what the camera is following
    public float smoothing;  //how quickly the camera starts to follow

    Vector3 offset;

    float lowY; //lowest point our camera can go


	// Use this for initialization
	void Start () {
        offset = transform.position - target.position;

        lowY = transform.position.y;

	
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        Vector3 targetCamPost = target.position + offset;

        transform.position = Vector3.Lerp(transform.position, targetCamPost, smoothing * Time.deltaTime);


        if(transform.position.y < lowY)
        {
            transform.position = new Vector3(transform.position.x, lowY, transform.position.z);
        }
	}
}
