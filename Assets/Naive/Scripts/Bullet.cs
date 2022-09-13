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
      }
    }
  }
}
