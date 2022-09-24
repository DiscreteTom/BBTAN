using System.Collections;
using System.Collections.Generic;
using BBTAN.MVC.CoreLib;
using TMPro;
using UnityEngine;

namespace BBTAN.MVC.Controller {
  public class UI {
    public UI(Core core) {
      var scoreText = GameObject.Find("ScoreText").GetComponent<TMP_Text>();
      var highScoreText = GameObject.Find("HighScoreText").GetComponent<TMP_Text>();

      core.Model.Score.AddListener((v, _) => scoreText.text = v.ToString());
      core.Model.HighScore.AddListener((v, _) => highScoreText.text = "TOP:" + v.ToString());
    }
  }
}
