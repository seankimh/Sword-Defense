using UnityEngine;

public class SwordController : MonoBehaviour
{
    public enum SwordPosition { Left, Right, Top, Bottom }
    private SwordPosition currentPosition = SwordPosition.Right;
    public Transform player; // Reference to player

    void Update()
    {
        HandleSwordMovement();
    }

    void HandleSwordMovement()
    {
        if (Input.GetKeyDown(KeyCode.W))
            currentPosition = SwordPosition.Top;
        else if (Input.GetKeyDown(KeyCode.S))
            currentPosition = SwordPosition.Bottom;
        else if (Input.GetKeyDown(KeyCode.A))
            currentPosition = SwordPosition.Left;
        else if (Input.GetKeyDown(KeyCode.D))
            currentPosition = SwordPosition.Right;

        MoveSword();
    }

    void MoveSword()
    {
        Vector3 newPosition = player.position;
        float newRotation = 0f; // Default rotation

        switch (currentPosition)
        {
            case SwordPosition.Left:
                newPosition += Vector3.left * 1.5f;
                newRotation = 90f; // Rotate sword 90 degrees
                break;
            case SwordPosition.Right:
                newPosition += Vector3.right * 1.5f;
                newRotation = -90f; // Rotate sword -90 degrees
                break;
            case SwordPosition.Top:
                newPosition += Vector3.up * 1.5f;
                newRotation = 0f; // Normal orientation
                break;
            case SwordPosition.Bottom:
                newPosition += Vector3.down * 1.5f;
                newRotation = 180f; // Flip upside down
                break;
        }

        transform.position = newPosition;
        transform.rotation = Quaternion.Euler(0, 0, newRotation); // Apply rotation
    }
}
