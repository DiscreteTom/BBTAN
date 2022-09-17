using System.Collections;
using System.Collections.Generic;
using BBTAN.MVC.Model;
using TMPro;
using UnityEngine;

namespace BBTAN.MVC.Controller {
  public class UI {
    public UI(LevelModel model, GameObject root) {
      var scoreText = root.transform.Find("ScoreText").GetComponent<TMP_Text>();
      var highScoreText = root.transform.Find("HighScoreText").GetComponent<TMP_Text>();

      model.Score.AddListener((v, _) => scoreText.text = v.ToString());
      model.HighScore.AddListener((v, _) => highScoreText.text = "TOP:" + v.ToString());
    }
  }
}
