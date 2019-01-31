using UnityEngine;
using System.Collections;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField]
    int levelSegments = 20;


    [SerializeField]
    GameObject player;


    [SerializeField]
    LevelSegment[] veryCommonLevelSegments;

    [SerializeField]
    LevelSegment[] commonLevelSegments;

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

        for (int i = 0; i < levelSegments; i++)
        {
            LevelSegment l;
            float rand = Random.Range(0f, 1f);
            if(rand > 0.5f)
            {
                l = commonLevelSegments[Random.Range(0, commonLevelSegments.Length)];

            }
            else
            {
                l = veryCommonLevelSegments[Random.Range(0, veryCommonLevelSegments.Length)];
            }
            GenerateSegment(l);

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
