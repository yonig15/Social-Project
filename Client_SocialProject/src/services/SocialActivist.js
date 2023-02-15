import axios from "axios";

const ServerAddress = "http://localhost:7153/api/SocialActivist";

// *********************************************All Get Request*******************************
export const getAllSA_Rows = async () => {
  try {
    let endpoint = await axios.get(`${ServerAddress}/get-AllSARows`);
    if (endpoint.status === 200) {
      return endpoint.data;
    } else {
      return null;
    }
  } catch (error) {
    console.log(
      `An Exception occurred while initializing the getAllSA_Rows Service : ${error}`
    );
    console.error(error);
  }
};

export const UpdateAddMoneyStatus = async (userInfoCode) => {
  try {
    let endpoint = await axios.get(
      `${ServerAddress}/update-AddMoneyStatus/${userInfoCode}`
    );
    if (endpoint.status === 200) {
      return endpoint.data;
    } else {
      return null;
    }
  } catch (error) {
    console.log(
      `An Exception occurred while initializing the UpdateAddMoneyStatus Service : ${error}`
    );
    console.error(error);
  }
};

// *********************************************All Post Request******************************
