using Player;

namespace Score
{
    public class ScoreController
    {
        private readonly ScoreView _scoreView;
        private readonly PlayerController _playerController;

        private int Score;

        public ScoreController(
            PlayerController playerController,
            ScoreView scoreView)
        {
            _playerController = playerController;
            _scoreView = scoreView;
            
            Score = 0;
            _playerController.OnTakeTowel += UpdateScore;
            _playerController.IsDead += ResetScore;
        }

        public void UpdateScore()
        {
            Score++;
            _scoreView.ScoreText.text = Score.ToString();
        }

        public void ResetScore()
        {
            Score = 0;
            _scoreView.ScoreText.text = Score.ToString();
        }
    }
}