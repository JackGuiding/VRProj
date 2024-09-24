using System;

namespace VRProj {

    public class IDService {

        int roleRecord;

        public IDService() {
            roleRecord = 0;
        }

        public int PickRoleID() {
            return roleRecord++;
        }

    }

}