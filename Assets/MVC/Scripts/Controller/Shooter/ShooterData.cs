using UnityEngine;

namespace BBTAN.MVC.Controller {
  [CreateAssetMenu(menuName = "ScriptableObjects/ShooterData")]
  public class ShooterData : ScriptableObject {
    public float BulletSpeed;
    public float IntervalMs;
    public GameObject BallPrefab;
  }
}