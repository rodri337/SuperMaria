using UnityEngine;
using System.Collections;

public class WitchController : MonoBehaviour
{
    private Animator anim;//to load animation of witch
    public GameObject enemyBullet;//drag the bullet the witch is going to shoot with
     public float witchVerticalSpeed;//set the speed the witch is moving up and dowm
    public float amplitude;// set how much the witch is goig u and down
    public float bulletRateMin, bulletRateMax;// set range the time rate the bullet is going to get shoot
    private float randnum;//hold the random number within the time rate
    private Vector2 pos;//temp holder of witch position
    private float y;//y position of witch
    public int life;//set the number of times the with gets hit before it dies
    public float distance;//set the distance the player is from the witch when it starts shooting 
    private int alreadyAttacked;//to make sure that the witch doesnt attacked each update
    void Start()
    {
        y = transform.position.y;// get starting position of the witch
        anim = GetComponent<Animator>();//get animations control for witch
        alreadyAttacked = 0;//witch is not yet attacked

    }
   
    void Update()
    {

        anim.SetBool("isAttacking", false);//just to make sure witch stays in idle 
        anim.SetBool("isHit", false);//make witch idle
        transform.position = new Vector2(transform.position.x, y + amplitude*(Mathf.Sin(Time.time * witchVerticalSpeed)));//to move witch up down continously


        GameObject player = GameObject.FindWithTag("Player");//witch looks for its target
        float dist = Vector2.Distance(player.transform.position, transform.position);//get the target distance
        
        if (dist < distance)//check if it is close enough and if it is it starts attacking
        {
            randnum = Random.Range(bulletRateMin, bulletRateMax);//gets random time rate a bullet is shot
            
            if (alreadyAttacked < 1)//to make sure it doesnt shoot bullets every it calls update function
            {
                InvokeRepeating("FireEnemyBullet", randnum, randnum);
            }
            alreadyAttacked = 1;//if it was in range that means it should have already attacked

        }


    }
    

    void FireEnemyBullet()
    {

        GameObject player = GameObject.FindWithTag("Player");//finds target
        float dist = Vector2.Distance(player.transform.position, transform.position);//get target distance
        if (dist < distance)//if the player is too far it doesnt fire
        {
            CancelInvoke();
            alreadyAttacked = 0;

            anim.SetBool("isAttacking", true);

            

            if (player != null)// to check that the player did not de yet
            {

                GameObject bullet = (GameObject)Instantiate(enemyBullet);//create a bullet
                bullet.transform.position = transform.position;// bullet starts at witch location
                Vector2 direction = player.transform.position - bullet.transform.position;//get position target is away from bullet
                bullet.GetComponent<MagicController>().SetDirection(direction);//access the bullets controls and set the direction the bullet is going to go towards

            }
        }
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerBullet"))//is the witch is hit
        {
            anim.SetBool("isHit", true);// play hit animation

            life = life - 1;//decrease witch life

            if(life<=0)//if it has no more life it disable and die
            {
                this.gameObject.SetActive(false);
            }
           
        }

    }


}
