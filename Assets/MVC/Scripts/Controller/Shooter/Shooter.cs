using System;
using BBTAN.MVC.Model;
using DT.General;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Events;

namespace BBTAN.MVC.Controller {
  public class Shooter {
    LevelModel model;
    ShooterView view;
    ShooterData data;
    GameObject obj;
    SetTimeoutFunc setTimeout;

    public Shooter(LevelModel model, SetTimeoutFunc setTimeOut) {
      this.model = model;
      this.setTimeout = setTimeOut;
      this.obj = GameObject.Find("Shooter").gameObject;
      this.view = new ShooterView(this.obj);
      this.view.SetBallCountText(model.BallCount.Value);
      this.data = Addressables.LoadAssetAsync<ShooterData>("Assets/MVC/ScriptableObjects/ShooterData.asset").WaitForCompletion();
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
          this.model.Shooting.Value = true;
          this.model.NextBallCount.Value = this.model.BallCount.Value;
          this.model.BallDestroyed.Value = 0;

          this.view.Hide();

          // create bullets
          var bulletVelocity = (mousePos - this.obj.transform.position).normalized * this.data.BulletSpeed;
          for (var i = 0; i < this.model.BallCount.Value; ++i) {
            this.setTimeout(this.data.IntervalMs * i, () => {
              UnityEngine.Object.Instantiate(this.data.BallPrefab, this.obj.transform.position, Quaternion.identity);
              // .GetComponent<Bullet>().SetVelocity(bulletVelocity);
            });
          }
        }
      }
    }
  }
}