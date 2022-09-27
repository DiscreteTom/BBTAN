using BBTAN.MVC.CoreLib;
using UnityEngine;

namespace BBTAN.MVC.Controller {
  public class Bullets {

    public Bullets(Core core) {
      core.Events.ShootBullet.AddListener((from, to) => {
        for (var i = 0; i < core.Model.BulletCount.Value; ++i) {
          core.SetTimeout(core.Config.Bullets.IntervalMs * i, () => {
            var view = GameObject.Instantiate(core.Config.Bullets.Prefab, from, Quaternion.identity).GetComponent<BulletView>();
            view.Init();
            view.Velocity = (to - from).normalized * core.Config.Bullets.Speed;
            view.OnRandomTrigger.AddListener(() => {
              view.Velocity = view.Velocity.magnitude * new Vector2(Random.Range(-1.0f, 1.0f), 1).normalized;
            });
            view.OnTouchBottom.AddListener(() => {
              // update game state
              new DestroyBulletCommand { PositionX = view.transform.position.x }.Exec(core);

              GameObject.Destroy(view.gameObject);
            });
            view.OnPlusOneTrigger.AddListener(() => {
              new AddBulletCommand().Exec(core);
            });
          });
        }
      });
    }
  }
}