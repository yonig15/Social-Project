import React from "react";
import { useLocation, useNavigate } from "react-router-dom";

import { FormCompany } from "./formCompany";
import { FormNPO } from "./formNPO";
import { FormSocialActivist } from "./formSocialActivist";
import "./styleRegister.css";

export const FormsForRegister = () => {
  const navigate = useNavigate();
  const location = useLocation();

  const { Role } = location.state;

  return (
    <div className="form-container">
      {Role === "Company" && <FormCompany />}
      {Role === "NPO" && <FormNPO />}
      {Role === "Social_Activist" && <FormSocialActivist />}
    </div>
  );
};
