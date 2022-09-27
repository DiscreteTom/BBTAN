using UnityEngine;
using UnityEngine.Events;

namespace BBTAN.MVC.Controller {
  public class BulletView : MonoBehaviour {
    Rigidbody2D body;

    public Vector2 Velocity {
      get => this.body.velocity;
      set => this.body.velocity = value;
    }

    // Events
    public UnityEvent OnRandomTrigger { get; private set; }
    public UnityEvent OnPlusOneTrigger { get; private set; }
    public UnityEvent OnTouchBottom { get; private set; }

    public void Init() {
      this.body = this.GetComponent<Rigidbody2D>();

      this.OnRandomTrigger = new UnityEvent();
      this.OnTouchBottom = new UnityEvent();
      this.OnPlusOneTrigger = new UnityEvent();
    }

    void OnTriggerEnter2D(Collider2D c) {
      if (c.gameObject.tag == "Random") {
        this.OnRandomTrigger.Invoke();
      }
      if (c.gameObject.tag == "PlusOne") {
        Destroy(c.gameObject);
        this.OnPlusOneTrigger.Invoke();
      }
    }

    void OnCollisionEnter2D(Collision2D c) {
      if (c.gameObject.tag == "Bottom") {
        this.OnTouchBottom.Invoke();
      }
    }
  }
}