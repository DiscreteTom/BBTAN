using BBTAN.MVC.Model;
using DT.General;
using UnityEngine;

namespace BBTAN.MVC {
  public class AddScoreCommand : ICommand {
    LevelModel model;

    public AddScoreCommand(LevelModel model) {
      this.model = model;
    }

    public void Exec() {
      this.model.Score.Value++;
      this.model.HighScore.Value = Mathf.Max(this.model.Score.Value, this.model.HighScore.Value);
    }
  }
}