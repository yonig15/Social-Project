import React, { useContext } from "react";
import { Link } from "react-router-dom";
import InventoryTwoToneIcon from "@mui/icons-material/InventoryTwoTone";
import AddTwoToneIcon from "@mui/icons-material/AddTwoTone";
import { Profile } from "./../auth/profile";
import { RollsStatus } from "./../../context/rollsStatus";

export const ActivistSidebar = () => {
  const { role } = useContext(RollsStatus);
  return (
    <div className="ActivistSidebar--container">
      <ul className="ActivistSidebar--menu">
        <li>
          <label className="ActivistSidebar--TitleLbl frm-lbl">{role}</label>
        </li>
        <li>
          {/* צריך לינק לדף של המשתמשים */}
          <Link to="/contactUs">
            <label className="ActivistSidebar--lbl frm-lbl">
              <InventoryTwoToneIcon />
              Product report by campaign
            </label>
          </Link>
        </li>
        <li>
          {/* צריך לשלוח לדף של דוח קמפיינים */}
          <Link to="/contactUs">
            <label className="ActivistSidebar--lbl frm-lbl">
              <InventoryTwoToneIcon />
              Report of products I donated
            </label>
          </Link>
        </li>
        <br />
        <li>
          <Profile />
        </li>
        <br />
      </ul>
    </div>
  );
};
