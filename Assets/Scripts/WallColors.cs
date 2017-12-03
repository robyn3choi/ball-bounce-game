using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class WallColors {
    public static Color32 defaultColor = new Color32(171, 171, 171, 255);
    public static Color32 red = new Color32(255, 118, 118, 255);
    public static Color32 yellow = new Color32(255, 255, 118, 255);
    public static Color32 green = new Color32(118, 255, 118, 255);
    public static Color32 blue = new Color32(118, 118, 255, 255);
    public static Color32 pink = new Color32(255, 118, 255, 255);

    public static List<Color32> colors;

    public static void InitColors() {
        colors = new List<Color32>();
        colors.Add(red);
        colors.Add(yellow);
        colors.Add(green);
        colors.Add(blue);
        colors.Add(pink);
    }
}


