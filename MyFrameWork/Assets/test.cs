using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class test : MonoBehaviour
{
    void Start()
    {
        Create();
    }
    async void Create()
    {
       var handle = Addressables.LoadAssetAsync<GameObject>("tree1");
       await handle.Task;
        GameObject obj =  Instantiate(handle.Result);

        obj.transform.position = Vector3.zero;
        obj.transform.localScale = Vector3.one * 10;
        Debug.Log("加载成功1");
        var handle2 = Addressables.LoadAssetAsync<GameObject>("tree2");
        await handle2.Task;
        GameObject obj2 = Instantiate(handle2.Result);
        obj2.transform.position = Vector3.one;
        obj2.transform.localScale = Vector3.one * 10;
        Debug.Log("加载成功2");
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
