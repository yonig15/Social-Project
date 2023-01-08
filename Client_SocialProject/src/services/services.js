import axios from "axios";

const ServerAddress = "http://localhost:7153/api/Users";

export const getRolesData = async (userId) => {
  console.log(userId);
  let endpoint = await axios.get(`${ServerAddress}/get-role/${userId}`);
  console.log(endpoint.data);
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

export const addFormToContactUs = async (frm) => {
  await axios.post(`${ServerAddress}/post`, frm);
};

export const getData = async () => {
  let endpoint = await axios.get(`${ServerAddress}/get`);
  return endpoint;
};

export const UpdateProduct = async (ProductToUpdate) => {
  await axios.post(`${ServerAddress}/update`, ProductToUpdate);
  console.log(ProductToUpdate);
};

export const deleteProduct = async (ProductId) => {
  try {
    await axios.delete(`${ServerAddress}/delete/${ProductId}`);
  } catch (error) {
    console.error(error);
  }
};
