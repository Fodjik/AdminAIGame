using UnityEngine;

public class RunManager : MonoBehaviour
{
    public static RunManager Instance;

    private void Awake()
    {
        
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

    
    public void RoomCleared()
    {
        Debug.Log("Room cleared! Waiting for next room...");

        
    }

    
    public void StartRoom(RoomWaveTracker room)
    {
        room.StartWave();
    }
}
