using System.Collections.Generic;
using UnityEngine;

public class RandomSlotAssigner : MonoBehaviour
{
    public List<Transform> slots = new List<Transform>();
    public List<Transform> pieces = new List<Transform>();

    // Stores last slot index for each piece
    private Dictionary<Transform, int> previousAssignments =
        new Dictionary<Transform, int>();

    void Start()
    {
        AssignRandomSlots();
    }

    public void AssignRandomSlots()
    {
        List<int> slotIndices = new List<int>();

        for (int i = 0; i < slots.Count; i++)
            slotIndices.Add(i);

        bool valid = false;

        while (!valid)
        {
            Shuffle(slotIndices);
            valid = true;

            for (int i = 0; i < pieces.Count; i++)
            {
                if (previousAssignments.ContainsKey(pieces[i]) &&
                    previousAssignments[pieces[i]] == slotIndices[i])
                {
                    valid = false;
                    break;
                }
            }
        }

        // Apply positions
        for (int i = 0; i < pieces.Count; i++)
        {
            pieces[i].position = slots[slotIndices[i]].position;
            previousAssignments[pieces[i]] = slotIndices[i];
        }
    }

    void Shuffle(List<int> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            int rnd = Random.Range(i, list.Count);
            (list[i], list[rnd]) = (list[rnd], list[i]);
        }
    }
}