using BBTAN.MVC.CoreLib;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace BBTAN.MVC.Controller {
  public class Bullets {
    BulletsData data;

    public Bullets(Core core) {
      this.data = Addressables.LoadAssetAsync<BulletsData>("Assets/MVC/ScriptableObjects/BulletsData.asset").WaitForCompletion();

      core.Events.ShootBullet.AddListener((from, to) => {
        for (var i = 0; i < core.Model.BulletCount.Value; ++i) {
          core.SetTimeout(this.data.IntervalMs * i, () => {
            var view = GameObject.Instantiate(this.data.BulletPrefab, from, Quaternion.identity).GetComponent<BulletView>();
            view.Init();
            view.Velocity = (to - from).normalized * this.data.BulletSpeed;
            view.OnRandomTrigger.AddListener(() => {
              view.Velocity = view.Velocity.magnitude * new Vector2(Random.Range(-1.0f, 1.0f), 1).normalized;
            });
            view.OnTouchBottom.AddListener(() => {
              // update game state
              new DestroyBulletCommand { PositionX = view.transform.position.x }.Exec(core);

              GameObject.Destroy(view.gameObject);
            });
            view.OnPlusOneTrigger.AddListener(() => {
              new AddBulletCommand().Exec(core);
            });
          });
        }
      });
    }
  }
}