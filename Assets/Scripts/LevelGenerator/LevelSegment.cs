using UnityEngine;

public class LevelSegment : ScriptableObject
{
    public int width;

    public virtual GameObject GenerateSegment()
    {
        return null;
    }
}

public enum SegmentStyle
{
    normal,
    hell
}