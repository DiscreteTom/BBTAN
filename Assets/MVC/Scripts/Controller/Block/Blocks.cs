using BBTAN.MVC.CoreLib;
using UnityEngine;

namespace BBTAN.MVC.Controller {
  public class Blocks {
    Transform container;

    public Blocks(Core core) {
      this.container = GameObject.Find("Blocks").transform;

      core.Events.TurnEnd.AddListener((e) => {
        // move all blocks down
        for (var i = 0; i < this.container.childCount; i++) {
          this.container.GetChild(i).Translate(Vector2.down * core.Config.BlockProps.Spacing);
        }

        // generate new blocks
        for (var i = 0; i < e.Length; i++) {
          GameObject obj = null;
          if (e[i] == BlockPropType.BLOCK) {
            obj = GameObject.Instantiate(core.Config.BlockProps.Block, new Vector3((i - (core.Config.BlockProps.Count - 1) / 2.0f) * core.Config.BlockProps.Spacing, core.Config.BlockProps.InitY, 0), Quaternion.identity);
          } else if (e[i] == BlockPropType.DIAMOND) {
            obj = GameObject.Instantiate(core.Config.BlockProps.DiamondBlock, new Vector3((i - (core.Config.BlockProps.Count - 1) / 2.0f) * core.Config.BlockProps.Spacing, core.Config.BlockProps.InitY, 0), Quaternion.identity);
          }
          if (obj != null) {
            obj.transform.parent = this.container;
            var view = obj.GetComponent<BlockView>();
            view.Init(core.Model.Score.Value);
          }
        }
      });
    }
  }
}