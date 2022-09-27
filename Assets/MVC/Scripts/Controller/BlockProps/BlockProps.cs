using BBTAN.MVC.CoreLib;
using UnityEngine;

namespace BBTAN.MVC.Controller {
  public class BlockProps {
    Transform container;

    public BlockProps(Core core) {
      this.container = GameObject.Find("BlockProps").transform;

      core.Events.TurnEnd.AddListener((e) => {
        // update existing block/props
        for (var i = 0; i < this.container.childCount; i++) {
          var child = this.container.GetChild(i);
          if (child.tag == "Random") {
            // remove random props
            GameObject.Destroy(child.gameObject);
          } else {
            // move all block/props down
            child.Translate(Vector2.down * core.Config.BlockProps.Spacing);
          }
        }

        // generate new block/props
        for (var i = 0; i < e.Length; i++) {
          GameObject target = null;
          if (e[i] == BlockPropType.BLOCK) {
            target = core.Config.BlockProps.Block;
          } else if (e[i] == BlockPropType.DIAMOND) {
            target = core.Config.BlockProps.DiamondBlock;
          } else if (e[i] == BlockPropType.RANDOM) {
            target = core.Config.BlockProps.RandomProp;
          } else if (e[i] == BlockPropType.PLUS_ONE) {
            target = core.Config.BlockProps.PlusOneProp;
          }

          if (target != null) {
            var obj = GameObject.Instantiate(target, new Vector3((i - (core.Config.BlockProps.Count - 1) / 2.0f) * core.Config.BlockProps.Spacing, core.Config.BlockProps.InitY, 0), Quaternion.identity);
            obj.transform.parent = this.container;
            // if block/diamond, init with health
            obj.GetComponent<BlockView>()?.Init(core.Model.Score.Value);
          }
        }
      });
    }
  }
}