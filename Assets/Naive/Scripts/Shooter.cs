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

    [SerializeField] int blockCount = 5;
    [SerializeField] GameObject block;
    [SerializeField] GameObject diamondBlock;
    [SerializeField] GameObject addBulletProp;
    [SerializeField] float initBlockY = 5;
    [SerializeField] float blockSpacing = 0.5f;

    LineRenderer line;

    void Start() {
      this.line = this.GetComponent<LineRenderer>();
      this.line.positionCount = 2;
      this.line.SetPosition(0, this.transform.position);

      // generate level 1
      this.UpdateProps();
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

    public void UpdateProps() {
      var props = GameObject.Find("Props");
      // move all existing props
      for (var i = 0; i < props.transform.childCount; ++i) {
        props.transform.GetChild(i).transform.Translate(Vector2.down * this.blockSpacing);
      }

      // index of add bullet prop
      var abp = Random.Range(0, this.blockCount);

      for (var i = 0; i < this.blockCount; ++i) {
        GameObject o;

        if (i == abp) {
          o = Instantiate(this.addBulletProp, Vector3.zero, Quaternion.identity);
        } else {
          var r = Random.Range(0, 10);
          if (r < 5) {
            o = Instantiate(this.block, Vector3.zero, Quaternion.identity);
            o.GetComponent<Block>().SetHealth(GameManager.score);
          } else if (r < 8) {
            o = Instantiate(this.diamondBlock, Vector3.zero, Quaternion.identity);
            o.GetComponent<Block>().SetHealth(GameManager.score);
          } else
            o = null;
        }
        if (o != null) {
          o.transform.position = new Vector3((i - (this.blockCount - 1) / 2.0f) * this.blockSpacing, this.initBlockY, 0);
          o.transform.parent = props.transform;
        }
      }
    }
  }
}