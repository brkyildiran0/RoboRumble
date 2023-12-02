using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TilePanelUI : MonoBehaviour
{
    public Transform TileManagerTransformHierarchy;
    [SerializeField] private Sprite tileSprite;

    private RectTransform rectTransform;
    private float rectWidth, rectHeight;
    private float rowTileDimension, columnTileDimension;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();

        rectWidth = rectTransform.rect.width;
        rectHeight = rectTransform.rect.height;
    }

    private void OnEnable()
    {
        TileController.OnTilesCreated += CalculateTileAmounts;
        TileController.OnTilesCreated += DrawUITiles;
    }
    private void OnDisable()
    {
        TileController.OnTilesCreated -= CalculateTileAmounts;
        TileController.OnTilesCreated -= DrawUITiles;
    }

    public void CalculateTileAmounts()
    {
        rowTileDimension = rectWidth / TileController.Instance.rowCount;
        columnTileDimension = rectHeight / TileController.Instance.columnCount;
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

                float posX = (rowTileDimension * j) - (rectWidth / 2) + (rowTileDimension / 2);
                float posY = (columnTileDimension * i) - (rectHeight / 2) + (columnTileDimension / 2);
                tileRectTransform.anchoredPosition = new Vector2(posX, posY);
                tileRectTransform.sizeDelta = new Vector2(rowTileDimension, columnTileDimension);

                var tileImage = tileRectTransform.AddComponent<Image>();
                tileImage.sprite = tileSprite;
            }
        }
    }

}
