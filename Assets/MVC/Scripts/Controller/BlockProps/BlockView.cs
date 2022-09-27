using DT.General;
using TMPro;
using UnityEngine;

namespace BBTAN.MVC.Controller {
  public class BlockView : MonoBehaviour {
    public Watch<int> Health { get; private set; }

    TMP_Text text;

    public void Init(int health) {
      this.Health = new Watch<int>(0);
      this.text = this.transform.Find("Canvas/HealthText").GetComponent<TMP_Text>();
      this.Health.AddListener((v, _) => {
        if (v == 0) Destroy(this.gameObject);
        this.text.text = v.ToString();
      });
      this.Health.Value = health;
    }

    void OnCollisionEnter2D(Collision2D c) {
      this.Health.Value--;
    }
  }
}