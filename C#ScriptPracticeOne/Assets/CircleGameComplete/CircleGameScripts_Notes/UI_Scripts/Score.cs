
using UnityEngine;
using UnityEngine.UI;


public class Score : MonoBehaviour
{

    public Text scoreText;
    public Text highScore;
    private void Start()
    {
        highScore.text = PlayerPrefs.GetInt("HighScore",0).ToString(); 
    }
    void Update()
    {
      scoreText.text = EnemyManager.instance.killTotalScore.ToString();
        if(EnemyManager.instance.killTotalScore > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", EnemyManager.instance.killTotalScore);
            highScore.text = EnemyManager.instance.killTotalScore.ToString();
        }
    
    
    }
    public void ResetHighScore()
    {
        PlayerPrefs.DeleteKey("HighScore");
        // or playerpref.deleteall() ...  
        //highScore.text = 0 (string format..quots not working on keybaord
        // HTIS WOULD DELETE ALL SAVE PLAYERPREFD
    }
}
