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
    Bullets bullets;

    void Start() {
      // init core
      this.core = new Core() {
        Model = new LevelModel(),
        SetTimeout = this.SetTimeout,
        Events = new Events()
      };

      // init controllers
      this.ui = new UI(core);
      this.shooter = new Shooter(core);
      this.bullets = new Bullets(core);
    }

    void Update() {
      this.shooter.Update();
    }
  }
}
