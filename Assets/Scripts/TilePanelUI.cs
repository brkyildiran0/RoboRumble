using System;
using System.Collections;
using System.Collections.Generic;
using Gameplay;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TilePanelUI : MonoBehaviour
{
    public Transform TileManagerTransformHierarchy;
    [SerializeField] private Sprite tileSprite;

    private RectTransform rectTransform;
    private float rectWidth, rectHeight;
    private float sizeWidth, sizeHeight;

    public static TilePanelUI Instance;
    
    public List<Vector2> coloredTiles;

    public Color softRed; 
    private void Awake()
    {
        Instance = this;
        rectTransform = GetComponent<RectTransform>();

        rectWidth = rectTransform.rect.width;
        rectHeight = rectTransform.rect.height;
    }

    private void OnEnable()
    {
        EventManager.OnTilesCreated += CalculateTileAmounts;
        EventManager.OnTilesCreated += DrawUITiles;
    }
    private void OnDisable()
    {
        EventManager.OnTilesCreated -= CalculateTileAmounts;
        EventManager.OnTilesCreated -= DrawUITiles;
    }

    public void CalculateTileAmounts()
    {
        sizeWidth = rectWidth / TileController.Instance.columnCount;
        sizeHeight = rectHeight / TileController.Instance.rowCount;
    }

    public void DrawUITiles()
    {
        var TileManagerObject = FindObjectOfType<TileController>();

        for (int i = 0; i < TileController.Instance.rowCount; i++)
        {
            for (int j = 0; j < TileController.Instance.columnCount; j++)
            {
                var tile = TileManagerTransformHierarchy.GetChild(i * TileController.Instance.columnCount + j);
                var tileRectTransform = tile.AddComponent<RectTransform>();

                float posX = (sizeWidth * j) - (rectWidth / 2) + (sizeWidth / 2);
                float posY = (sizeHeight * i) - (rectHeight / 2) + (sizeHeight / 2);
                tileRectTransform.anchoredPosition = new Vector2(posX, posY);
                tileRectTransform.sizeDelta = new Vector2(sizeWidth, sizeHeight);

                var tileImage = tileRectTransform.AddComponent<Image>();

                tileImage.sprite = tileSprite;

                /*if (TileMapController.Instance.IsTileWall(TileController.Instance.GetTile(i, j))) ;
                {
                    tileRectTransform.AddComponent<BoxCollider2D>();
                }*/
            }
        }
    }

    public int PathContains(Tile tile)
    {
        Vector2 tilePos = new Vector2(tile.row, tile.col);
        if (coloredTiles.Contains(tilePos))
        {
            if (coloredTiles[coloredTiles.Count - 1] == tilePos)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        return -1;
    }

}
