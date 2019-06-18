using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
public class Character : MonoBehaviour
{
    [Header("Velocidad de movimiento:")]
    [SerializeField]
    public float speed;

    [Range(0, .3f)] [SerializeField] private float movementSmoothing = .05f; // How much to smooth out the movement
    private bool _facingRight = true; // For determining which way the player is currently facing.

    [Header("Fuerza de salto")]
    [Tooltip("La fuerza debe ser una magnitud grande")]
    public float jumpForce;

    [SerializeField] private Transform groundCheck; // A position marking where to check if the player is grounded.
    private const float KGroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
    private Rigidbody2D _rigidbody;
    [SerializeField] private LayerMask whatIsGround; // A mask determining what is ground to the character
    [SerializeField] private bool airControl = false; // Whether or not a player can steer while jumping;
    private bool _suelo;
    private Animator _anim;
    private bool _movement;
    private Vector3 _velocity = Vector3.zero;
    private float _horizontalMove = 0;
    private bool _jump;
    private bool _special;

    private GameManager _gm;


    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _suelo = false;
        _anim = GetComponent<Animator>();
        _gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void Update()
    {
        _horizontalMove = Input.GetAxisRaw("Horizontal") * speed;
        _anim.SetFloat("Speed", Mathf.Abs(_horizontalMove));
        _anim.SetBool("Grounded", _suelo);
        //_anim.SetBool("isFalling", _rigidbody.velocity.y < -0.1);
        // _anim.SetBool("special",_special);
        //        _anim.SetBool("isDead", _vida == 0);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Quimico"))
        {
            _gm.Quimico++;
            // print("Quimicos: [" + _gm.Quimico + ']');
            Destroy(other.gameObject);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
        // This can be done using layers instead but Sample Assets will not overwrite your project settings.
        var colliders = Physics2D.OverlapCircleAll(groundCheck.position, KGroundedRadius, whatIsGround);
        foreach (var col in colliders)
        {
            if (col.gameObject != gameObject)
            {
                _suelo = true;
            }
        }

        _jump = Input.GetButtonDown("Jump");
        //_special = Input.GetButtonDown("Fire1");
        Move(_horizontalMove * Time.fixedDeltaTime, _jump);
    }

    private void Move(float move, bool jump)
    {
        //only control the player if grounded or airControl is turned on
        if (_suelo || airControl)
        {
            // Move the character by finding the target velocity
            Vector3 targetVelocity = new Vector2(move * 10f, _rigidbody.velocity.y);
            // And then smoothing it out and applying it to the character
            _rigidbody.velocity =
                Vector3.SmoothDamp(_rigidbody.velocity, targetVelocity, ref _velocity, movementSmoothing);


            // If the input is moving the player right and the player is facing left...
            if (move > 0 && !_facingRight)
            {
                // ... flip the player.
                Flip();
            }
            // Otherwise if the input is moving the player left and the player is facing right...
            else if (move < 0 && _facingRight)
            {
                // ... flip the player.
                Flip();
            }
        }

        // If the player should jump...
        if (!_suelo || !jump) return;
        // Add a vertical force to the player.
        _suelo = false;
        _rigidbody.AddForce(new Vector2(0f, jumpForce));
    }

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        _facingRight = !_facingRight;

        // Multiply the player's x local scale by -1.
        var theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}