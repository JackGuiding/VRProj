using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.AddressableAssets;

namespace VRProj {

    public class AssetsCore {

        Dictionary<string, GameObject> entityPrefabs;
        AsyncOperationHandle entityHandle; // 指针

        public AssetsCore() {
            entityPrefabs = new Dictionary<string, GameObject>();
        }

        // 从硬盘加载到内存
        // 非托管的内存
        public async Task LoadAll() {
            {
                AssetLabelReference labelReference = new AssetLabelReference();
                labelReference.labelString = AssetLabelConst.Entity;
                var handle = Addressables.LoadAssetsAsync<GameObject>(labelReference, null);
                var all = await handle.Task;
                foreach (var item in all) {
                    entityPrefabs.Add(item.name, item);
                }
                entityHandle = handle;
            }
        }

        public void UnloadAll() {
            if (entityHandle.IsValid()) {
                Addressables.Release(entityHandle);
            }
        }

        // Entity
        public GameObject Entity_GetRole() {
            entityPrefabs.TryGetValue("Entity_Role", out GameObject prefab);
            return prefab;
        }

    }
}