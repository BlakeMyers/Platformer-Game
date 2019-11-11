using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_Controller : MonoBehaviour
{
    public GameObject Player;
    public GameObject Death_Panel;
    public GameObject Menu_Panel;
    public GameObject Destructionpoint;
    private float High_score = Score_Singleton.Instance.High_Score;
    float Current_Score = 0f;
    float max_height = 0f;
    public Text High_Score_Text;
    public Text Current_Score_Text;

    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("escape"))
            Menu_Panel.gameObject.SetActive(true);
        if (Player.transform.position.y > max_height)
            max_height = Player.transform.position.y;
        Current_Score = max_height * 10;
        if (Current_Score > High_score)
        {
            High_score = Current_Score;
            Score_Singleton.Instance.High_Score = Current_Score;
        }
        High_Score_Text.text = "High Score: " + High_score.ToString();
        Current_Score_Text.text = "Current Score: " + Current_Score.ToString();
        if (Player.transform.position.y < Destructionpoint.transform.position.y)
        {
            Death_Panel.gameObject.SetActive(true);
        }
    }

    public void BacktoGame()
    {
        Menu_Panel.gameObject.SetActive(false);
    }
    public void BacktoMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void ResetLevel()
    {
        SceneManager.LoadScene(1);
    }
}
