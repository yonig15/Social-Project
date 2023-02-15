import axios from "axios";

const TwitterAddress = "http://localhost:7153/api/twitter";

// *********************************************All Get Request*******************************
export const getAllTwitted = async () => {
  try {
    let endpoint = await axios.get(`${TwitterAddress}/get-AllTwitted`);
    if (endpoint.status === 200) {
      return endpoint.data;
    } else {
      return null;
    }
  } catch (error) {
    console.log(
      `An Exception occurred while initializing the getAllTwitted Service : ${error}`
    );
    console.error(error);
  }
};

export const UpdateMoneyStatus = async (TotalMoneyStatus, SA_Code) => {
  try {
    let endpoint = await axios.get(
      `${TwitterAddress}/get-UpdateMoneyStatus/${TotalMoneyStatus}/${SA_Code}`
    );
    if (endpoint.status === 200) {
      return endpoint.data;
    } else {
      return null;
    }
  } catch (error) {
    console.log(
      `An Exception occurred while initializing the UpdateMoneyStatus Service : ${error}`
    );
    console.error(error);
  }
};

// *********************************************All Post Request******************************

export const MakeA_TweetInTwitter = async (Tweet) => {
  try {
    await axios.post(`${TwitterAddress}/post-MakeATweet`, Tweet);
  } catch (error) {
    console.log(
      `An Exception occurred while initializing the MakeA_TweetInTwitter Service : ${error}`
    );
    console.error(error);
  }
};

export const AddTweetToDB = async (Tweet, SA_code) => {
  try {
    await axios.post(`${TwitterAddress}/Post-tweet/${SA_code}`, Tweet);
  } catch (error) {
    console.log(
      `An Exception occurred while initializing the AddTweetToDB Service : ${error}`
    );
    console.error(error);
  }
};
