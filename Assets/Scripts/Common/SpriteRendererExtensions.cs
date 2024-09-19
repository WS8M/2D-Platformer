using UnityEngine;

public static class SpriteRendererExtensions
{
    public static void Flip(this SpriteRenderer renderer, bool isMovingRigh)
    {
        renderer.flipX = isMovingRigh == false;
    }
}