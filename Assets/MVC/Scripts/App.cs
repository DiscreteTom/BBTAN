using BBTAN.MVC.Model;
using TMPro;
using UnityEngine;

namespace BBTAN.MVC {
  public class App : MonoBehaviour {
    LevelModel model;
    UIController ui;

    void Start() {
      // init
      this.model = new LevelModel();
      this.ui = new UIController(this.transform.Find("ScoreText").GetComponent<TMP_Text>(), this.transform.Find("HighScoreText").GetComponent<TMP_Text>());

      // inject
      this.ui.Inject(model);
    }

    void Update() {

    }
  }
}
