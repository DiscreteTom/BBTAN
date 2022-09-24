using BBTAN.MVC.Controller;
using BBTAN.MVC.Model;
using DT.General;
using UnityEngine;

namespace BBTAN.MVC {
  public class App : MonoBehaviour {
    Core core;

    // controllers
    UI ui;
    Shooter shooter;

    void Start() {
      // init core
      this.core = new Core() {
        Model = new LevelModel(),
        SetTimeout = this.SetTimeout
      };

      // init controllers
      this.ui = new UI(core);
      this.shooter = new Shooter(core);
    }

    void Update() {
      this.shooter.Update();
    }
  }
}
