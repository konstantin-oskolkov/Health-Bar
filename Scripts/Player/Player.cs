using System;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]

public class Player : MonoBehaviour
{
   [SerializeField] private int _health;

   private SpriteRenderer _sprite;
   private int _currentHealth;

   public event Action<int, int> HealthChanged;

   private void Start()
   {
      _sprite = GetComponent<SpriteRenderer>();
      _currentCoin = 0;
   }

   public void Damage(int damage)
   {
      _currentHealth -= damage;

      if (_currentHealth <= 0)
         Died?.Invoke();

      HealthChanged?.Invoke(_currentHealth, _health);
   }

   public void Heal(int heal)
   {
      _currentHealth += heal;

      if (_currentHealth >= _health)
         _currentHealth = _health;

      HealthChanged?.Invoke(_currentHealth, _health);
   }
}
