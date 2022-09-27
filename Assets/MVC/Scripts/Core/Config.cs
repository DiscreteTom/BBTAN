using UnityEngine;

namespace BBTAN.MVC.CoreLib {
  [CreateAssetMenu(menuName = "ScriptableObjects/Config")]
  public class Config : ScriptableObject {
    public int BlockPropCount;
    public int BlankWeight;
    public int BlockWeight;
    public int DiamondBlockWeight;
    public int RandomPropWeight;
  }
}