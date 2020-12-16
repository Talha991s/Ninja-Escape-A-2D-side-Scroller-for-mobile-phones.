/*
 Filename: PlayerMove.cs
 Author: Salick Talhah
 Student Number: 101214166
 Date last modified: 29/12/2020
 Description: This file have the player control and player effects, including sfx.
 Revision History:
 07/12/2020 
 10/12/2020
 11/12/2020
 13/12/2020
 15/12/2020
*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public enum ImpulseSounds
{
    JUMP,
    HIT,
    DIE,
    PRESSED

}


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

    public AudioSource[] sounds;
    // Start is called before the first frame update
    void Start()
    {
        m_rigidBody2D = GetComponent<Rigidbody2D>();
        m_spriteRenderer = GetComponent<SpriteRenderer>();
        m_animator = GetComponent<Animator>();

        sounds = GetComponents<AudioSource>();
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
                  //  sounds[(int)ImpulseSounds.STEP].Play();
                }
                else if (joystick.Horizontal < -joystickHorizontalSensitivity)
                {
                    m_rigidBody2D.AddForce(Vector2.left * horizontalForce * Time.deltaTime);
                    m_spriteRenderer.flipX = true;
                    m_animator.SetInteger("AnimState", 1);
                   // sounds[(int)ImpulseSounds.STEP].Play();
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

                sounds[(int)ImpulseSounds.JUMP].Play();
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

        if (other.gameObject.CompareTag("Goal"))
        {
            SceneManager.LoadScene(3);
        }

    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Platforms"))
        {
            isGrounded = false;
        }


        //if (other.gameObject.CompareTag("MovingPlatform"))
        //{
        //    other.gameObject.GetComponent<MovingPlatfomrController>().isActive = false;
        //}
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // respawn
        if (other.gameObject.CompareTag("DeathPlane"))
        {
            LifeManager.health -= 1;
            transform.position = spawnPoint.position;
            sounds[(int)ImpulseSounds.DIE].Play();
        }

        if (other.gameObject.CompareTag("Coin"))
        {
            //transform.position = spawnPoint.position;
            Destroy(other.gameObject);
            sounds[(int)ImpulseSounds.HIT].Play();

        }

        if(other.gameObject.CompareTag("MovingPlatform"))
        {
            isJumping = false;
            isGrounded = true;
            gameObject.transform.parent = other.gameObject.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("MovingPlatform"))
        {
            gameObject.transform.parent = null;
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Alien"))
        {
            LifeManager.health -= 1;
            transform.position = spawnPoint.position;
            sounds[(int)ImpulseSounds.DIE].Play();
        }
    }


}
