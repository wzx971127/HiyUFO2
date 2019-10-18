using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreRecorder : MonoBehaviour {
    public int score;
    private Dictionary<Color, int> scoreTable = new Dictionary<Color, int>();

    void Start()
    {
        score = 0;
        scoreTable.Add(Color.white, 1);
        scoreTable.Add(Color.gray, 2);
        scoreTable.Add(Color.black, 4);
    }

    public void reset()
    {
        score = 0;
    }

    public void record(GameObject disk)
    {
        score += scoreTable[disk.GetComponent<DiskData>().getColor()];
    }
}
