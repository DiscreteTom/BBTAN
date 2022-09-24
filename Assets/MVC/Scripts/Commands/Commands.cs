using UnityEngine;

namespace BBTAN.MVC {
  public interface ICommand {
    void Exec(Core core);
  }

  public struct AddScoreCommand : ICommand {
    public void Exec(Core core) {
      core.Model.Score.Value++;
      core.Model.HighScore.Value = Mathf.Max(core.Model.Score.Value, core.Model.HighScore.Value);
    }
  }

  public struct ShootCommand : ICommand {
    public Vector2 From;
    public Vector2 To;

    public void Exec(Core core) {
      // update states
      core.Model.Shooting.Value = true;
      core.Model.NextBallCount.Value = core.Model.BallCount.Value;
      core.Model.BallDestroyed.Value = 0;

      // generate bullets
      core.Events.ShootBulletEvent.Invoke(this.From, this.To);
    }
  }

  public struct DestroyBulletCommand : ICommand {
    public float PositionX;

    public void Exec(Core core) {
      core.Model.BallDestroyed.Value++;

      // if first ball, change shooter position
      if (core.Model.BallDestroyed.Value == 1) {
        core.Events.SetShooterXEvent.Invoke(this.PositionX);
      }

      // if all ball destroyed, end this turn
      if (core.Model.BallDestroyed.Value == core.Model.BallCount.Value) {
        core.Model.Shooting.Value = false;
        core.Model.BallCount.Value = core.Model.NextBallCount.Value;
        core.Model.Score.Value++;
        if (core.Model.Score.Value > core.Model.HighScore.Value) {
          core.Model.HighScore.Value = core.Model.Score.Value;
        }
        core.Events.ShowShooterEvent.Invoke();
      }
    }
  }
}