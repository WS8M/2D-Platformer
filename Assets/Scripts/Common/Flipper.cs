using UnityEngine;

public static class Flipper
{
    public static void Flip(this SpriteRenderer renderer, bool isMovingRigh)
    {
        renderer.flipX = isMovingRigh == false;
    }
}