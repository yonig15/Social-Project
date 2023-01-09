import axios from "axios";

const ServerAddress = "http://localhost:7153/api/Users";

export const getRolesData = async (userId) => {
  let endpoint = await axios.get(`${ServerAddress}/get-role/${userId}`);
  if (endpoint.status === 200) {
    return endpoint.data;
  } else {
    return null;
  }
};

export const getPending = async (email) => {
  console.log(email);
  let endpoint = await axios.get(`${ServerAddress}/get-Pending/${email}`);
  console.log(endpoint.data);
  if (endpoint.status === 200) {
    return endpoint.data;
  } else {
    return null;
  }
};

export const getData = async () => {
  let endpoint = await axios.get(`${ServerAddress}/get`);
  return endpoint;
};
