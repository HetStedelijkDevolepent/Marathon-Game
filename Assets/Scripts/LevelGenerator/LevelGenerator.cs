using UnityEngine;
using System.Collections;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField]
    GameObject player;


    [SerializeField]
    LevelSegment[] levelSegments;

    [SerializeField]
    SegmentStyle style;

    public GameObject normalGround;

    public GameObject normalBlock;

    public GameObject platform;

    int currentDistance = 0;

    public static LevelGenerator ins;

    private void Awake()
    {
        ins = this;
    }

    private void Start()
    {

        GenerateLevel();
    }

    private void GenerateLevel()
    {
        SetBackground();
        foreach(LevelSegment segment in levelSegments)
        {
            GenerateSegment(segment);
        }

        StartCoroutine(EnablePlayer());
    }

    IEnumerator EnablePlayer()
    {
        yield return new WaitForSeconds(.2f);
        player.SetActive(true);

    }

    private void GenerateSegment(LevelSegment segment)
    {
        Instantiate(segment.GenerateSegment(), new Vector3(-currentDistance, 0), Quaternion.identity);
        currentDistance += segment.width+6;
    }

    private void SetBackground()
    {
        switch (style)
        {
            case SegmentStyle.normal:
                Instantiate(normalGround);
                break;
        }
    }
}
