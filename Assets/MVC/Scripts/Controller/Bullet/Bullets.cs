using System.Collections.Generic;
using UnityEngine;

namespace BBTAN.MVC.Controller {
  public class Bullets {
    public Bullets(Core core) {
      core.Events.NewBulletEvent.AddListener((view, velocity) => {
        view.Init();
        view.Velocity = velocity;
        view.OnRandomTrigger.AddListener(() => {
          view.Velocity = view.Velocity.magnitude * new Vector2(Random.Range(-1.0f, 1.0f), 1).normalized;
        });
        view.OnTouchBottom.AddListener(() => {
          // update game state
          new DestroyBulletCommand { PositionX = view.transform.position.x }.Exec(core);

          GameObject.Destroy(view.gameObject);
        });
      });
    }
  }
}