using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public Transform player;
    private float endgameHeight = 120;
    public GameObject endgameCanvas;
    public GameObject highscoreCanvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.position.y > endgameHeight)
        {
            endgameCanvas.SetActive(true);
        }
    }

    public void EndGameButton()
    {
        endgameCanvas.SetActive(false);
        highscoreCanvas.SetActive(true);
    }
}
