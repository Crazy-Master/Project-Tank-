using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textRender : MonoBehaviour
{
    [SerializeField] private int _width;
    [SerializeField] private int _height;
    [SerializeField] private float _scale;

    [SerializeField] private int _octaves;
    [SerializeField] private float _persistence;
    [SerializeField] private float _lacunarity;

    [SerializeField] private int _seed;
    [SerializeField] private Vector2 _offset;

    public void SetText(int width, int height, int seed, float scale, int octaves, float persistence, float lacunarity, Vector2 offset)
    {
        _width = width;
        _height = height;
        _scale = scale;
        _octaves = octaves;
        _persistence = persistence;
        _lacunarity = lacunarity;
        _offset = offset;
        _seed = seed;
    }
}
