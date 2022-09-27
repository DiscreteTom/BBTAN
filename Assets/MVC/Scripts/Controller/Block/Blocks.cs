using System.Collections.Generic;
using BBTAN.MVC.CoreLib;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace BBTAN.MVC.Controller {
  public class Blocks {
    BlocksData data;
    Transform container;

    public Blocks(Core core) {
      this.data = Addressables.LoadAssetAsync<BlocksData>("Assets/MVC/ScriptableObjects/BlocksData.asset").WaitForCompletion();
      this.container = GameObject.Find("Blocks").transform;

      core.Events.TurnEnd.AddListener((e) => {
        // move all blocks down
        for (var i = 0; i < this.container.childCount; i++) {
          this.container.GetChild(i).Translate(Vector2.down * this.data.BlockSpacing);
        }

        // generate new blocks
        for (var i = 0; i < e.Length; i++) {
          if (e[i] == BlockPropType.BLOCK) {
            var obj = GameObject.Instantiate(this.data.BlockPrefab, new Vector3((i - (core.Config.BlockPropCount - 1) / 2.0f) * this.data.BlockSpacing, this.data.InitBlockY, 0), Quaternion.identity);
            obj.transform.parent = this.container;
            var view = obj.GetComponent<BlockView>();
            view.Init(core.Model.Score.Value);
          }
        }
      });
    }
  }
}