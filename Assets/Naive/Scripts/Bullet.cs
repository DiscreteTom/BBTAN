using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace BBTAN.Naive {
  public class Bullet : MonoBehaviour {
    [SerializeField] int blockCount = 5;
    [SerializeField] GameObject block;
    [SerializeField] GameObject diamondBlock;
    [SerializeField] GameObject addBulletProp;
    [SerializeField] float initBlockY = 5;
    [SerializeField] float blockSpacing = 0.5f;

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
          GameObject.Find("Shooter").GetComponent<Shooter>().Show();
          this.UpdateProps();
        }
      }
    }

    void UpdateProps() {
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
          o.transform.position = new Vector3((i - this.blockCount / 2) * this.blockSpacing, this.initBlockY, 0);
          o.transform.parent = props.transform;
        }
      }
    }
  }
}
