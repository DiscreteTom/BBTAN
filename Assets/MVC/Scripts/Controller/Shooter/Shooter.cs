using BBTAN.MVC.CoreLib;
using UnityEngine;

namespace BBTAN.MVC.Controller {
  public class Shooter {
    Core core;
    ShooterView view;

    public Shooter(Core core) {
      this.core = core;
      this.view = GameObject.Find("Shooter").GetComponent<ShooterView>();
      this.view.Init();
      this.view.SetBallCountText(core.Model.BallCount.Value);
      this.core.Events.SetShooterXEvent.AddListener((x) => {
        var pos = this.view.transform.position;
        pos.x = x;
        this.view.transform.position = pos;
      });
      this.core.Events.ShowShooterEvent.AddListener(() => {
        this.view.Show();
        this.view.SetLineSource();
        this.view.SetBallCountText(core.Model.BallCount.Value);
      });
    }

    public void Update() {
      // if not shooting, should aim and check shoot
      if (!this.core.Model.Shooting.Value) {
        // draw aim line
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        this.view.SetLineTarget(mousePos);

        // check shoot
        if (Input.GetMouseButtonDown(0)) {
          this.view.Hide();

          new ShootCommand {
            From = this.view.transform.position,
            To = mousePos,
          }.Exec(this.core);
        }
      }
    }
  }
}