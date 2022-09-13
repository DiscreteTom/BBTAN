using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BBTAN.Naive {
  public class AddBulletProp : MonoBehaviour {
    void OnTriggerEnter2D(Collider2D c) {
      Destroy(this.gameObject);

      GameManager.nextBallCount++;
    }
  }
}
