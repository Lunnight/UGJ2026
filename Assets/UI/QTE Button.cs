using System;
using TMPro;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class QTEButton : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public KeyCode[] PotentialKeys;
    public float MaxTime;
    public float MaxIndividualTime;
    public Vector2 MinScreenCoords;
    public Vector2 MaxScreenCoords;
    public int ScoreAmount;
    public GameObject KeyText;
    public GameObject RadialProgressBar;
    
    // NOTE: Will need to tie to player score later when that's implemented

    private float CurrentTime;
    private bool IsQTEOngoing;
    private KeyCode CurrentKeyCode;
    private float CurrentIndividualTime;
    void Start()
    {
        IsQTEOngoing = false;
        if (PotentialKeys == null)
            Debug.LogError("No keybinds set for QTE buttons");
    }

    // Update is called once per frame
    void Update()
    {
        // Temp Testing
        if (Input.GetKeyDown(KeyCode.CapsLock))
            StartQTEMinigame();

        if (IsQTEOngoing)
        {
            if (CurrentTime > 0)
            {
                CurrentTime -= Time.deltaTime;
                if (CurrentIndividualTime > 0)
                {
                    CurrentIndividualTime -= Time.deltaTime;
                    RadialProgressBar.GetComponent<Image>().fillAmount = CurrentIndividualTime / MaxIndividualTime;
                    if (Input.GetKeyDown(CurrentKeyCode))
                    {
                        Debug.Log("Score earnt: " + ScoreAmount);
                        NewQTE();
                    }
                }
                else
                    NewQTE();
            }
            else
                IsQTEOngoing = false;
        }
        
    }

    private KeyCode GetRandomKeyCode()
    {
        int Index = UnityEngine.Random.Range(0, PotentialKeys.Length);
        return PotentialKeys[Index];
    }

    void StartQTEMinigame()
    {
        CurrentTime = MaxTime;
        IsQTEOngoing = true;
        NewQTE();
    }

    void NewQTE()
    {
        CurrentIndividualTime = MaxIndividualTime;
        CurrentKeyCode = GetRandomKeyCode();
        KeyText.GetComponent<TextMeshProUGUI>().text = CurrentKeyCode.ToString();

        float XPos = UnityEngine.Random.Range(MinScreenCoords.x, MaxScreenCoords.x);
        float YPos = UnityEngine.Random.Range(MinScreenCoords.y, MaxScreenCoords.y);
        transform.position = new Vector3(XPos, YPos, transform.position.z);

        RadialProgressBar.GetComponent<Image>().fillAmount = 1;
    }
}
