using UnityEngine;

namespace BBTAN.MVC.Controller {
  [CreateAssetMenu(menuName = "ScriptableObjects/BlocksData")]
  public class BlocksData : ScriptableObject {
    public GameObject BlockPrefab;
    public GameObject DiamondBlockPrefab;
    public float InitBlockY;
    public float BlockSpacing;
    public GameObject RandomProp;
    public GameObject PlusOneProp;
  }
}