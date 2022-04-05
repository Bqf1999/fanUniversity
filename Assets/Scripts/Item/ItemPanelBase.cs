using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemPanelBase : MonoBehaviour
{
    private List<ItemPanelBase> childList;
    [HideInInspector]
    public Button downArrow;
    public Sprite down, right, dot;
    public bool isOpen { get; set; }
    private Vector2 startSize;
    private void Awake()
    {
        childList = new List<ItemPanelBase>();
        downArrow = this.transform.Find("ContentPanel/ArrowButton").GetComponent<Button>();
        downArrow.onClick.AddListener(() =>
        {

            if (isOpen)
            {
                //CloseChild();
                isOpen = false;
            }
            else
            {
                //OpenChild();
                isOpen = true;
            }
        });
        startSize = this.GetComponent<RectTransform>().sizeDelta;
        isOpen = false;
    }
    public void AddChild() {
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
