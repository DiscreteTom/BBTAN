using BBTAN.MVC.Controller;
using BBTAN.MVC.Model;
using TMPro;
using UnityEngine;

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
      this.ui = new UI(model, this.gameObject);
      this.shooter = new Shooter(model, this.gameObject);
    }

    void Update() {
      this.shooter.Update();
    }
  }
}
