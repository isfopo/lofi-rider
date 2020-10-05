using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class InheritColor : MonoBehaviour
{
    public enum ThemeSelection
    {
        foreground1,
        foreground2,
        background1,
        background2
    }

    public SpriteRenderer spriteRenderer;
    public LevelDesigner levelDesigner;
    public ThemeSelection themeSelection;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        levelDesigner = FindObjectOfType<LevelDesigner>();
        SelectTheme(themeSelection);
    }

    void SelectTheme(ThemeSelection themeSelection)
    {
        switch (themeSelection)
        {
            case ThemeSelection.foreground1:
                spriteRenderer.color = levelDesigner.foregroundColor1;
                break;
            case ThemeSelection.foreground2:
                spriteRenderer.color = levelDesigner.foregroundColor2;
                break;
            case ThemeSelection.background1:
                spriteRenderer.color = levelDesigner.backgroundColor1;
                break;
            case ThemeSelection.background2:
                spriteRenderer.color = levelDesigner.backgroundColor2;
                break;
        }
    }
}
