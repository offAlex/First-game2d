using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{

    [SerializeField] public float maxSpeed = 10f; 
    [SerializeField] private bool isFacingRight = true;
    [SerializeField] private float powerJump = 300f;
    [SerializeField] public bool isGrounded;
     
    private bool isDie;
    private Rigidbody2D _rb;

    void Start(){
        _rb = GetComponent<Rigidbody2D>();
        isDie = false;
    }


    private void Update(){
        if (transform.position.y>-6f){
            isDie = false;
        }
        else{
            isDie = true;
            Destroy(this.gameObject);
        }
    }

	private void FixedUpdate()
    {   
        float move = Input.GetAxis("Horizontal");

        _rb.velocity = new Vector2(move * maxSpeed, _rb.velocity.y);

        //если нажали клавишу для перемещения вправо, а персонаж направлен влево
        if(move > 0 && !isFacingRight)
            //отражаем персонажа вправо
            Flip();
        //обратная ситуация. отражаем персонажа влево
        else if (move < 0 && isFacingRight)
            Flip();
        
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
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
            isGrounded = false;
            this.transform.parent = null;
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
}