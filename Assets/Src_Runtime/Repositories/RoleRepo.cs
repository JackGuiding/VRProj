using System;
using System.Collections.Generic;
using UnityEngine;

namespace VRProj {

    public class RoleRepo {

        Dictionary<int, RoleEntity> all;

        public RoleRepo() {
            all = new Dictionary<int, RoleEntity>();
        }

        public void Add(RoleEntity entity) {
            all.Add(entity.id, entity);
        }

        public bool TryGet(int id, out RoleEntity entity) {
            return all.TryGetValue(id, out entity);
        }

        public void Foreach(Action<RoleEntity> action) {
            foreach (var item in all.Values) {
                action(item);
            }
        }

        public void Remove(int id) {
            all.Remove(id);
        }

    }
}