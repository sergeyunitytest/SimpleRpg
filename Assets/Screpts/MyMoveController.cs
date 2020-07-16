using UnityEngine;

public static class MyMoveController
{
    private static Vector3 top = new Vector3(0f, 3f, 0f);
    private static Vector3 bottom = new Vector3(0f, -3f, 0f);
    private static Vector3 left = new Vector3(-3f, 0f, 0f);
    private static Vector3 right = new Vector3(3f, 0f, 0f);

    public static void MoveTop(Rigidbody2D rb, SpriteRenderer sr, float speed, Transform transform, float fixedDeltaime)
    {
        top.y = speed;
        rb.MovePosition(transform.position + top * fixedDeltaime);
    }
    public static void MoveBottom(Rigidbody2D rb, SpriteRenderer sr, float speed, Transform transform, float fixedDeltaime)
    {
        bottom.y = speed;
        rb.MovePosition(transform.position + bottom * fixedDeltaime);
    }
    public static void MoveLeft(Rigidbody2D rb, SpriteRenderer sr, float speed, Transform transform, float fixedDeltaime)
    {
        left.x = speed;
        sr.flipX = true;
        rb.MovePosition(transform.position + left * fixedDeltaime);
    }
    public static void MoveRight(Rigidbody2D rb, SpriteRenderer sr, float speed, Transform transform, float fixedDeltaime)
    {
        right.x = speed;
        sr.flipX = false;
        rb.MovePosition(transform.position + right * fixedDeltaime);
    }
}
