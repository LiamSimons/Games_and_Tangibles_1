using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject prefabBlock;

    Timer fallTimer;

    [SerializeField]
    float minTime = 1;
    [SerializeField]
    float maxTime = 4;

    float minX;
    float maxX;

    

    // Start is called before the first frame update
    void Start()
    {
        fallTimer = gameObject.AddComponent<Timer>();
        fallTimer.Duration = NextFloat(minTime, maxTime);
        fallTimer.Run();
        float screenWidth = Screen.width;
        maxX = screenWidth / 2;
        minX = maxX;
    }

    // Update is called once per frame
    void Update()
    {
        if (fallTimer.Finished)
        {
            //spawn een bal en begin opnieuw
            spawnBlock();
            //
            fallTimer.Duration = NextFloat(minTime, maxTime);
            fallTimer.Run();
        }
    }
    static float NextFloat(float minimum, float maximum)
    {
        System.Random random = new System.Random();
        double value = random.NextDouble() * (maximum - minimum) + minimum;
        return (float)value;
    }

    void spawnBlock()
    {
        float RandX = NextFloat(ScreenUtils.ScreenLeft, ScreenUtils.ScreenRight);
        float RandY = ScreenUtils.ScreenTop;
        Vector3 blockPos = new Vector3(RandX, RandY, 0);
        GameObject block = Instantiate(prefabBlock);
        block.transform.position = blockPos;
        
    }
}
