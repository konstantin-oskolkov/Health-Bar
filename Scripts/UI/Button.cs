using UnityEngine;

public class Button : MonoBehaviour
{
   [SerializeField] private Player _player;

   public void OnButtonClick(int value)
   {
      _player.ApplyChangeHealth(value);
   }
}
