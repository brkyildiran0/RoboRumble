using System;
using UnityEngine;

namespace Gameplay
{
    //this script should listen to the event fired by fire
    public class RaycastLazerTurret : Execute
    {
        public Transform firePoint;
        public LineRenderer lineRenderer;
        public Transform itself;
        public Tile currentTile;

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
            currentTile = entity.GetCurrentTile();  
            if (entity == this.entity)
            {
                Shoot();
            }
        }

        private void Shoot()
        {
            RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.up, 10f);
            if (hitInfo)
            {
                Transform obje = hitInfo.transform;
                Transform health = null;
                if (obje != null)
                {
                    Vector3 temp = obje.position;
                    Vector3 pos = firePoint.position;
                    lineRenderer.SetPosition(0, pos);
                    lineRenderer.SetPosition(1, temp);
                    EnableLazer();
                    Invoke("DisableLazer", 0.06f);
                    Debug.Log("parent " + obje.name);
                    if(obje.childCount > 1)
                    {
                        health = obje.GetChild(1);
                    }
                    if (health != null)
                    {
                        Health healthScript = health.GetComponent<Health>();
                        if (healthScript != null)
                        {
                            healthScript.TakeDamage();
                        }
                    }
                }
                
            }
            else
            {
                //if the raycast does not hit anything it will calculate nearest wall tile and draw a line to it
                
                
                lineRenderer.SetPosition(0, firePoint.position);
                lineRenderer.SetPosition(1,  firePoint.position + firePoint.up * 100f /** NearestWall(currentTile)*/);
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
        
        /*int NearestWall(Tile tile)
        {
            int count = 0;
            //find the nearest wall tile and draw a line to it
            Boolean until = true;
            while (until)
            {
                tile.SetRowColValue(tile.row + (int)firePoint.up.y, tile.col + (int)firePoint.up.x);
                if (TileMapController.Instance.IsTileWall(tile))
                {
                    until = false;
                }
                count++;
            }
            return count;
        }*/
    }
}
