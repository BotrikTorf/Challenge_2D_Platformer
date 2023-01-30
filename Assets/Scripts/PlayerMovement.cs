using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _runSpeed = 5f;
    [SerializeField] private float _jumpSpeed = 15;
    [SerializeField] private Animator _animator;

    private Rigidbody2D _rigidbody2D;
    private float _horizontalMove;
    private bool _isFacingRight = true;
    private Vector2 _targetVelocity;
    private bool _haveTouchdown;
    private bool _isGrounded = false;
    private float _checkGroundOffsety = 0.25f;
    private float _checkGroundRadius = 0.3f;
    
    private void Start()
    {
        _targetVelocity = transform.position;
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _haveTouchdown = true;
    }

    private void Update()
    {
        _horizontalMove = Input.GetAxisRaw("Horizontal") * _runSpeed;

        if (_horizontalMove < 0 && _isFacingRight)
            Flip();
        else if (_horizontalMove > 0 && _isFacingRight == false)
            Flip();

        _animator.SetFloat("Speed", Mathf.Abs(_horizontalMove));

        if (Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.W))
        {
            if (_isGrounded && _haveTouchdown)
            {
                _animator.SetBool("IsJump", true);
                _rigidbody2D.AddForce(transform.up * _jumpSpeed, ForceMode2D.Impulse);
                _haveTouchdown = false;
            }
        }

        if (_isGrounded == false)
            _animator.SetBool("IsJump", true);
        else
            _animator.SetBool("IsJump", false);
    }

    private void FixedUpdate()
    {
        _targetVelocity = new Vector2(_horizontalMove, _rigidbody2D.velocity.y);
        _rigidbody2D.velocity = _targetVelocity;
        CheckGround();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out TilemapWater water))
            _animator.SetBool("IsWater", true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out TilemapWater water))
            _animator.SetBool("IsWater", false);
    }

    private void Flip()
    {
        _isFacingRight = !_isFacingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    private void CheckGround()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(
            new Vector2(transform.position.x, transform.position.y + _checkGroundOffsety), _checkGroundRadius);

        if (colliders.Length > 1)
        {
            _isGrounded = true;
        }
        else
        {
            _isGrounded = false;
            _haveTouchdown = true;
        }
    }
}
