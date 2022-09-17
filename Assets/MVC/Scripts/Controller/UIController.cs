using System.Collections;
using System.Collections.Generic;
using BBTAN.MVC.Model;
using TMPro;
using UnityEngine;

namespace BBTAN.MVC {
  public class UIController {
    public UIController(LevelModel model, TMP_Text scoreText, TMP_Text highScoreText) {
      model.Score.AddListener((v, _) => scoreText.text = v.ToString());
      model.HighScore.AddListener((v, _) => highScoreText.text = "TOP:" + v.ToString());
    }
  }
}
