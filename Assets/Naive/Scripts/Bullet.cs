using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace BBTAN.Naive {
  public class Bullet : MonoBehaviour {
    TMP_Text scoreText;
    TMP_Text highScoreText;

    void Start() {
      this.scoreText = GameObject.Find("ScoreText").GetComponent<TMP_Text>();
      this.highScoreText = GameObject.Find("HighScoreText").GetComponent<TMP_Text>();
    }

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
          GameManager.score++;
          this.scoreText.text = GameManager.score.ToString();
          if (GameManager.score > GameManager.highScore) {
            GameManager.highScore = GameManager.score;
            this.highScoreText.text = "TOP:" + GameManager.highScore.ToString();
          }
        }
      }
    }
  }
}
