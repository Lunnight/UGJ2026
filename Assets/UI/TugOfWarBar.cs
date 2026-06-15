using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class TugOfWarBar : MonoBehaviour
{
    public KeyCode LeftButtonMashKey;
    public KeyCode RightButtonMashKey;
    public int MovePerMash;

    private Vector3 RightBarPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        RightBarPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(LeftButtonMashKey))
            LeftButtonPressed();

        if (Input.GetKeyDown(RightButtonMashKey))
            RightButtonPressed();
    }

    private void RightButtonPressed()
    {
        transform.position = new Vector3(RightBarPos.x + MovePerMash, RightBarPos.y, RightBarPos.z);
        RightBarPos = transform.position;
    }

    private void LeftButtonPressed()
    {
        transform.position = new Vector3(RightBarPos.x - MovePerMash, RightBarPos.y, RightBarPos.z);
        RightBarPos = transform.position;
    }
}
