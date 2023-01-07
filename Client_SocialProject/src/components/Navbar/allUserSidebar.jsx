import React, { useContext, useEffect } from "react";
import { RollsStatus } from "./../../context/rollsStatus";
import { OwnerSidebar } from "./ownerSidebar";
import { NonProfitSidebar } from "./nonProfitSidebar";
import { CompanySidebar } from "./companySidebar";
import { ActivistSidebar } from "./activistSidebar";
import { GetRoleFromAuth0 } from "./../auth/getRoleFromAuth0";

export const AllUserSidebar = () => {
  const { role } = useContext(RollsStatus);

  return (
    <>
      <GetRoleFromAuth0 />
      {role === "" && <>you have a problem</>}
      {role === "Owner" && (
        <>
          <OwnerSidebar />
        </>
      )}
      {role === "N.P.O" && (
        <>
          <NonProfitSidebar />
        </>
      )}
      {role === "company" && (
        <>
          <CompanySidebar />
        </>
      )}
      {role === "Activist" && (
        <>
          <ActivistSidebar />
        </>
      )}
    </>
  );
};
