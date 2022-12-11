using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class Player : MonoBehaviour
{
   [SerializeField] private int _health;
   [SerializeField] private float _moveSpeed;
   [SerializeField] private float _jumpForce;
   [SerializeField] private float _checkRadius;
   [SerializeField] private Transform _checkGround;
   [SerializeField] private LayerMask _ground;

   private Animator _animator;
   private SpriteRenderer _sprite;
   private Rigidbody2D _rigitBody;
   private Vector3 _vector;
   private bool _isOnGround;
   private int _currentHealth;

   private const string OnGround = "onGround";
   private const string MoveHorisontal = "moveHorisontal";
   private const string Horizontal = "Horizontal";

   public event Action<int, int> HealthChanged;

   private void Start()
   {
      _animator = GetComponent<Animator>();
      _sprite = GetComponent<SpriteRenderer>();
      _rigitBody = GetComponent<Rigidbody2D>();
      _currentCoin = 0;
   }

   private void Update()
   {
      Run();
      Flip();
      CheckGround();
      Jump();
   }

   public void ApplyChangeHealth(int value)
   {
      _currentHealth += value;

      if (_currentHealth <= 0)
         Died?.Invoke();

      if (_currentHealth >= _health)
         _currentHealth = _health;

      HealthChanged?.Invoke(_currentHealth, _health);
   }

   private void Run()
   {
      _vector = new Vector3(Input.GetAxis(Horizontal), 0);
      transform.position += _vector * _moveSpeed * Time.deltaTime;
      _animator.SetFloat(MoveHorisontal, Mathf.Abs(_vector.x));
   }

   private void Jump()
   {
      if (Input.GetKeyDown(KeyCode.Space) && _isOnGround)
      {
         _rigitBody.velocity = new Vector2(_rigitBody.velocity.x, _jumpForce);
      }
   }

   private void CheckGround()
   {
      _isOnGround = Physics2D.OverlapCircle(_checkGround.position, _checkRadius, _ground);
      _animator.SetBool(OnGround, _isOnGround);
   }

   private void Flip() => _sprite.flipX = _vector.x < 0;

}