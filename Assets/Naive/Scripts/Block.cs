using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace BBTAN.Naive {
  public class Block : MonoBehaviour {
    int health = 1;
    TMP_Text text;

    void Start() {
      this.text = this.transform.Find("Canvas/HealthText").GetComponent<TMP_Text>();
    }

    public void SetHealth(int n) {
      this.text = this.transform.Find("Canvas/HealthText").GetComponent<TMP_Text>();
      this.health = n;
      this.text.text = n.ToString();
    }

    void OnCollisionEnter2D(Collision2D c) {
      this.health--;
      this.text.text = this.health.ToString();

      if (this.health == 0) Destroy(this.gameObject);
    }
  }
}
