using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{   
    public Transform coins;
    public Animator anim; 
    public GameObject buttonRestart;
    public GameObject buttonJump;
    public FixedJoystick fixedJoystick;

    [SerializeField] public float maxSpeed = 10f; 
    [SerializeField] private bool isFacingRight = true;
    [SerializeField] private float powerJump = 300f;
    [SerializeField] public bool isGrounded;
    [SerializeField] public static int money;
    [SerializeField] public AudioSource moneySoung;
    [SerializeField] public AudioSource dieSoung;

    private Rigidbody2D _rb;

    void Start()
    {   money = 0;
        _rb = GetComponent<Rigidbody2D>();
    }


    private void Update(){
        if (transform.position.y<-6f)
        {
            enabled = false;
            StartCoroutine(Die());       
        }
    }

	private void FixedUpdate()
    {   
        float move = fixedJoystick.Horizontal;

        _rb.velocity = new Vector2(move * maxSpeed, _rb.velocity.y);

        if (move == 0 )
        {
            WalkOff();
        }
        else if(move > 0 && !isFacingRight)
        {
            Flip();
            Walk();
        }
        else if (move < 0 && isFacingRight)
        {
            Flip();
            Walk();
        }
    }


    public void Jump(){
        if (isGrounded){
            isGrounded = false;
            _rb.AddForce(Vector2.up * powerJump);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {   
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
            isGrounded = true;
            this.transform.parent = collision.transform;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {   
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground")){
            isGrounded = false;
            this.transform.parent = null;
    }
    }


    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Coins"))
        {
            money++;
            Destroy(other.gameObject);
            moneySoung.Play();
        }
        if(other.CompareTag("Weapon"))
        {   
            enabled = false;
            StartCoroutine(Die());
        }

    }
    
    public void Walk()
	{
		anim.SetBool("Walk", true);
	}
    public void WalkOff()
	{
		anim.SetBool("Walk", false);
    }

    IEnumerator Die()
    {   
        dieSoung.Play();
        buttonRestart.gameObject.SetActive(true);
        yield return new WaitForSeconds(2);
        Destroy(this.gameObject);
    }
}