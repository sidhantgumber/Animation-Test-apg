using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minotaur : MonoBehaviour
{

    public Animator animator;
    public float speed = 5f;
    public float jumpSpeed = 2f;
    bool isGrounded;
    Rigidbody rb;
    void Start()
    {
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
        animator.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Vertical")));
        
        if (Input.GetKey(KeyCode.LeftShift))
        {
            animator.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Vertical")) * speed);
        
        }
      
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {


            rb.velocity = new Vector3(0, jumpSpeed*Time.deltaTime, 0);
              // addforce was causing problems, not working
               // Debug.Log(rb.velocity.y);
              //  animator.SetBool("isJumping", false);

            
            
        }
        if(rb.velocity.y>0)
        {
            animator.SetBool("isJumping", true);
        }
        if (rb.velocity.y <= 0)
        { 
            animator.SetBool("isJumping", false);
        }
       // if (Input.GetKeyUp(KeyCode.Space))
        //{
          //  animator.SetBool("isJumping", false);
        //}
      
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        else isGrounded = false;
    }


}
