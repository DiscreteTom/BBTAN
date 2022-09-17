using TMPro;
using UnityEngine;

namespace BBTAN.MVC.Controller {
  public class ShooterView {
    Transform transform;
    LineRenderer line;
    GameObject canvas;
    GameObject ballShadow;
    TMP_Text ballCountText;

    public ShooterView(GameObject obj) {
      this.transform = obj.transform;
      this.line = obj.GetComponent<LineRenderer>();
      this.canvas = obj.transform.Find("Canvas").gameObject;
      this.ballShadow = obj.transform.Find("BallShadow").gameObject;
      this.ballCountText = this.canvas.transform.Find("BallCountText").GetComponent<TMP_Text>();

      this.line.positionCount = 2;
      this.SetLineSource();
    }

    public void Hide() {
      this.canvas.SetActive(false);
      this.ballShadow.SetActive(false);
    }
    public void Show() {
      this.ballShadow.SetActive(true);
      this.canvas.SetActive(true);
    }

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