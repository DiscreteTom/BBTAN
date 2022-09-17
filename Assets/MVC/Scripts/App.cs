using BBTAN.MVC.Model;
using TMPro;
using UnityEngine;

namespace BBTAN.MVC {
  public class App : MonoBehaviour {
    LevelModel model;

    // controllers
    UIController ui;
    ShooterController shooter;

    void Start() {
      // init model
      this.model = new LevelModel();

      // init controllers
      var scoreText = this.transform.Find("ScoreText").GetComponent<TMP_Text>();
      var highScoreText = this.transform.Find("HighScoreText").GetComponent<TMP_Text>();
      this.ui = new UIController(model, scoreText, highScoreText);
      var shooterView = this.transform.Find("Shooter").GetComponent<Shooter>();
      this.shooter = new ShooterController(shooterView);
    }

    void Update() {

    }
  }
}
