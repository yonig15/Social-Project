import axios from "axios";

const ServerAddress = "http://localhost:7153/api/SocialActivist";

// *********************************************All Get Request*******************************
export const getAllSA_Rows = async () => {
  let endpoint = await axios.get(`${ServerAddress}/get-AllSARows`);
  if (endpoint.status === 200) {
    return endpoint.data;
  } else {
    return null;
  }
};

export const UpdateAddMoneyStatus = async (userInfoCode) => {
  let endpoint = await axios.get(
    `${ServerAddress}/update-AddMoneyStatus/${userInfoCode}`
  );
  if (endpoint.status === 200) {
    return endpoint.data;
  } else {
    return null;
  }
};

// *********************************************All Post Request******************************
