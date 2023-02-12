import axios from "axios";

const ServerAddress = "http://localhost:7153/api/Campaigns";

// *********************************************All Get Request*******************************
export const getAllCampaigns = async () => {
  let endpoint = await axios.get(`${ServerAddress}/get-AllCampaigns`);
  if (endpoint.status === 200) {
    return endpoint.data;
  } else {
    return null;
  }
};

export const getAllCampaignsByNPO_code = async (NPO_code) => {
  let endpoint = await axios.get(
    `${ServerAddress}/get-AllCampaignsByNPO_code/${NPO_code}`
  );
  if (endpoint.status === 200) {
    return endpoint.data;
  } else {
    return null;
  }
};

// *********************************************All Post Request******************************
