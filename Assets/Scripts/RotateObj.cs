using UnityEngine;

public class RotateObj : MonoBehaviour
{
    public Rigidbody2D rb;
    private Vector3 screenPos;
    private float angleOffset;
    public bool check = true;

    private void Update()
    {
        if(check == true)
        {
            if (Input.GetMouseButtonDown(0) && Input.mousePosition.y > Screen.height / 3f)
            {
                screenPos = Camera.main.WorldToScreenPoint(transform.position);
                Vector3 vec3 = Input.mousePosition - screenPos;
                angleOffset = (Mathf.Atan2(transform.right.y, transform.right.x) - Mathf.Atan2(vec3.y, vec3.x)) * Mathf.Rad2Deg;
                rb.gravityScale = 0f;

            }
            if (Input.GetMouseButton(0) && Input.mousePosition.y > Screen.height / 3f)
            {
                Vector3 vec3 = Input.mousePosition - screenPos;
                float angle = Mathf.Atan2(vec3.y, vec3.x) * Mathf.Rad2Deg;
                Mathf.Clamp(angle + angleOffset, 0, 180);
                transform.eulerAngles = new Vector3(0, 0, angle + angleOffset);
            }
            if (Input.GetMouseButtonUp(0) && Input.mousePosition.y > Screen.height / 3f)
            {
                rb.gravityScale = 9.8f;
                check = false;
            }
        }
    }
}
