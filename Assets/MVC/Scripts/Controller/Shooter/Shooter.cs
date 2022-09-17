using BBTAN.MVC.Model;
using UnityEngine;

namespace BBTAN.MVC.Controller {
  public class Shooter {
    LevelModel model;
    ShooterView view;

    public Shooter(LevelModel model, GameObject root) {
      this.model = model;
      this.view = new ShooterView(root.transform.Find("Shooter").gameObject);
      this.view.SetBallCountText(model.BallCount.Value);
    }

    public void Update() {
      // if not shooting, should aim and check shoot
      if (!this.model.Shooting.Value) {
        // draw aim line
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        this.view.SetLineTarget(mousePos);

        // check shoot
        if (Input.GetMouseButtonDown(0)) {
          // update game state
          GameManager.shooting = true;
          GameManager.nextBallCount = GameManager.ballCount;
          GameManager.ballDestroyed = 0;

          this.Hide();

          // create bullets
          var bulletVelocity = (mousePos - this.transform.position).normalized * this.bulletSpeed;
          for (var i = 0; i < GameManager.ballCount; ++i) {
            this.SetTimeout(this.intervalMs * i, () => {
              Instantiate(this.bullet, this.transform.position, Quaternion.identity).GetComponent<Bullet>().SetVelocity(bulletVelocity);
            });
          }
        }
      }
    }
  }
}