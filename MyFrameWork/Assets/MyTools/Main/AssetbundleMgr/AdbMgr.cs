using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class AdbMgr : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DownLoadAsset()
    {
        StartCoroutine(download());
    }

    IEnumerator download()
    {
        //初始化Addressable
        var init = Addressables.InitializeAsync();
        yield return init;
        List<object> list = new List<object>();
        list.Add("Cube");
        list.Add("Sphere");
        var downloadsize = Addressables.GetDownloadSizeAsync(list);
        yield return downloadsize;
        Debug.Log("start download:" + downloadsize.Result);
        var download = Addressables.DownloadDependenciesAsync(list, Addressables.MergeMode.None);
        yield return download;
        Debug.Log("download finish");
    }

    public void UpdateAsset()
    {
        StartCoroutine(checkUpdate());
    }

    IEnumerator checkUpdate()
    {
        //初始化Addressable
        var init = Addressables.InitializeAsync();
        yield return init;
        //开始连接服务器检查更新
        AsyncOperationHandle<List<string>> checkHandle = Addressables.CheckForCatalogUpdates(false);
        //检查结束，验证结果 
        yield return checkHandle;
        if (checkHandle.Status == AsyncOperationStatus.Succeeded)
        {
            List<string> catalogs = checkHandle.Result;
            if (catalogs != null && catalogs.Count > 0)
            {
                Debug.Log("download start");
                var updateHandle = Addressables.UpdateCatalogs(catalogs, false);
                yield return updateHandle;
                Debug.Log("download finish");
            }
        }
        Addressables.Release(checkHandle);
    }
}
