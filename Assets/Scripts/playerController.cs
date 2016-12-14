using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class playerController : MonoBehaviour {

    //movement variables
    public float maxSpeed = 4;

    //jumping variables
    bool grounded = false;
    float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float jumpHeight = 60;
    int coinCount;
    public Text countText;
    int numLives;


    //movement variables
    Rigidbody2D myRB;
    Animator myAnim; //change the parameters of the animator
    bool facingRight;

	// Use this for initialization
	void Start () {
        myRB = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        facingRight = true; //initialize character facing right to true

        //set the count of coin to 0;
        coinCount = 0;
        setCountText(); //set the counter text;
        numLives = 5; //start with 5 lives

	}


    void Update()
    {
        if (grounded && Input.GetAxis("Jump")>0)
        {
            grounded = false;
            myAnim.SetBool("isGrounded", grounded);
            myRB.AddForce(new Vector2(0, jumpHeight));
        }


    }
	
	// Update is called once per frame
	void FixedUpdate () {
        //check if we are grounded
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        myAnim.SetBool("isGrounded", grounded);

        myAnim.SetFloat("verticalSpeed", myRB.velocity.y);


        float move = Input.GetAxis("Horizontal");
        myAnim.SetFloat("speed", Mathf.Abs(move));
        myRB.velocity = new Vector2(move * maxSpeed, myRB.velocity.y);

        if(move > 0 && !facingRight) //change the facing direction of the character
        {
            flip();
        }
        else if(move < 0 && facingRight)
        {
            flip();
        }

	}

    //tricker for when it comes to contact with coins or other objects
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            other.gameObject.SetActive(false);
            coinCount++;
            setCountText();

        }
        if (other.gameObject.CompareTag("Enemy"))//if the top of the head of the enemy is hit
        {
            other.gameObject.SetActive(false);//the parent enemy dies
            //Application.LoadLevel(Application.loadedLevel);
        }

    }


    //rotates the player to the accurate position depending on the button pressed
    void flip()
    {
        facingRight = !facingRight; //do the oposite
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }



    //updates the lives counter;

    void setCountText()
    {
        countText.text = "Coins: " + coinCount.ToString();
        if(coinCount == 100)
        {
            numLives = numLives = 1;
        }
    }



}
