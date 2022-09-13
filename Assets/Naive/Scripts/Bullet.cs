using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BBTAN.Naive {
  public class Bullet : MonoBehaviour {
    public void SetVelocity(Vector2 v) {
      this.GetComponent<Rigidbody2D>().velocity = v;
    }

    void OnCollisionEnter2D(Collision2D c) {
      if (c.gameObject.tag == "Bottom") {
        Destroy(this.gameObject);

        // update game state
        GameManager.ballDestroyed++;
        if (GameManager.ballDestroyed == GameManager.ballCount) {
          GameManager.shooting = false;
          GameManager.ballCount = GameManager.nextBallCount;
        }
      }
    }
  }
}
