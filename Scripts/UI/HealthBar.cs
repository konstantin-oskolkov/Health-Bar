using UnityEngine;
using UnityEngine.UI;

public class HealthBar : Bar
{
   [SerializeField] private Player _player;
   [SerializeField] private int _gradientValue;
   [SerializeField] private int _sliderValue;

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
