using UnityEngine;

public class RoomEntranceTrigger : MonoBehaviour
{
    private RoomWaveTracker room;
    private bool activated = false;

    private void Awake()
    {
        room = GetComponentInParent<RoomWaveTracker>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (activated)
            return;

        if (other.CompareTag("Player"))
        {
            activated = true;
            room.StartWave();
        }
    }
}
