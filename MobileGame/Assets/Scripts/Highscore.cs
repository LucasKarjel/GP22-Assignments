using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Highscore : MonoBehaviour
{
    public GameObject highScorePrefab;
    public int numberOfScores = 4;


    List<UserInfo> users;
    // Start is called before the first frame update
    void Start()
    {
        users = new List<UserInfo>();

        //for (int i = 0; i < 5; i++)
        //{
        //    users.Add(new UserInfo { name = "test" + i, currentScore = Random.Range(0, 100) }); 
        //}

        SaveManager.Instance.LoadHighScoreData<UserInfo>("users", numberOfScores, LoadedAllUsers);
    }

    private void LoadedAllUsers(List<UserInfo> users)
    {
        users.Reverse();

        foreach (var item in users)
        {
            var newHighScore = Instantiate(highScorePrefab, transform);
            newHighScore.transform.Find("Name").GetComponent<TextMeshProUGUI>().text = item.name;
            newHighScore.transform.Find("Score").GetComponent<TextMeshProUGUI>().text = item.currentScore.ToString();
        }
    }
    private void PopulateHighscore()
    {
        foreach (var item in users)
        {
            var newHighscore = Instantiate(highScorePrefab, transform);
            newHighscore.transform.Find("Name").GetComponent<TextMeshProUGUI>().text = item.name;
            newHighscore.transform.Find("Name").GetComponent<TextMeshProUGUI>().text = item.currentScore.ToString();
        }
    }
}
