using System;
using UnityEngine;

namespace BBTAN.MVC.CoreLib {
  [CreateAssetMenu(menuName = "ScriptableObjects/Config")]
  public class Config : ScriptableObject {
    public BlockPropsData BlockProps;
    public BulletsData Bullets;

    [Serializable]
    public struct BlockPropsData {
      // for view
      public GameObject Block;
      public GameObject DiamondBlock;
      public GameObject RandomProp;
      public GameObject PlusOneProp;
      public float InitY;
      public float Spacing;

      // for logic
      public int Count;
      public int BlankWeight;
      public int BlockWeight;
      public int DiamondBlockWeight;
      public int RandomPropWeight;
    }

    [Serializable]
    public struct BulletsData {
      public float Speed;
      public float IntervalMs;
      public GameObject Prefab;
    }
  }
}