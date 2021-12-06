using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignedDistanceFieldGenerator
{
    public struct Pixel
    {
        public float distance;
        public bool edge;
    }

    public Pixel[] pixels;
    public int xDimensions;
    public int yDimensions;

    public SignedDistanceFieldGenerator()
    {
        xDimensions = 0;
        yDimensions = 0;
        pixels = null;
    }
}