using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Player_moviment : MonoBehaviour
{
    [SerializeField]float speed = 15f;
    [SerializeField]float jumpForce = 15f;

    Rigidbody2D playerRigidbody;
    Vector2 movementInput;
    Animator PlayerAnimator;
    CapsuleCollider2D PlayerCapsuleCollider;
    BoxCollider2D feetBoxCollider;
    bool isJumping = false;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        PlayerAnimator = GetComponent<Animator>();
        PlayerCapsuleCollider = GetComponent<CapsuleCollider2D>();       
        feetBoxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

     Run();   
     SpriteFlip();
     Jump();
     PlayerCapsuleCollider = GetComponent<CapsuleCollider2D>();       
     feetBoxCollider = GetComponent<BoxCollider2D>();

    }
    //metodo para assionar a movimentacao do personagem
    void OnMove(InputValue value){
        movementInput = value.Get<Vector2>();
    }
    //metodo para o personagem correr 
    void Run(){
       Vector2 playerSpeed = new Vector2(movementInput.x * speed, playerRigidbody.velocity.y);
       playerRigidbody.velocity = playerSpeed;
       
       bool playerHasXSpeed = Mathf.Abs(playerRigidbody.velocity.x) > Mathf.Epsilon;
       PlayerAnimator.SetBool("isRunning", playerHasXSpeed);
    }

    //metodo para fazer personagem pular
    void OnJump(InputValue value){
        if(!IsOnGround()){
            return;
          }

        if(value.isPressed){
            playerRigidbody.velocity += new Vector2(0f, jumpForce);
            isJumping = true;
          }

    }
    //metodo  para retorna a condicao para verificar se esta tocando o "chao"
    private bool IsOnGround(){
           return feetBoxCollider.IsTouchingLayers(LayerMask.GetMask("Ground"));

    }
    //metodo para personagem trocar animacao de pulo quando nao estiver pulando
    void Jump(){
        if(isJumping && !IsOnGround()){
            PlayerAnimator.SetBool("isJumping", true);
        }
        else if(isJumping && IsOnGround()){
             PlayerAnimator.SetBool("isJumping", false);
        }

    }

    //metodo para mudar diracao sprite quando apertado a tecla
    void SpriteFlip(){
        float scaleX = (Mathf.Sign(playerRigidbody.velocity.x))*20f;
        float scaleY = 20f;
        bool playerHasXSpeed = Mathf.Abs(playerRigidbody.velocity.x) > Mathf.Epsilon;

        if(playerHasXSpeed){
            transform.localScale = new Vector2(scaleX, scaleY);
        }

    }
}
