using BBTAN.MVC.CoreLib;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace BBTAN.MVC.Controller {
  public class Props {
    BlocksData data;
    Transform container;

    public Props(Core core) {
      this.container = GameObject.Find("Blocks").transform;
      this.data = Addressables.LoadAssetAsync<BlocksData>("Assets/MVC/ScriptableObjects/BlocksData.asset").WaitForCompletion();

      core.Events.TurnEnd.AddListener((e) => {
        // remove random props
        for (var i = 0; i < this.container.childCount; i++) {
          var child = this.container.GetChild(i);
          if (child.tag == "Random") {
            GameObject.Destroy(child.gameObject);
          }
        }

        // generate new props
        for (var i = 0; i < e.Length; i++) {
          GameObject obj = null;
          if (e[i] == BlockPropType.RANDOM) {
            obj = GameObject.Instantiate(this.data.RandomProp, new Vector3((i - (core.Config.BlockPropCount - 1) / 2.0f) * this.data.BlockSpacing, this.data.InitBlockY, 0), Quaternion.identity);
          } else if (e[i] == BlockPropType.PLUS_ONE) {
            obj = GameObject.Instantiate(this.data.PlusOneProp, new Vector3((i - (core.Config.BlockPropCount - 1) / 2.0f) * this.data.BlockSpacing, this.data.InitBlockY, 0), Quaternion.identity);
          }
        }
      });
    }
  }
}
