using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class TugOfWarBar : MonoBehaviour
{
    public KeyCode LeftButtonMashKey;
    public KeyCode RightButtonMashKey;
    public int MovePerMash;
    public float MinigameMaxTime;
    public bool IsMinigameEnabled;

    private float CurrentTime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CurrentTime = 0;
        IsMinigameEnabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsMinigameEnabled)
        {

            if (Input.GetKeyDown(LeftButtonMashKey))
                RightPlayerScore(MovePerMash);

            if (Input.GetKeyDown(RightButtonMashKey))
                LeftPlayerScore(MovePerMash);

            CurrentTime -= Time.deltaTime;

            if (CurrentTime < 0)
            {
                IsMinigameEnabled = false;
            }
        }
    }

    public void StartMinigame()
    {
        IsMinigameEnabled = true;
        CurrentTime = MinigameMaxTime;
    }

    public void RightPlayerScore(int Score)
    {
        transform.position = new Vector3(transform.position.x - Score, transform.position.y, transform.position.z);
    }

    public void LeftPlayerScore(int Score)
    {
        transform.position = new Vector3(transform.position.x + Score, transform.position.y, transform.position.z);
    }
}
