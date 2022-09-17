using DT.General;

namespace BBTAN.MVC.Model {
  public class LevelModel {
    public Watch<int> Score { get; private set; }
    public Watch<int> HighScore { get; private set; }

    public int BallCount;
    public int NextBallCount;
    public int BallDestroyed;
    public bool Shooting;

    public LevelModel() {
      this.Score = new Watch<int>(1);
      this.HighScore = new Watch<int>(1);

      this.BallCount = 0;
      this.NextBallCount = 1;
      this.BallDestroyed = 0;
      this.Shooting = false;
    }
  }
}
