using UnityEngine;
using System.Collections.Generic;

public class ShuffleCardsWithList : MonoBehaviour
{
    [SerializeField] private Transform _parent;
    private List<Transform> _originalChildrenOrder = new List<Transform>();
    private List<Transform> _shuffledChildrenOrder = new List<Transform>();

    void Start()
    {
        if (_parent != null)
        {
            InitializeOriginalOrder();
            Shuffle();
            ApplyShuffledOrder();
        }
        else
        {
            Debug.LogError("Parent is not assigned.");
        }
    }

    private void InitializeOriginalOrder()
    {
        int childCount = _parent.childCount;
        for (int i = 0; i < childCount; i++)
        {
            _originalChildrenOrder.Add(_parent.GetChild(i));
        }
        Unparent();
    }

    private void Shuffle()
    {
        while (_originalChildrenOrder.Count > 0)
        {
            int randomIndex = Random.Range(0, _originalChildrenOrder.Count);
            Transform child = _originalChildrenOrder[randomIndex];
            _originalChildrenOrder.RemoveAt(randomIndex);
            _shuffledChildrenOrder.Add(child);
        }
    }

    private void ApplyShuffledOrder()
    {
        foreach (Transform child in _shuffledChildrenOrder)
        {
            child.SetParent(_parent);
        }
    }

    private void Unparent()
    {
        foreach (Transform child in _originalChildrenOrder)
        {
            child.SetParent(null);
        }
    }
}


