using UnityEngine;

namespace BBTAN.MVC.Controller {
  [CreateAssetMenu(menuName = "ScriptableObjects/BulletsData")]
  public class BulletsData : ScriptableObject {
    public float BulletSpeed;
    public float IntervalMs;
    public GameObject BulletPrefab;
  }
}