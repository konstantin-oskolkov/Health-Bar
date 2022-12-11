using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public abstract class Bar : MonoBehaviour
{
   [SerializeField] protected Image SliderFilling;
   [SerializeField] protected Gradient Gradient;
   [SerializeField] protected Slider Slider;
   [SerializeField] protected float Time;
   [SerializeField] protected float Step;

   private Coroutine _barCoroutine;

   public void OnValueChanged(int value, int maxValue)
   {
      if (_barCoroutine != null)
         StopCoroutine(_barCoroutine);

      _barCoroutine = StartCoroutine(BarChanget((float)value / maxValue));
   }

   private IEnumerator BarChanget(float target)
   {
      while (Slider.value != target)
      {
         Slider.value = Mathf.MoveTowards(Slider.value, target, Step);
         SliderFilling.color = Gradient.Evaluate(SliderFilling.fillAmount);
         yield return new WaitForSeconds(Time);
      }
   }
}
