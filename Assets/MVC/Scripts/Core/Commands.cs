using UnityEngine;

namespace BBTAN.MVC.CoreLib {
  public interface ICommand {
    void Exec(Core core);
  }

  public struct ShootCommand : ICommand {
    public Vector2 From;
    public Vector2 To;

    public void Exec(Core core) {
      // update states
      core.Model.Shooting.Value = true;
      core.Model.NextBulletCount.Value = core.Model.BulletCount.Value;
      core.Model.BulletDestroyed.Value = 0;

      // generate bullets
      core.Events.ShootBullet.Invoke(this.From, this.To);
    }
  }

  public struct DestroyBulletCommand : ICommand {
    public float PositionX;

    public void Exec(Core core) {
      core.Model.BulletDestroyed.Value++;

      // if first ball, change shooter position
      if (core.Model.BulletDestroyed.Value == 1) {
        core.Events.SetShooterX.Invoke(this.PositionX);
      }

      // if all ball destroyed, end this turn
      if (core.Model.BulletDestroyed.Value == core.Model.BulletCount.Value) {
        core.Model.Shooting.Value = false;
        core.Model.BulletCount.Value = core.Model.NextBulletCount.Value;
        core.Model.Score.Value++;
        core.Model.HighScore.Value = Mathf.Max(core.Model.HighScore.Value, core.Model.Score.Value);
        core.Events.TurnEnd.Invoke();
      }
    }
  }
}