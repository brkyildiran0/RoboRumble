﻿using System;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Gameplay
{
    public class TileMapController: MonoBehaviour
    {
        public static TileMapController Instance;

        private void Awake()
        {
            Instance = this;
        }

        // private void Update()
        // {
            // if (Input.GetMouseButtonDown(0))
            // {
                // var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                // var cellPos = tilemap.WorldToCell(mousePos);
                // var sprite = tilemap.GetSprite(cellPos);
                // Debug.Log("getting " + cellPos + " sprite " + sprite.name);
            // }
        // }

        public Tilemap tilemap;
        
        public bool IsTileWall(Tile tile)
        {
            var cellPos = tilemap.WorldToCell(tile.transform.position);
            var sprite = tilemap.GetSprite(cellPos);
            Debug.Log("getting " + cellPos + " sprite " + sprite.name);
            return sprite != null && sprite.name == "Wall";
        }
    }
}