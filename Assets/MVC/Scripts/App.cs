using BBTAN.MVC.Model;
using UnityEngine;

namespace BBTAN.MVC {
  public class App : MonoBehaviour {
    LevelModel model;
    UIController ui;

    void Start() {
      // init
      this.model = new LevelModel();
      this.ui = new UIController();

      // inject
      this.ui.Inject(model);
    }

    void Update() {

    }
  }
}
