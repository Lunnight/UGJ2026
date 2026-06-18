using System;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject BarBackground;
    public GameObject BarMask;
    public GameObject QTEMinigameRight;
    public GameObject QTEMinigameLeft;
    public int AdvantageScore;
    public GameObject MashText;
    public float MaxTextTime;
    public int MaxNumMinigames;

    private GameObject RightPlayerBar;
    private int CurrentNumMinigames;
    private string[] MinigameList;
    private bool IsMinigameActive;
    private float TextTimer;
    private string MinigameName;
    private bool StartNewMinigame;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        BarBackground.SetActive(false);
        BarMask.SetActive(false);
        QTEMinigameRight.SetActive(false);
        QTEMinigameLeft.SetActive(false);
        MashText.SetActive(false);
        RightPlayerBar = BarMask.GetComponentInChildren<TugOfWarBar>().gameObject;
        RightPlayerBar.SetActive(false);

        MinigameList = new string[] { "Button Mash", "Quick Time" };
        IsMinigameActive = false;
        StartNewMinigame = false;

        TextTimer = 0;
        CurrentNumMinigames = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentNumMinigames > MaxNumMinigames && StartNewMinigame)
        {
            // End Round
        }

        if (IsMinigameActive)
        {
            if (StartNewMinigame)
            {
                if (TextTimer > 0)
                    TextTimer -= Time.deltaTime;
                else
                {
                    switch (MinigameName)
                    {
                        case "Button Mash":
                            MashText.SetActive(false);
                            RightPlayerBar.GetComponent<TugOfWarBar>().StartMinigame();
                            break;
                        case "Quick Time":
                            break;
                    }
                    StartNewMinigame = false;
                }
            }
            else
            {
                switch (MinigameName)
                {
                    case "Button Mash":
                        if (!RightPlayerBar.GetComponent<TugOfWarBar>().IsMinigameEnabled)
                        {
                            RunMinigame();
                        }
                        break;
                    case "Quick Time":
                        break;
                }
            }
        }
    }

    public void StartMingames(char AdvantagePlayer)
    {
        CurrentNumMinigames = 0;
        BarBackground.SetActive(true);
        BarMask.SetActive(true);
        RightPlayerBar.SetActive(true);
        IsMinigameActive = true;

        switch (AdvantagePlayer)
        {
            case 'L':
                RightPlayerBar.GetComponent<TugOfWarBar>().LeftPlayerScore(AdvantageScore);
                break;
            case 'R':
                RightPlayerBar.GetComponent<TugOfWarBar>().RightPlayerScore(AdvantageScore);
                break;
        }

        RunMinigame();
    }

    private void RunMinigame()
    {
        CurrentNumMinigames++;
        StartNewMinigame = true;

        int Choice = UnityEngine.Random.Range(0, MinigameList.Length - 1);
        MinigameName = MinigameList[Choice];
        
        switch (MinigameName)
        {
            case "Button Mash":
                MashText.SetActive(true);
                break;
            case "Quick Time":
                break;
        }

        TextTimer = MaxTextTime;
    }
}
