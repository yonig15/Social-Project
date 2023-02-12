import axios from "axios";

const ServerAddress = "http://localhost:7153/api/Users";

// *********************************************All Get Request*******************************
export const getRolesData = async (userId) => {
  let endpoint = await axios.get(`${ServerAddress}/get-RolesData/${userId}`);
  console.log(userId, "test");
  if (endpoint.status === 200) {
    return endpoint.data;
  } else {
    return null;
  }
};

export const getUserInfoData = async (email, role) => {
  // console.log(1, email, role);
  let endpoint = await axios.get(
    `${ServerAddress}/get-UserInfoData/${email}/${role}`
  );
  if (endpoint.status === 200) {
    return endpoint.data;
  } else {
    return null;
  }
};

export const getPending = async (email) => {
  let endpoint = await axios.get(`${ServerAddress}/get-Pending/${email}`);
  if (endpoint.status === 200) {
    return endpoint.data;
  } else {
    return null;
  }
};

export const getPendingList = async () => {
  let endpoint = await axios.get(`${ServerAddress}/get-PendingList`);
  if (endpoint.status === 200) {
    return endpoint.data;
  } else {
    return null;
  }
};

// *********************************************All Post Request******************************

export const addFormToContactUs = async (frm) => {
  try {
    await axios.post(`${ServerAddress}/post-ContactUs`, frm);
  } catch (error) {}
};

export const addFormRole = async (frm, role) => {
  try {
    await axios.post(`${ServerAddress}/post${role}`, frm);
  } catch (error) {}
};

export const UpdateIs_Approved = async (Is_ApprovedToUpdate) => {
  try {
    await axios.post(
      `${ServerAddress}/update-Is_Approved`,
      Is_ApprovedToUpdate
    );
  } catch (error) {}
};

export const UpdateIs_Active = async (Is_ActiveToUpdate) => {
  // console.log(Is_ActiveToUpdate);
  await axios.post(`${ServerAddress}/update-Is_Active`, Is_ActiveToUpdate);
};

export const AddOrEditForm = async (frm, action, Type) => {
  try {
    await axios.post(`${ServerAddress}/post${action}/${Type}`, frm);
  } catch (error) {}
};

export const UpdateIs_send = async (Is_sendToUpdate) => {
  try {
    await axios.post(`${ServerAddress}/update-Is_send`, Is_sendToUpdate);
  } catch (error) {}
};
