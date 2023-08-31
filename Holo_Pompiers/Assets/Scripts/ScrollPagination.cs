using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.UI;

public class ScrollPagination : MonoBehaviour
{
    [SerializeField] private ScrollingObjectCollection scrollView;

    public ScrollingObjectCollection ScrollView
    {
        get
        {
            if (scrollView == null)
            {
                scrollView = GetComponent<ScrollingObjectCollection>();
            }
            return scrollView;
        }
        set
        {
            scrollView = value;
        }
    }

    public void ScrollByTier(int amount)
    {
        scrollView.MoveByTiers(amount);
    }
}
