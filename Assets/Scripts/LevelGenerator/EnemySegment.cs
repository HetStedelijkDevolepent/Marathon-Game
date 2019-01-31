using UnityEngine;

[CreateAssetMenu(fileName = "Platform Segment", menuName = "ScriptableObjects/LevelSegments/EnemySegment", order = 2)]
public class EnemySegment : LevelSegment
{
    public SegmentStyle segmentStyle;



    [Range(0, 20)]
    public int minEnemies;
    [Range(0, 20)]
    public int maxEnemies;

    public GameObject enemyType;

    public override GameObject GenerateSegment()
    {
        int currentDistance = 0;

        GameObject go = new GameObject("Segment");


        for (int i = 0; i < Random.Range(minEnemies, maxEnemies); i++)
        {
            Instantiate(enemyType, go.transform).transform.position = new Vector3(Random.Range(-2f, 2f), Random.Range(-2f, 2f));
        }
        /*
        GameObject block = Instantiate(LevelGenerator.ins.normalBlock, go.transform);
        block.transform.position = new Vector3(-width-3, -6);
        block.GetComponent<SpriteRenderer>().size = new Vector2(block.GetComponent<SpriteRenderer>().size.x, currentHeight + 6);
        block.GetComponent<BoxCollider2D>().size = new Vector2(block.GetComponent<BoxCollider2D>().size.x, currentHeight + 6);
        block.GetComponent<BoxCollider2D>().offset = new Vector2(0, (currentHeight + 6)/2);
        */
        Destroy(go, .1f);
        return go;

    }


}
