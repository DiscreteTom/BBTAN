using BBTAN.MVC.Controller;
using DT.General;
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

  public class ShootCommand : ICommand {
    public float IntervalMs;
    public GameObject BallPrefab;
    public Vector3 Position;
    public Vector2 Velocity;

    public void Exec(Core core) {
      // update states
      core.Model.Shooting.Value = true;
      core.Model.NextBallCount.Value = core.Model.BallCount.Value;
      core.Model.BallDestroyed.Value = 0;

      // generate bullets
      for (var i = 0; i < core.Model.BallCount.Value; ++i) {
        core.SetTimeout(this.IntervalMs * i, () => {
          var bulletView = GameObject.Instantiate(this.BallPrefab, this.Position, Quaternion.identity).GetComponent<BulletView>();
          core.Events.NewBulletEvent.Invoke(bulletView, this.Velocity);
        });
      }
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