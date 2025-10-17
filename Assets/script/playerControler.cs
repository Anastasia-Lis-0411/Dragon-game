using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControler : MonoBehaviour
{
    public float moveSpeed = 5f; //скорость перемещ
    public float jumpForce = 5f;
    private Rigidbody2D rb; // компонент rigidBody2d
    public bool isGrounded; // находится ли персонаж на земле
    private Animator anim;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        Move();
        Jump();


        // проверка стоим ли мы на земле

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            anim.SetBool("jump",false);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
    private void Move()
    {
        float horiz = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horiz * moveSpeed, rb.velocity.y);
        anim.SetBool("walk", horiz != 0);
        //поворачиваем персонаж в сторону движения
        if (horiz > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        if (horiz < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

    }

    private void Jump()
    {
        // прыжок
        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            anim.SetBool("jump", true);
        }
    }
}
