using System.Collections;
using System.Collections.Generic;
using BBTAN.MVC.Model;
using TMPro;
using UnityEngine;

namespace BBTAN.MVC {
  public class UIController {
    TMP_Text scoreText;
    TMP_Text highScoreText;

    public UIController() {
      this.scoreText = GameObject.Find("ScoreText").GetComponent<TMP_Text>();
      this.highScoreText = GameObject.Find("HighScoreText").GetComponent<TMP_Text>();
    }

    public void Inject(LevelModel model) {
      model.Score.AddListener((v, _) => this.scoreText.text = v.ToString());
      model.HighScore.AddListener((v, _) => this.highScoreText.text = "TOP:" + v.ToString());
    }
  }
}
