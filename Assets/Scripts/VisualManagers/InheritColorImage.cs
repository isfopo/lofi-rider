using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteAlways]
public class InheritColorImage : MonoBehaviour
{
    public enum ThemeSelection
    {
        foreground1,
        foreground2,
        background1,
        background2
    }

    public Image image;
    public LevelDesigner levelDesigner;
    public ThemeSelection themeSelection;

    void Start()
    {
        image = GetComponent<Image>();
    }

    void Update()
    {
        levelDesigner = FindObjectOfType<LevelDesigner>();

        if (levelDesigner != null)
        {
            image.color = SelectTheme(themeSelection);
        }
    }

    Color SelectTheme(ThemeSelection themeSelection)
    {
        switch (themeSelection)
        {
            case ThemeSelection.foreground1:
                return levelDesigner.foregroundColor1;

            case ThemeSelection.foreground2:
                return levelDesigner.foregroundColor2;
             
            case ThemeSelection.background1:
                return levelDesigner.backgroundColor1;
              
            case ThemeSelection.background2:
                return levelDesigner.backgroundColor2;

            default:
                return new Color(1, 1, 1, 1);
        }
    }
}
