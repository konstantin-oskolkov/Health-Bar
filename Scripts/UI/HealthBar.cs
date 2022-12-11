using UnityEngine;
using UnityEngine.UI;

public class HealthBar : Bar
{
   [SerializeField] private Player _player;
   [SerializeField] int _gradientValue;
   [SerializeField] int _sliderValue;

   private void OnEnable()
   {
      _player.HealthChanged += OnValueChanged;
      SliderFilling.color = Gradient.Evaluate(_gradientValue);
      Slider.value = _sliderValue;
   }

   private void OnDisable()
   {
      _player.HealthChanged -= OnValueChanged;
   }
}
