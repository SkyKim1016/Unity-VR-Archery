using UnityEngine;

public class ShuffleCards : MonoBehaviour
{
    [SerializeField] private Transform parent;

    void Start()
    {
        if (parent != null)
        {
            Shuffle();
        }
        else
        {
            Debug.LogError("Parent is not assigned.");
        }
    }

    private void Shuffle()
    {
        int childCount = parent.childCount;

        for (int i = 0; i < childCount; i++)
        {
            int randomIndex = Random.Range(0, childCount);
            parent.GetChild(i).SetSiblingIndex(randomIndex);
        }
    }
}
