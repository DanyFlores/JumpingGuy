using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public static PlayerController sharedInstance;

    public float jumpForce = 6.0f;
    public float runningSpeed = 2.5f;
    private Rigidbody2D rigiBody;
    public LayerMask groundLayerMask;
    public Animator animator; 


    void Awake()
    {
        sharedInstance = this;
        rigiBody = GetComponent<Rigidbody2D>();
        
    }

	// Use this for initialization
	void Start () {
        animator.SetBool("isAlive",true);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Jump();
        }

        animator.SetBool("isGrounded",IsOnTheFloor());
	}

    void FixedUpdate()
    {
        if (GameManager.sharedInstance.currentGameState == GamesState.inTheGame)
        {
            if (rigiBody.velocity.x < runningSpeed)
            rigiBody.velocity = new Vector2(runningSpeed, rigiBody.velocity.y);
        }
        
    }

    void Jump()
    {
        if(GameManager.sharedInstance.currentGameState == GamesState.inTheGame)
        {
            if (IsOnTheFloor())
            {
                rigiBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
        }

    }

    bool IsOnTheFloor()
    {
        if (Physics2D.Raycast (this.transform.position, Vector2.down, 1.0f, groundLayerMask.value))
        {
            return true;
        }
        else
        {
            return false;    
        }
            
    }

    public void KillerPlayer()
    {
        GameManager.sharedInstance.GameOver();
        animator.SetBool("isAlive",false);
    }
}
