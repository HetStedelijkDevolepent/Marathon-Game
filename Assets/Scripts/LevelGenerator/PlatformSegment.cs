using UnityEngine;

[CreateAssetMenu(fileName = "Platform Segment", menuName = "ScriptableObjects/LevelSegments/PlatformSegment", order = 1)]
public class PlatformSegment : LevelSegment
{
    public SegmentStyle segmentStyle;




    public override GameObject GenerateSegment()
    {
        int currentDistance = 0;
        float currentHeight = 1f;
        
        GameObject go = new GameObject("Segment");

        currentDistance -= 3;

        while (currentDistance < width - 4)
        {

            if(width-currentDistance < 6)
            {
                currentDistance += Random.Range(4, width-currentDistance);
            }
            else
            {
                currentDistance += Random.Range(4, 8);
            }


            GameObject platform = Instantiate(LevelGenerator.ins.platform, go.transform);
            platform.transform.position = new Vector3(-currentDistance, currentHeight);

            currentHeight += Random.Range(0f, 1.5f);



        }

        GameObject block = Instantiate(LevelGenerator.ins.normalBlock, go.transform);
        block.transform.position = new Vector3(-width-3, -6);
        block.GetComponent<SpriteRenderer>().size = new Vector2(block.GetComponent<SpriteRenderer>().size.x, currentHeight + 6);
        block.GetComponent<BoxCollider2D>().size = new Vector2(block.GetComponent<BoxCollider2D>().size.x, currentHeight + 6);
        block.GetComponent<BoxCollider2D>().offset = new Vector2(0, (currentHeight + 6)/2);

        Destroy(go, .1f);

        
        return go;

    }


}
