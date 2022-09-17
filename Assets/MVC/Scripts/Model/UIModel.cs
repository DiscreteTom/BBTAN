using System.Collections;
using System.Collections.Generic;
using DT.General;
using UnityEngine;

namespace BBTAN.MVC.Model {
  public class UIModel {
    Watch<int> score;
    Watch<int> highScore;

    public UIModel() {
      this.score = new Watch<int>(0);
      this.highScore = new Watch<int>(0);
    }

    // getters
    public Watch<int> Score => this.score;
    public Watch<int> HighScore => this.highScore;
  }
}
