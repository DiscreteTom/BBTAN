using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
  public void SetVelocity(Vector2 v) {
    this.GetComponent<Rigidbody2D>().velocity = v;
  }
}
