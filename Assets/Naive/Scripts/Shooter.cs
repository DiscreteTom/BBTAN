using System.Collections;
using System.Collections.Generic;
using DT.General;
using UnityEngine;

namespace BBTAN.Naive {
  public class Shooter : MonoBehaviour {
    [SerializeField] float bulletSpeed;
    [SerializeField] GameObject bullet;
    [SerializeField] float intervalMs = 100;

    LineRenderer line;

    void Start() {
      this.line = this.GetComponent<LineRenderer>();
      this.line.positionCount = 2;
      this.line.SetPosition(0, this.transform.position);
    }

    void Update() {
      // if not shooting, should aim and check shoot
      if (!GameManager.shooting) {
        // draw aim line
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        this.line.SetPosition(1, mousePos);


        // check shoot
        if (Input.GetMouseButtonDown(0)) {
          // update game state
          GameManager.shooting = true;
          GameManager.nextBallCount = GameManager.ballCount;
          GameManager.ballDestroyed = 0;

          // create bullets
          var bulletVelocity = (mousePos - this.transform.position).normalized * this.bulletSpeed;
          for (var i = 0; i < GameManager.ballCount; ++i) {
            this.SetTimeout(this.intervalMs * i, () => {
              Instantiate(this.bullet, this.transform.position, Quaternion.identity).GetComponent<Bullet>().SetVelocity(bulletVelocity);
            });
          }
        }
      } else {
        // shooting, disable line
        this.line.SetPosition(1, this.transform.position);
      }
    }
  }
}