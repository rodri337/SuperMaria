using UnityEngine;
using System.Collections;

public class CupcakeController : MonoBehaviour {

    public GameObject enemyBullet;//the candyShooter
    public float radius = 2f;//how far it moves
    public float speed = 2f;//how fast it moves back and forth
    private Vector2 position;
    private float min;//for the range it goes back and forth
    private float max;
    public float bulletRate = 5f;

    void Start()
    {
        
        min = transform.position.x;
        max = transform.position.x + radius;
        
        InvokeRepeating("FireEnemyBullet", 1f, bulletRate);//to shoot candy canes
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position = new Vector2(Mathf.PingPong(Time.time * speed, max - min) + min, transform.position.y);//moves cupcake left right


    }
    void FireEnemyBullet()
    {
        GameObject bullet = (GameObject)Instantiate(enemyBullet);//create a bullet
        bullet.transform.position = transform.position;// bullet starts at cupcake position;

    }
}
