using System;
using UnityEngine;

namespace Gameplay
{
    //this script should listen to the event fired by fire
    public class RaycastLazer : Execute
    {
        public Transform firePoint;
        public LineRenderer lineRenderer;
        public Transform itself;

        private void Start()
        {
            itself = transform;
        }
        

        private void OnEnable()
        {
            EventManager.OnRaycast += ShootLazer;
        }
        
        private void OnDisable()
        {
            EventManager.OnRaycast -= ShootLazer;
        }
        
    
        void ShootLazer(Entity entity)
        {
            if (entity == this.entity)
            {
                Shoot();
            }
        }

        private void Shoot()
        {
            RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.up, 1000f);
            Debug.DrawRay(firePoint.position, firePoint.up * 100, Color.red, 0.1f);
            if (hitInfo)
            {
                Transform obje = hitInfo.transform;
                if (obje != null)
                {
                    Vector3 temp = obje.position;
                    Vector3 pos = firePoint.position;
                    if(itself.rotation.eulerAngles.z % 180 == 0)
                    {
                        temp.x = pos.x;
                    }
                    else
                    {
                        temp.y = pos.y;
                    }
                    lineRenderer.SetPosition(0, pos);
                    lineRenderer.SetPosition(1, temp);
                    EnableLazer();
                    Invoke("DisableLazer", 0.06f);
                    Debug.Log("parent " + obje.name);
                    Transform health = hitInfo.transform.GetChild(1);
                    if (health != null)
                    {
                        Health healthScript = health.GetComponent<Health>();
                        healthScript.TakeDamage();
                    }
                }
                
            }
            else
            {
                lineRenderer.SetPosition(0, firePoint.position);
                lineRenderer.SetPosition(1,  firePoint.position + firePoint.up * 20f);
                EnableLazer();
                Invoke("DisableLazer", 0.06f);
            }
        }
        
        void DisableLazer()
        {
            lineRenderer.enabled = false;
        }
        
        void EnableLazer()
        {
            lineRenderer.enabled = true;
        }
    }
}
