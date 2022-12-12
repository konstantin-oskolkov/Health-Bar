using System;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]

public class Player : MonoBehaviour
{
   [SerializeField] private int _maxHealth;

   private SpriteRenderer _sprite;
   private int _currentHealth;

   public event Action<int, int> HealthChanged;

   private void Start()
   {
      _sprite = GetComponent<SpriteRenderer>();
      _currentHealth = _maxHealth;
   }

   public void Damage(int damage)
   {
      _currentHealth -= damage;
      _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth);

      HealthChanged?.Invoke(_currentHealth, _maxHealth);
   }

   public void Heal(int heal)
   {
      _currentHealth += heal;
      _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth);

      HealthChanged?.Invoke(_currentHealth, _maxHealth);
   }
}
