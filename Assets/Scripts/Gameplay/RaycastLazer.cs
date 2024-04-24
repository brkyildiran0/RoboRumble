using UnityEngine;

namespace Gameplay
{
    public class RaycastLazer : MonoBehaviour
    {

        public Transform firePoint;
        void Update()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                ShootLazer();
            }
        
        }
    
        void ShootLazer()
        {
            RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.up, 0.01f);
            Debug.DrawRay(firePoint.position, firePoint.up * 100, Color.red, 1f);
            // Create a LineRenderer component if it doesn't exist
            LineRenderer lineRenderer = GetComponent<LineRenderer>();
            if (lineRenderer == null)
            {
                lineRenderer = gameObject.AddComponent<LineRenderer>();
            }
            Debug.Log(hitInfo.point);
            // Set the properties of the LineRenderer
            lineRenderer.positionCount = 2;
            lineRenderer.SetPosition(0, firePoint.position);
            lineRenderer.SetPosition(1, hitInfo.point);
            lineRenderer.startColor = Color.black;
            lineRenderer.endColor = Color.black;
            lineRenderer.startWidth = 0.1f;
            lineRenderer.endWidth = 0.1f;

            if (hitInfo)
            {
                Debug.Log("name" + hitInfo.transform.name);
            }
        }
    }
}
