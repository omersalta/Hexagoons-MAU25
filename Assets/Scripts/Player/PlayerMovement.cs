using Game;
using UnityEngine;

public class PlayerMovement : MonoBehaviour,ILightDarkBehaviour
{
    public int JumpCountOnGrounded = 1;
    public Rigidbody2D rb;
    
    private float _moveSpeed = 5f;
    private float _acceleration = 5f;
    private float _deceleration = 5f;
    private float _jumpForce = 10f;
    private int _currentJumpCount = 1;
   
    private Vector2 _currentVelocity;
    private bool _isGrounded;

    void Update()
    {
        // Kullanıcı girişlerini al
        float moveInput = Input.GetAxisRaw("Horizontal");
        Vector2 targetVelocity = new Vector2(moveInput * _moveSpeed, rb.velocity.y);
        
        // Hızlanma ve yavaşlama hesaplamaları
        _currentVelocity = Vector2.Lerp(rb.velocity, targetVelocity, (Mathf.Abs(moveInput) > 0 ? _acceleration : _deceleration) * Time.deltaTime);
        
        // Rigidbody'ye yeni hızı uygula
        rb.velocity = new Vector2(_currentVelocity.x, rb.velocity.y);
        
        // Zıplama
        if (Input.GetButtonDown("Jump"))
        {
            if (_currentJumpCount > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, _jumpForce);
                _currentJumpCount--;
            }
            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
     {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("groundedddd");
            _currentJumpCount = JumpCountOnGrounded;
        }
        else
        {
            Debug.Log("collision not grounded : " + collision.gameObject.name);
        }
    }
    public void OnLight()
    {
        _moveSpeed = 5f;
        _acceleration = 4f;
        _deceleration = 5f;
        _jumpForce = 14f;
        JumpCountOnGrounded = 2;
    }
    public void OnDark()
    {
        _moveSpeed = 2f;
        _acceleration = 4f;
        _deceleration = 5f;
        _jumpForce = 14f;
        JumpCountOnGrounded = 1;
    }
}