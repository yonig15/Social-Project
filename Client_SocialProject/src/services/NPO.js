import axios from "axios";

const ServerAddress = "http://localhost:7153/api/NPO";

// *********************************************All Get Request*******************************

export const getAllNPO_Rows = async () => {
  let endpoint = await axios.get(`${ServerAddress}/get-AllNPORows`);
  if (endpoint.status === 200) {
    return endpoint.data;
  } else {
    return null;
  }
};

// *********************************************All Post Request******************************
