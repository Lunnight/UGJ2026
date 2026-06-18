using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public KeyCode MoveLeft;
    public KeyCode MoveRight;
    public bool IsMoveDisabled;
    public float Speed;
    public bool IsGrappleEnabled;
    public KeyCode GrappleButton;
    public GameObject OtherPlayer;

    private bool HasWonGrapple;

    void Start()
    {
        IsMoveDisabled = false;
        IsGrappleEnabled = true;
        HasWonGrapple = false;
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

    private void OnCollisionStay(Collision collision)
    {
        if (IsGrappleEnabled && collision.collider.name == OtherPlayer.name && collision.thisCollider.name == name)
        {
            if (Input.GetKeyDown(GrappleButton))
            {
                IsMoveDisabled = true;
                IsGrappleEnabled = false;
                HasWonGrapple = true;

                OtherPlayer.GetComponent<PlayerController>().IsMoveDisabled = true;
                OtherPlayer.GetComponent<PlayerController>().IsGrappleEnabled = false;

                // Trigger minigames
            }
        }
    }
}
