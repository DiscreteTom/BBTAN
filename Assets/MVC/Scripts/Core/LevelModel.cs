using DT.General;

namespace BBTAN.MVC.CoreLib {
  public class LevelModel {
    // score
    public Watch<int> Score { get; private set; }
    public Watch<int> HighScore { get; private set; }

    // shoot & bullet
    public Watch<int> BulletCount { get; private set; }
    public Watch<int> NextBulletCount { get; private set; }
    public Watch<int> BulletDestroyed { get; private set; }
    public Watch<bool> Shooting { get; private set; }

    public LevelModel() {
      this.Score = new Watch<int>(1);
      this.HighScore = new Watch<int>(1);

      this.BulletCount = new Watch<int>(1);
      this.NextBulletCount = new Watch<int>(1);
      this.BulletDestroyed = new Watch<int>(0);
      this.Shooting = new Watch<bool>(false);
    }
  }

  public enum BlockPropType {
    BLANK,
    BLOCK,
  }
}
