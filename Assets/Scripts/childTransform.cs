using UnityEngine;

public class childTransform : MonoBehaviour
{
    private Vector3 originalScale;
    private Vector3 parentOriginalScale;
 
    private void Awake()
    {
        originalScale = transform.localScale;
        parentOriginalScale = transform.parent.parent.localScale;
    }

    private void LateUpdate()
    {
        var currentParentScale = transform.parent.parent.localScale;

        var diffX = currentParentScale.x / parentOriginalScale.x;
        var diffY = currentParentScale.y / parentOriginalScale.y;
        var diffZ = currentParentScale.z / parentOriginalScale.z;

        var diffVector = new Vector3(1 / diffX, 1 / diffY, 1 / diffZ);

        transform.localScale = Vector3.Scale(originalScale, diffVector);
    }
}
