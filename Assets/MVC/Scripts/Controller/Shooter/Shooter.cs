using System;
using BBTAN.MVC.Model;
using DT.General;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Events;

namespace BBTAN.MVC.Controller {
  public class Shooter {
    Core core;
    ShooterView view;
    ShooterData data;

    public Shooter(Core core) {
      this.core = core;
      this.view = GameObject.Find("Shooter").GetComponent<ShooterView>();
      this.view.Init();
      this.view.SetBallCountText(core.Model.BallCount.Value);
      this.data = Addressables.LoadAssetAsync<ShooterData>("Assets/MVC/ScriptableObjects/ShooterData.asset").WaitForCompletion();
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
        mousePos.z = 0;
        this.view.SetLineTarget(mousePos);

        // check shoot
        if (Input.GetMouseButtonDown(0)) {
          new ShootCommand().Exec(this.core);

          this.view.Hide();

          // create bullets
          var bulletVelocity = (mousePos - this.view.transform.transform.position).normalized * this.data.BulletSpeed;
          for (var i = 0; i < this.core.Model.BallCount.Value; ++i) {
            this.core.SetTimeout(this.data.IntervalMs * i, () => {
              var bulletView = GameObject.Instantiate(this.data.BallPrefab, this.view.transform.transform.position, Quaternion.identity).GetComponent<BulletView>();
              this.core.Events.NewBulletEvent.Invoke(bulletView, bulletVelocity);
            });
          }
        }
      }
    }
  }
}