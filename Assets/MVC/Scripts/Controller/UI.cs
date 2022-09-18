using System.Collections;
using System.Collections.Generic;
using BBTAN.MVC.Model;
using TMPro;
using UnityEngine;

namespace BBTAN.MVC.Controller {
  public class UI {
    public UI(LevelModel model) {
      var scoreText = GameObject.Find("ScoreText").GetComponent<TMP_Text>();
      var highScoreText = GameObject.Find("HighScoreText").GetComponent<TMP_Text>();

      model.Score.AddListener((v, _) => scoreText.text = v.ToString());
      model.HighScore.AddListener((v, _) => highScoreText.text = "TOP:" + v.ToString());
    }
  }
}
