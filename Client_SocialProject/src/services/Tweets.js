import axios from "axios";

const TwitterAddress = "http://localhost:7153/api/twitter";

// *********************************************All Get Request*******************************
export const getAllTwitted = async () => {
  let endpoint = await axios.get(`${TwitterAddress}/get-AllTwitted`);
  if (endpoint.status === 200) {
    return endpoint.data;
  } else {
    return null;
  }
};

export const get_twitterPostForUpdate = async () => {
  let endpoint = await axios.get(`${TwitterAddress}/get-twitterPostForUpdate`);
  if (endpoint.status === 200) {
    return endpoint.data;
  } else {
    return null;
  }
};

export const UpdateMoneyStatus = async (TotalMoneyStatus, SA_Code) => {
  let endpoint = await axios.get(
    `${TwitterAddress}/get-UpdateMoneyStatus/${TotalMoneyStatus}/${SA_Code}`
  );
  if (endpoint.status === 200) {
    return endpoint.data;
  } else {
    return null;
  }
};

// *********************************************All Post Request******************************

export const MakeA_TweetInTwitter = async (Tweet) => {
  try {
    await axios.post(`${TwitterAddress}/post-MakeATweet`, Tweet);
  } catch (error) {}
};

export const AddTweetToDB = async (Tweet, SA_code) => {
  try {
    await axios.post(`${TwitterAddress}/Post-tweet/${SA_code}`, Tweet);
  } catch (error) {}
};
