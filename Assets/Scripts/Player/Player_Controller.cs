using System.Collections;
using UnityEngine;


public class Player_Controller : MonoBehaviour
{

    private Rigidbody2D rb2d;
    private Animator _animator;
    public ScoreController _scoreController;
    public GameOverController gameOverController;


    [SerializeField]
    private float _playerSpeed = 5.5f;

    //Jump
    [SerializeField]
    private float _jumpSpeed;
    public Transform GroundCheck;
    public LayerMask groundLayer;
    private bool doubleJump;




    private void Awake()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        _animator = gameObject.GetComponent<Animator>();
    }

    public void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");

        MoveCharecter(horizontal);
        Crouch();
        HorizontalAnimation(horizontal);
        JumpAnimation();
    }

    private void JumpAnimation()
    {
        if (IsGrounded() && !Input.GetButton("Jump"))
        {
            doubleJump = false;
        }
        if (Input.GetButtonDown("Jump"))
        {
            SoundManager.Instance.Play(Sounds.PlayerJump);
            if (IsGrounded() || doubleJump)
            {
                _animator.SetBool("Jump", true);
                rb2d.velocity = new Vector2(rb2d.velocity.x, _jumpSpeed);
                doubleJump = !doubleJump;
            }
        }
        else if (IsGrounded() == false && Input.GetButtonUp("Jump"))
        {
           _animator.SetBool("Jump", false);
        }
        if (Input.GetButtonUp("Jump") && rb2d.velocity.y > 0f)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, rb2d.velocity.y * 0.5f);
        }
    }
    public bool IsGrounded()
    {
        return Physics2D.OverlapCircle(GroundCheck.position, 0.2f, groundLayer);
    }
    void MoveCharecter(float horizontal)
    {
        Vector3 position = transform.position;
        position.x += horizontal * _playerSpeed * Time.deltaTime;
        transform.position = position;
    }

    public void HorizontalAnimation(float horizontal)
    {
        _animator.SetFloat("speed", Mathf.Abs(horizontal));

        Vector2 scale = transform.localScale;
        if (horizontal < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (horizontal > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;
    }

    public void KillPlayer()
    {
        _animator.SetTrigger("isDead");
        gameOverController.PlayerDied();
        this.enabled = false;
    }
        void Crouch()
        {
            if (Input.GetKey(KeyCode.LeftControl))
            {
                _animator.SetBool("crouch", true);
            }
            else
            {
                _animator.SetBool("crouch", false);
            }
        }
        public void PickUpKeys()
        {
            SoundManager.Instance.Play(Sounds.PlayerPicUp);
            _scoreController.AddScore(10);
        }
   

}

