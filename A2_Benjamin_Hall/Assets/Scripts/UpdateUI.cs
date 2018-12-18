using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateUI : MonoBehaviour {

    [SerializeField]
    private Text timerLabel;

    [SerializeField]
    private Text ringsLabel;

    [SerializeField]
    private Text healthLabel;

    public GameObject wonGamePanel;



    // Update is called once per frame
    void Update()
    {
        timerLabel.text = FormatTime(GameManager.Instance.TimeRemaining);
        ringsLabel.text = GameManager.Instance.NumRing.ToString();
        healthLabel.text = FormatHealth(GameManager.Instance.GetPlayerHealthPercentage());
    }

    private string FormatTime(float timeInSeconds)
    {
        return string.Format("{0}:{1:00}", Mathf.FloorToInt(timeInSeconds / 60), Mathf.FloorToInt(timeInSeconds % 60));
    }

    private string FormatHealth(float healthPercentage)
    {
        return string.Format("{0}%", Mathf.RoundToInt(healthPercentage * 100));
    }
}
