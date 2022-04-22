using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 折叠菜单
/// </summary>
public class FoldPanel : MonoBehaviour
{
    [SerializeField]
    private GameObject panelItem; // 折叠页
    [SerializeField]
    private TitleItem titleItem;
    [SerializeField]
    private DataItem dataItem;

    public List<FoldData> dataList = new List<FoldData>();

    private void Start()
    {
        Create();
    }

    public void Create()
    {
        for (int i = 0; i < dataList.Count; i++)
        {
            // 创建标题
            TitleItem title = Instantiate(titleItem).GetComponent<TitleItem>();
            title.SetTitle(dataList[i].titleName);
            title.transform.SetParent(this.transform);

            // 创建子折叠面板
            GameObject panel = Instantiate(panelItem);
            panel.transform.SetParent(this.transform);
            // 260是折叠页的宽度，30DataItem的高度
            panel.GetComponent<RectTransform>().sizeDelta = new Vector3(380, 80 * dataList[i].data.Count);
            title.SetFoldPanel(panel);
            panel.SetActive(false);

            // 创建折叠页数据
            for (int j = 0; j < dataList[i].data.Count; j++)
            {
                DataItem item = Instantiate(dataItem).GetComponent<DataItem>();
                item.transform.SetParent(panel.transform);
                item.SetInfo(dataList[i].data[j]);
            }
        }
    }
}

[System.Serializable]
public class FoldData
{
    public string titleName;
    public List<ItemData> data;
}

[System.Serializable]
public class ItemData
{
    public string userName;
    //public string imageName;
    public Sprite imageName;
}
