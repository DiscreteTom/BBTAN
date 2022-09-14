using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace BBTAN.Naive {
  public class Bullet : MonoBehaviour {
    TMP_Text scoreText;
    TMP_Text highScoreText;
    Rigidbody2D body;

    void Start() {
      this.scoreText = GameObject.Find("ScoreText").GetComponent<TMP_Text>();
      this.highScoreText = GameObject.Find("HighScoreText").GetComponent<TMP_Text>();
      this.body = this.GetComponent<Rigidbody2D>();
    }

    public void SetVelocity(Vector2 v) {
      this.body = this.GetComponent<Rigidbody2D>();
      this.body.velocity = v;
    }

    void OnCollisionEnter2D(Collision2D c) {
      if (c.gameObject.tag == "Bottom") {
        Destroy(this.gameObject);

        // update game state
        GameManager.ballDestroyed++;
        if (GameManager.ballDestroyed == 1) {
          // the first ball, change shooter position
          var shooter = GameObject.Find("Shooter");
          var pos = shooter.transform.position;
          pos.x = this.transform.position.x;
          shooter.transform.position = pos;
        }
        if (GameManager.ballDestroyed == GameManager.ballCount) {
          GameManager.shooting = false;
          GameManager.ballCount = GameManager.nextBallCount;
          GameManager.score++;
          this.scoreText.text = GameManager.score.ToString();
          if (GameManager.score > GameManager.highScore) {
            GameManager.highScore = GameManager.score;
            this.highScoreText.text = "TOP:" + GameManager.highScore.ToString();
          }
          var shooter = GameObject.Find("Shooter").GetComponent<Shooter>();
          shooter.Show();
          shooter.UpdateProps();
        }
      }
    }

    void OnTriggerEnter2D(Collider2D c) {
      if (c.gameObject.tag == "Random") {
        this.body.velocity = this.body.velocity.magnitude * new Vector2(Random.Range(-1.0f, 1.0f), 1).normalized;
      }
    }
  }
}
