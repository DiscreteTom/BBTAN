using UnityEngine;
using UnityEngine.Events;

namespace BBTAN.MVC.CoreLib {
  public class Events {
    // from, to
    public UnityEvent<Vector2, Vector2> ShootBullet = new UnityEvent<Vector2, Vector2>();
    // x
    public UnityEvent<float> SetShooterX = new UnityEvent<float>();
    public UnityEvent<BlockPropType[]> TurnEnd = new UnityEvent<BlockPropType[]>();
  }
}