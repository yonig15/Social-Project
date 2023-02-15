import axios from "axios";

const ServerAddress = "http://localhost:7153/api/BCompany";

// *************************All Get Request******************

export const getAllCompany_Rows = async () => {
  try {
    let endpoint = await axios.get(`${ServerAddress}/get-AllCompanyRows`);
    if (endpoint.status === 200) {
      return endpoint.data;
    } else {
      return null;
    }
  } catch (error) {
    console.log(
      `An Exception occurred while initializing the getAllCompany_Rows Service : ${error}`
    );
    console.error(error);
  }
};

// *************************All Post Request******************
