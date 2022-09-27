using BBTAN.MVC.CoreLib;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace BBTAN.MVC.Controller {
  public class Props {
    Transform container;

    public Props(Core core) {
      this.container = GameObject.Find("Blocks").transform;

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
            obj = GameObject.Instantiate(core.Config.BlockProps.RandomProp, new Vector3((i - (core.Config.BlockProps.Count - 1) / 2.0f) * core.Config.BlockProps.Spacing, core.Config.BlockProps.InitY, 0), Quaternion.identity);
          } else if (e[i] == BlockPropType.PLUS_ONE) {
            obj = GameObject.Instantiate(core.Config.BlockProps.PlusOneProp, new Vector3((i - (core.Config.BlockProps.Count - 1) / 2.0f) * core.Config.BlockProps.Spacing, core.Config.BlockProps.InitY, 0), Quaternion.identity);
          }
        }
      });
    }
  }
}
