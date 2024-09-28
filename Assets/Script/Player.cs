using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float JumpPosition = 0f;
    private float JumpTime = 0f;

    private bool isJump = false;
    private bool isDash = false;
    private bool isGround = false;

    private Rigidbody2D rb;
    private Animator anim;

    [SerializeField]
    private GroundCheck groundCheck;
    private PlayerStatus _playerStatus;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        _playerStatus = Resources.Load<PlayerStatus>("PlayerStatus");
    }

    void Update(){
        isGround = groundCheck.CheckGround();
        SetAnimationBool();
    }

    void FixedUpdate(){
        float xSpeed = GetXSpeed();
        float ySpeed = GetYSpeed();

        rb.velocity = new Vector2(xSpeed, ySpeed);
    }

    private float GetXSpeed(){
        float xSpeed = 0.0f;
        float HorizontalKey = Input.GetAxis("Horizontal");

        if(0f < HorizontalKey){
            transform.localScale = new Vector3(1, 1, 1);
            xSpeed = _playerStatus.speed;
            isDash = true;
        }
        else if(HorizontalKey < 0f){
            transform.localScale = new Vector3(-1, 1, 1);
            xSpeed = -_playerStatus.speed;
            isDash = true;
        }
        else
            isDash = false;

        return xSpeed;
    }

    private float GetYSpeed(){
        float ySpeed = -_playerStatus.gravity;
        float VerticalKey = Input.GetAxis("Vertical");

        if(isGround){
            if(0f < VerticalKey){
                isJump = true;
                JumpPosition = transform.position.y;
                JumpTime = 0f;
                ySpeed = _playerStatus.jumpSpeed;
            }
            else
                isJump = false;
        }
        else{
            bool canHeight = transform.position.y < JumpPosition + _playerStatus.jumpLimitHeight;

            if(0f < VerticalKey && canHeight){
                ySpeed = _playerStatus.jumpSpeed;
                JumpTime += Time.deltaTime;
            }
            else if(VerticalKey < 0f){
                isJump = false;
                ySpeed = ySpeed*1.5f;
            }
            else
                isJump = false;
        }

        return ySpeed;
    }

    private void SetAnimationBool(){
        anim.SetBool("isDash", isDash);
        anim.SetBool("isJump", isJump);
        anim.SetBool("isGround", isGround);
    }
}
