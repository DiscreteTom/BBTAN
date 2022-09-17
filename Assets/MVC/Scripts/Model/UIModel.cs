using System.Collections;
using System.Collections.Generic;
using DT.General;
using UnityEngine;

namespace BBTAN.MVC.Model {
  public class UIModel {
    public Watch<int> Score { get; private set; }
    public Watch<int> HighScore { get; private set; }

    public UIModel() {
      this.Score = new Watch<int>(0);
      this.HighScore = new Watch<int>(0);
    }
  }
}
