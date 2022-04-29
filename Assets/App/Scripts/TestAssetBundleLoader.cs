using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAssetBundleLoader : MonoBehaviour
{

    private void Start()
    {
        if (AssetBundleLoader.Instance.TryLoad("fire_loop"))
        {
            AssetBundleLoader.Instance.InstantiateLoadedBundleGameObject();
        }
    }

}
