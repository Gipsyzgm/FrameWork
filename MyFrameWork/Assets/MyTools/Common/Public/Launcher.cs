using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;
using AppDomain = ILRuntime.Runtime.Enviorment.AppDomain;

public class Launcher : MonoBehaviour
{


    // 游戏的总入口
    //注意先后顺序
    async void Awake()
    {
        DataMgr.Instance.InitAllConfig();
        //await VersionCheckMgr.Instance.Check();
        //while (!VersionCheckMgr.Instance.isUpdateCheckComplete)
        //{
        //    await new WaitForEndOfFrame();
        //}
        //ABMgr.Instance.Initialize();
        LanguageMgr.Init();
        PanelMgr.Instance.OpenPanel<MenuePl>();
        //MyAudioMgr.Instance.Init();
        //GameObject gameObject = ABMgr.Instance.LoadPrefab("prefabs/scenemodel/tree_red_01");
        //GameObject obj = Instantiate(gameObject);
        //obj.transform.position = Vector3.zero;
        //StartHotFixPro();
    }


    AppDomain appdomain;
    MemoryStream fs;
    MemoryStream pdb;
    private const string dllPath = "Assets/HotUpdateResources/Dll/Hidden~/HotUpdateScripts.dll";
    private const string pdbPath = "Assets/HotUpdateResources/Dll/Hidden~/HotUpdateScripts.pdb";

    [SerializeField] public string Key;
    [SerializeField] public bool UsePdb = true;

    /// <summary>
    /// 进入热更工程
    /// </summary>
    public void StartHotFixPro()
    {
        LoadHotFixAssembly();
    }

    void LoadHotFixAssembly()
    {
        appdomain = new AppDomain();
        pdb = null;

        ////编译模式
        //if (!Assets.runtimeMode)
        //{
        //    if (File.Exists(dllPath))
        //    {
        //        fs = new MemoryStream(DLLMgr.FileToByte(dllPath));
        //    }
        //    else
        //    {
        //        Debug.LogError("DLL文件不存在");
        //        return;
        //    }

        //    //查看是否有PDB文件
        //    if (File.Exists(pdbPath) && UsePdb && (File.GetLastWriteTime(dllPath) - File.GetLastWriteTime(pdbPath)).Seconds < 30)
        //    {
        //        pdb = new MemoryStream(DLLMgr.FileToByte(pdbPath));
        //    }
        //}
        //else//解密加载
        //{
        //    var dllAsset = Assets.LoadAsset("HotUpdateScripts.bytes", typeof(TextAsset));
        //    if (dllAsset.error != null)
        //    {
        //        Debug.LogError.PrintError(dllAsset.error);
        //        return;
        //    }
        //    var dll = (TextAsset)dllAsset.asset;
        //    try
        //    {
        //        var original = CryptoHelper.AesDecrypt(dll.bytes, Key);
        //        fs = new MemoryStream(original);
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.LogError("加载热更DLL失败，可能是解密密码不正确");
        //        Debug.LogError("加载热更DLL错误：\n" + ex.Message);
        //        return;
        //    }
        //}

        //try
        //{
        //    appdomain.LoadAssembly(fs, pdb, new PdbReaderProvider());
        //}
        //catch (Exception e)
        //{
        //    if (!UsePdb)
        //    {
        //        Debug.LogError("加载热更DLL失败，请确保HotUpdateResources/Dll里面有HotUpdateScripts.bytes文件，并且Build Bundle后将DLC传入服务器");
        //        Debug.LogError("加载热更DLL错误：\n" + e.Message);
        //        return;
        //    }

        //    Debug.LogError("PDB不可用，可能是DLL和PDB版本不一致，可能DLL是Release，如果是Release出包，请取消UsePdb选项，本次已跳过使用PDB");
        //    UsePdb = false;
        //    LoadHotFixAssembly();
        //}

        //InitILrt.InitializeILRuntime(appdomain);
        //OnHotFixLoaded();
    }





    void OnHotFixLoaded()
    {
        appdomain.Invoke("HotUpdateScripts.Program", "RunGame", null, null);
    }
 
}
