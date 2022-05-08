using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class Lose : MonoBehaviour
{
    [SerializeField] private GameObject GamePanel, losePanel;
    [SerializeField] private Text scoreTextLosePanel,scoreTextGamePanel;
    [SerializeField] private TMP_Text randomScoreText;
    [SerializeField] private AudioSource BackGround,loseBackGround,CoinSource;



    public int _score,_randomScore;
   
    
    
    //назначаем тексту то,что он теперь счёт
    void Start()
    {
        
        _score = 0;
        _randomScore = Random.RandomRange(1, 6);
        scoreTextGamePanel.text = _score.ToString();
        scoreTextLosePanel.text = _score.ToString();
        randomScoreText.text = _randomScore.ToString();
        BackGround.Play();
    }
    

    // проверяем столкновение с тегом препятствие
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "Obstacle")
        {
            GamePanel.SetActive(false);
            losePanel.SetActive(true);
            Time.timeScale = 0;
            //останавливаем музыку фона и включаем музыку проигрыша
            BackGround.Pause();
            loseBackGround.Play();
        }
        if (other.gameObject.tag == "Coin")
        {
            
            _score++;
            scoreTextGamePanel.text = _score.ToString();
            scoreTextLosePanel.text = _score.ToString();
            Destroy(other.gameObject);
            CoinSource.Play();
            
        
        }
        if (other.gameObject.tag == "ObstacleEnd")
        {
            if (_score >= _randomScore)
            {
                _score -=  _randomScore;
            }
            scoreTextGamePanel.text = _score.ToString();
            scoreTextLosePanel.text = _score.ToString();
            randomScoreText.text = _randomScore.ToString();
        }
        
        
    }
}
