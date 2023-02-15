import axios from "axios";

const ServerAddress = "http://localhost:7153/api/Campaigns";

// *********************************************All Get Request*******************************
export const getAllCampaigns = async () => {
  try {
    let endpoint = await axios.get(`${ServerAddress}/get-AllCampaigns`);
    if (endpoint.status === 200) {
      return endpoint.data;
    } else {
      return null;
    }
  } catch (error) {
    console.log(
      `An Exception occurred while initializing the getAllCampaigns Service : ${error}`
    );
    console.error(error);
  }
};

export const getAllCampaignsByNPO_code = async (NPO_code) => {
  try {
    let endpoint = await axios.get(
      `${ServerAddress}/get-AllCampaignsByNPO_code/${NPO_code}`
    );
    if (endpoint.status === 200) {
      return endpoint.data;
    } else {
      return null;
    }
  } catch (error) {
    console.log(
      `An Exception occurred while initializing the getAllCampaignsByNPO_code Service : ${error}`
    );
    console.error(error);
  }
};

// *********************************************All Post Request******************************
