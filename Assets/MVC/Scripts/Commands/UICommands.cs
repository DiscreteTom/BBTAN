using BBTAN.MVC.Model;
using DT.General;
using UnityEngine;

namespace BBTAN.MVC {
  public class AddScoreCommand : ICommand {
    UIModel uiModel;

    public AddScoreCommand(UIModel uiModel) {
      this.uiModel = uiModel;
    }

    public void Exec() {
      this.uiModel.Score.Value++;
      this.uiModel.HighScore.Value = Mathf.Max(this.uiModel.Score.Value, this.uiModel.HighScore.Value);
    }
  }
}