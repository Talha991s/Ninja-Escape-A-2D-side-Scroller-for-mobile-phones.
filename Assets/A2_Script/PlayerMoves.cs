using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoves : MonoBehaviour
{
    public Joystick joystick;
    public float joystickHorizontalSensitivity;
    public float joystickVerticalSensitivity;
    public float horizontalForce;
    public float verticalForce;
    public bool isGrounded;
    public bool isJumping;
    public bool isCrouching;
    public Transform spawnPoint;
    private Rigidbody2D m_rigidBody2D;
    private SpriteRenderer m_spriteRenderer;
    private Animator m_animator;
    // Start is called before the first frame update
    void Start()
    {
        m_rigidBody2D = GetComponent<Rigidbody2D>();
        m_spriteRenderer = GetComponent<SpriteRenderer>();
        m_animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _Move();
    }

    void _Move()
    {
        if(isGrounded)
        {
            if (!isJumping && !isCrouching)
            {
                if (joystick.Horizontal > joystickHorizontalSensitivity)
                {
                    m_rigidBody2D.AddForce(Vector2.right * horizontalForce * Time.deltaTime);
                    m_spriteRenderer.flipX = false;
                    m_animator.SetInteger("AnimState", 1);
                }
                else if (joystick.Horizontal < -joystickHorizontalSensitivity)
                {
                    m_rigidBody2D.AddForce(Vector2.left * horizontalForce * Time.deltaTime);
                    m_spriteRenderer.flipX = true;
                    m_animator.SetInteger("AnimState", 1);
                }
                else 
                {
                    m_animator.SetInteger("AnimState", 0);
                } 
            }

            if ((joystick.Vertical > joystickVerticalSensitivity) && (!isJumping))
            {
                //jump
                m_rigidBody2D.AddForce(Vector2.up * verticalForce);
                m_animator.SetInteger("AnimState", 2);
                isJumping = true;
            }
            else
            {
                isJumping = false;
            }

            if ((joystick.Vertical < -joystickVerticalSensitivity) && (!isCrouching))
            {
                //crouch
                //m_rigidBody2D.AddForce(Vector2.up * verticalForce);
                m_animator.SetInteger("AnimState", 3);
                isCrouching = true;
            }
            else
            {
                isCrouching = false;
            }


        }
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Platforms"))
        {
            isGrounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Platforms"))
        {
            isGrounded = false;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // respawn
        if (other.gameObject.CompareTag("DeathPlane"))
        {
            LifeManager.health -= 1;
            transform.position = spawnPoint.position;
        }

        if (other.gameObject.CompareTag("Coin"))
        {
            //transform.position = spawnPoint.position;
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Alien"))
        {
            LifeManager.health -= 1;
            transform.position = spawnPoint.position;
        }
    }


}
