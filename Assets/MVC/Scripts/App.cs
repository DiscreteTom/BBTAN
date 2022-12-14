using BBTAN.MVC.Controller;
using BBTAN.MVC.CoreLib;
using DT.General;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace BBTAN.MVC {
  public class App : MonoBehaviour {
    Core core;

    // controllers
    UI ui;
    Shooter shooter;
    Bullets bullets;
    BlockProps blockProps;

    void Start() {
      // init core
      this.core = new Core() {
        Model = new LevelModel(),
        SetTimeout = this.SetTimeout,
        Events = new Events(),
        Config = Addressables.LoadAssetAsync<Config>("Assets/MVC/ScriptableObjects/Config.asset").WaitForCompletion(),
      };

      // init controllers
      this.ui = new UI(core);
      this.shooter = new Shooter(core);
      this.bullets = new Bullets(core);
      this.blockProps = new BlockProps(core);

      // generate blocks, enter level 1
      new TurnEndCommand().Exec(core);
    }

    void Update() {
      this.shooter.Update();
    }
  }
}
