using UnityEngine;

namespace BBTAN.MVC.CoreLib {
  [CreateAssetMenu(menuName = "ScriptableObjects/Config")]
  public class Config : ScriptableObject {
    public int BlockPropCount;
    public int BlockWeight;
    public int BlankWeight;
  }
}