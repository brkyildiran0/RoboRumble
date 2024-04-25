using System;
using UnityEngine;

namespace Gameplay
{
    //this script should listen to the event fired by fire
    public class RaycastLazer : MonoBehaviour
    {
        public Transform firePoint;

        private void Start()
        {
            EventManager.OnRaycast += ShootLazer;
        }

        private void OnEnable()
        {
            EventManager.OnRaycast += ShootLazer;
        }
        
        private void OnDisable()
        {
            EventManager.OnRaycast -= ShootLazer;
        }
        
    
        void ShootLazer()
        {
            RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.up, 0.01f);
            Debug.DrawRay(firePoint.position, firePoint.up * 100, Color.red, 0.1f);
            if (hitInfo)
            {
                Debug.Log("name" + hitInfo.transform.name);
            }
        }
    }
}
