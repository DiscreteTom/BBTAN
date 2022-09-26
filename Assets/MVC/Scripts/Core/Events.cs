using UnityEngine;
using UnityEngine.Events;

namespace BBTAN.MVC.CoreLib {
  public class Events {
    public UnityEvent<Vector2, Vector2> ShootBullet = new UnityEvent<Vector2, Vector2>();
    public UnityEvent<float> SetShooterX = new UnityEvent<float>();
    public UnityEvent TurnEnd = new UnityEvent();
    public UnityEvent<Vector2, int> NewBlock = new UnityEvent<Vector2, int>();
  }
}