using DT.General;

namespace BBTAN.MVC.CoreLib {
  public class LevelModel {
    public Watch<int> Score { get; private set; }
    public Watch<int> HighScore { get; private set; }

    public Watch<int> BallCount { get; private set; }
    public Watch<int> NextBallCount { get; private set; }
    public Watch<int> BallDestroyed { get; private set; }
    public Watch<bool> Shooting { get; private set; }

    public LevelModel() {
      this.Score = new Watch<int>(1);
      this.HighScore = new Watch<int>(1);

      this.BallCount = new Watch<int>(1);
      this.NextBallCount = new Watch<int>(1);
      this.BallDestroyed = new Watch<int>(0);
      this.Shooting = new Watch<bool>(false);
    }
  }
}
