using UnityEngine;
using UnityEngine.UI;

namespace Score
{
    public class ScoreView : MonoBehaviour
    {
        public Text ScoreText => _scoreText;
        
        [SerializeField] private Text _scoreText;
    }
}