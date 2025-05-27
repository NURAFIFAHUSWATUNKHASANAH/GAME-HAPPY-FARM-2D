using UnityEngine;

public class PlayerTouchMovement : MonoBehaviour
{
    public float moveSpeed = 3f;
    private Vector2 moveDirection;

    void Update()
    {
        if (moveDirection != Vector2.zero)
        {
            transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
        }
    }

    // Fungsi dipanggil dari tombol UI
    public void MoveUp() => moveDirection = Vector2.up;
    public void MoveDown() => moveDirection = Vector2.down;
    public void MoveLeft() => moveDirection = Vector2.left;
    public void MoveRight() => moveDirection = Vector2.right;
    public void StopMove() => moveDirection = Vector2.zero;
}
