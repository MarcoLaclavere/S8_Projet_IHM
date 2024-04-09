using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LapManagerTD1 : MonoBehaviour
{
    public List<Checkpoint> checkpoints;
    public int totalLaps = 3;
    private int lastPlayerCheckpoint = -1;
    private int currentPlayerLap = 0;
    public UIManager ui;

    void Start()
    {
        ListenCheckpoints(true);
        ui.UpdateLapText("Lap 0 / " + totalLaps);
    }

    private void ListenCheckpoints(bool subscribe)
    {
        foreach (Checkpoint checkpoint in checkpoints)
        {
            if (subscribe) checkpoint.onCheckpointEnter.AddListener(CheckpointActivated);
            else checkpoint.onCheckpointEnter.RemoveListener(CheckpointActivated);
        }
    }

    public void CheckpointActivated(GameObject car, Checkpoint checkpoint)
    {
        if (checkpoints.Contains(checkpoint))
        {
            int checkpointNumber = checkpoints.IndexOf(checkpoint);
            // first time ever the car reach the first checkpoint
            bool startingFirstLap = checkpointNumber == 0 && lastPlayerCheckpoint == -1;
            // finish line checkpoint is triggered & last checkpoint was reached
            bool lapIsFinished = checkpointNumber == 0 && lastPlayerCheckpoint >= checkpoints.Count - 1;
            if (startingFirstLap || lapIsFinished) 
            {
                currentPlayerLap += 1;
                lastPlayerCheckpoint = 0;

                // if this was the final lap
                if (currentPlayerLap > totalLaps)
                {
                    Debug.Log("You won");
                    ui.UpdateLapText("You won");
                    //wait 5 seconds before changing scene
                    
                    

                    SceneManager.LoadScene("planetsMenu");
                }
                else
                {
                    Debug.Log("Lap " + currentPlayerLap);
                    ui.UpdateLapText("Lap " + currentPlayerLap + " / " + totalLaps);
                }
            }
            // next checkpoint reached
            else if (checkpointNumber == lastPlayerCheckpoint + 1) 
            {
                lastPlayerCheckpoint += 1;
            }
        }
        Debug.Log("Checkpoint " + lastPlayerCheckpoint);
    }
}