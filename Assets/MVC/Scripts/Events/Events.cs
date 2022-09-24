using BBTAN.MVC.Controller;
using UnityEngine;
using UnityEngine.Events;

namespace BBTAN.MVC.Model {
  public class Events {
    public UnityEvent<BulletView, Vector2> NewBulletEvent = new UnityEvent<BulletView, Vector2>();
    public UnityEvent<float> SetShooterXEvent = new UnityEvent<float>();
    public UnityEvent ShowShooterEvent = new UnityEvent();
  }
}