using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public KeyCode MoveLeft;
    public KeyCode MoveRight;
    public bool IsMoveDisabled;
    public float Speed;
    void Start()
    {
        IsMoveDisabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsMoveDisabled)
        {
            if (Input.GetKey(MoveLeft))
                GetComponent<Rigidbody>().linearVelocity = new Vector3(-Speed, 0, 0);
            if (Input.GetKey(MoveRight))
                GetComponent<Rigidbody>().linearVelocity = new Vector3(Speed, 0, 0);
        }
    }
}
