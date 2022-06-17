using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{   
    public Transform coins;
    public Animator anim; 
    public GameObject button;

    [SerializeField] public float maxSpeed = 10f; 
    [SerializeField] private bool isFacingRight = true;
    [SerializeField] private float powerJump = 300f;
    [SerializeField] public bool isGrounded;
    [SerializeField] public static int money = 0;
    [SerializeField] public AudioSource moneySoung;
    [SerializeField] public AudioSource dieSoung;

    private Rigidbody2D _rb;

    void Start()
    {
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
        float move = Input.GetAxis("Horizontal");

        _rb.velocity = new Vector2(move * maxSpeed, _rb.velocity.y);

        if (move == 0 )
        {
            WalkOff();
        }
        //если нажали клавишу для перемещения вправо, а персонаж направлен влево
        else if(move > 0 && !isFacingRight)
        {
            //отражаем персонажа вправо
            Flip();
            Walk();
        }
        //обратная ситуация. отражаем персонажа влево
        else if (move < 0 && isFacingRight)
        {
            Flip();
            Walk();
        }
        if (isGrounded && Input.GetKey(KeyCode.Space)){
            isGrounded = false;
            _rb.AddForce(Vector2.up * powerJump);
        }
    }

    //проверяем, стоит ли персонаж на платформе
    private void OnCollisionEnter2D(Collision2D collision)
    {   
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
            isGrounded = true;
            this.transform.parent = collision.transform;
    }
    //проверяем, прыгнул ли персонаж с платформы
    private void OnCollisionExit2D(Collision2D collision)
    {   
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground")){
            isGrounded = false;
            this.transform.parent = null;
    }
    }


    private void Flip()
    {
        //меняем направление движения персонажа
        isFacingRight = !isFacingRight;
        //получаем размеры персонажа
        Vector3 theScale = transform.localScale;
        //зеркально отражаем персонажа по оси Х
        theScale.x *= -1;
        //задаем новый размер персонажа, равный старому, но зеркально отраженный
        transform.localScale = theScale;
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Coins"))
        {
            money++;
            Debug.Log("coins!!!");
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
        button.gameObject.SetActive(true);
        yield return new WaitForSeconds(2);
        Destroy(this.gameObject);
    }
}