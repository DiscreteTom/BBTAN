using System.Collections;
using System.Collections.Generic;
using DT.General;
using TMPro;
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

    void Hide() {
      this.transform.Find("Canvas").gameObject.SetActive(false);
      this.transform.Find("Bullet").gameObject.SetActive(false);
      this.line.positionCount = 0;
    }

    public void Show() {
      this.transform.Find("Bullet").gameObject.SetActive(true);
      this.transform.Find("Canvas").gameObject.SetActive(true);
      this.transform.Find("Canvas").Find("BallCountText").GetComponent<TMP_Text>().text = "x" + GameManager.ballCount.ToString();
      this.line.positionCount = 2;
      this.line.SetPosition(0, this.transform.position);
    }
  }
}