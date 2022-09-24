using TMPro;
using UnityEngine;

namespace BBTAN.MVC.Controller {
  public class ShooterView : MonoBehaviour {
    LineRenderer line;
    GameObject canvas;
    GameObject ballShadow;
    TMP_Text ballCountText;

    public void Init() {
      this.line = this.GetComponent<LineRenderer>();
      this.canvas = this.transform.Find("Canvas").gameObject;
      this.ballShadow = this.transform.Find("BallShadow").gameObject;
      this.ballCountText = this.canvas.transform.Find("BallCountText").GetComponent<TMP_Text>();

      this.line.positionCount = 2;
      this.SetLineSource();
    }

    public void Hide() {
      this.canvas.SetActive(false);
      this.ballShadow.SetActive(false);
      this.line.enabled = false;
    }
    public void Show() {
      this.ballShadow.SetActive(true);
      this.canvas.SetActive(true);
      this.line.enabled = true;
    }

    // Set line source to this game object's position.
    public void SetLineSource() {
      this.line.SetPosition(0, this.transform.position);
    }
    public void SetLineTarget(Vector3 target) {
      this.line.SetPosition(1, target);
    }

    public void SetBallCountText(int ballCount) {
      this.ballCountText.text = "x" + ballCount.ToString();
    }
  }
}