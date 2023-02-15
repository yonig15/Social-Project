import axios from "axios";

const ServerAddress = "http://localhost:7153/api/NPO";

// *********************************************All Get Request*******************************

export const getAllNPO_Rows = async () => {
  try {
    let endpoint = await axios.get(`${ServerAddress}/get-AllNPORows`);
    if (endpoint.status === 200) {
      return endpoint.data;
    } else {
      return null;
    }
  } catch (error) {
    console.log(
      `An Exception occurred while initializing the getAllNPO_Rows Service : ${error}`
    );
    console.error(error);
  }
};

// *********************************************All Post Request******************************
