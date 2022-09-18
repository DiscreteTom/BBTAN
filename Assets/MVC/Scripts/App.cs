using BBTAN.MVC.Controller;
using BBTAN.MVC.Model;
using UnityEngine;
using DT.General;

namespace BBTAN.MVC {
  public class App : MonoBehaviour {
    LevelModel model;

    // controllers
    UI ui;
    Shooter shooter;

    void Start() {
      // init model
      this.model = new LevelModel();

      // init controllers
      this.ui = new UI(model);
      this.shooter = new Shooter(model, this.SetTimeout);

    }

    void Update() {
      this.shooter.Update();
    }
  }
}
