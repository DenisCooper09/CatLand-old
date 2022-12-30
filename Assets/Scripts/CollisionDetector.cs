using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    protected Collider2D GetDetectedCollider(Vector2 origin, float radius, LayerMask layer)
    {
        return Physics2D.OverlapCircle(origin, radius, layer);
    }
}
