import React, { useEffect, useContext } from "react";
import { useAuth0 } from "@auth0/auth0-react";
import { RollsStatus } from "./../../context/rollsStatus";
import { getRolesData } from "../../services/allGetServices";

export const GetRoleFromAuth0 = (props) => {
  const { role, setRole } = useContext(RollsStatus);
  const { user } = useAuth0();

  const handleRoles = async () => {
    let userId = user.sub;
    let RoleData = await getRolesData(userId);
    if (Object.keys(RoleData).length === 0) {
      setRole("");
    } else {
      let RoleName = RoleData[0].name;
      setRole(RoleName);
    }
  };

  useEffect(() => {
    handleRoles();
  }, []);

  // return <div>{role}</div>;
};
