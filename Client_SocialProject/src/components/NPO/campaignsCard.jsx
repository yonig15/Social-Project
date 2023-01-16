import React, { useState, useEffect, useContext } from "react";

import "./CampaignsCardsStyle.css";
import { useNavigate } from "react-router-dom";
import { getAllCampaignsByNPO_code } from "./../../services/allGetServices";
import { RollsStatus } from "./../../context/rollsStatus";
import { UserDataContext } from "./../../context/userData";

export const CampaignsCard = () => {
  const { role } = useContext(RollsStatus);
  const { userInfo } = useContext(UserDataContext);

  const [AllCampaigns, setAllCampaigns] = useState([]);

  const navigate = useNavigate();

  const get_CampaignsByNPO_Code = async () => {
    let result = await getAllCampaignsByNPO_code(userInfo.Code);
    setAllCampaigns(result);
  };

  useEffect(() => {
    get_CampaignsByNPO_Code();
  }, [userInfo]);

  const handleProduct = (Campaign) => {
    navigate("/editOrAddProduct", {
      state: {
        Campaign,
      },
    });
  };

  const handleDonateProduct = (Campaign) => {
    navigate("/productTable", {
      state: {
        Campaign,
      },
    });
  };

  return (
    <div className="card--container">
      {AllCampaigns.length > 0 ? (
        AllCampaigns.map((Campaign) => {
          let {
            Code,
            Name,
            Email,
            Description,
            Landing_Page_URL,
            HashTag,
            NPO_code,
            Image,
            Is_Active,
          } = Campaign;
          return (
            <div className="card">
              <img className="card-img-top" src={Image} alt="Card image cap" />
              <div className="card-body">
                <h4 className="card-title">{Name}</h4>
                <p className="card-text">
                  <b>Email: </b>
                  {Email}
                </p>
                <p className="card-text">
                  <b>Description:</b> {Description}
                </p>
              </div>
              {role === "company" && (
                <div className="card--button">
                  <button
                    className="btn btn-success"
                    onClick={() => handleProduct(Campaign)}
                  >
                    Add product
                  </button>
                </div>
              )}
              {role === "Activist" && (
                <div className="card--button">
                  <button
                    className="btn btn-success"
                    onClick={() => handleDonateProduct(Campaign)}
                  >
                    Donate product
                  </button>
                </div>
              )}
              <div className="card-footer">
                <small className="text-muted">{HashTag}</small>
              </div>
            </div>
          );
        })
      ) : (
        <h1>There are no campaigns.</h1>
      )}
    </div>
  );
};
