using System.Collections.Generic;
using UnityEngine;

namespace BBTAN.MVC.Controller {
  public class Bullets {
    Core core;

    public Bullets(Core core) {
      this.core = core;
      core.Events.NewBulletEvent.AddListener(this.InitView);
    }

    void InitView(BulletView view, Vector2 velocity) {
      view.Init();
      view.Velocity = velocity;
      view.OnRandomTrigger.AddListener(() => {
        view.Velocity = view.Velocity.magnitude * new Vector2(Random.Range(-1.0f, 1.0f), 1).normalized;
      });
      view.OnTouchBottom.AddListener(() => {
        // update game state
        new DestroyBulletCommand(view.transform.position.x).Exec(this.core);

        GameObject.Destroy(view.gameObject);
      });
    }
  }
}