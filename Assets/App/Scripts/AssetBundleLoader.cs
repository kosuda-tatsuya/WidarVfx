using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using klib;

public class AssetBundleLoader : Singleton<AssetBundleLoader>
{

#if UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN
    private static readonly string ASSETBUNDLE_DIR = Application.streamingAssetsPath + "/AssetBundles/StandaloneWindows";
#elif UNITY_IOS
    private static readonly string ASSETBUNDLE_DIR = Application.streamingAssetsPath + "/AssetBundles/iOS";
#elif UNITY_ANDROID
    private static readonly string ASSETBUNDLE_DIR = Application.streamingAssetsPath + "/AssetBundles/Android";
#endif

    private AssetBundle _loadedAB;

    public GameObject GetLoadedBundleGameObject()
    {
        if (_loadedAB == null) { return null; }

        return _loadedAB.LoadAsset<GameObject>(_loadedAB.name);
    }

    public GameObject InstantiateLoadedBundleGameObject()
    {
        if (_loadedAB == null) { return null; }

        var prefab = _loadedAB.LoadAsset<GameObject>(_loadedAB.name);
        var obj = Instantiate(prefab, Vector3.zero, Quaternion.identity);
        _loadedAB.Unload(false);
        _loadedAB = null;
        return obj;
    }

    public bool TryLoad(string name)
    {
        return TryLoadFromLocalFile(name);
    }

    private bool TryLoadFromLocalFile(string name)
    {
        if (_loadedAB != null)
        {
            _loadedAB.Unload(false);
        }

        _loadedAB = AssetBundle.LoadFromFile(ASSETBUNDLE_DIR + "/" + name);

        if (_loadedAB == null)
        {
            Debug.LogError($"[AssetBundleLoader] failure load : name = {name}");
            return false;
        }

        return true;
    }

}

