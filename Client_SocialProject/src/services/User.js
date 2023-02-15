import axios from "axios";

const ServerAddress = "http://localhost:7153/api/Users";

// *********************************************All Get Request*******************************
export const getRolesData = async (userId) => {
  try {
    let endpoint = await axios.get(`${ServerAddress}/get-RolesData/${userId}`);
    if (endpoint.status === 200) {
      return endpoint.data;
    } else {
      return null;
    }
  } catch (error) {
    console.log(
      `An Exception occurred while initializing the getRolesData Service : ${error}`
    );
    console.error(error);
  }
};

export const getUserInfoData = async (email, role) => {
  try {
    let endpoint = await axios.get(
      `${ServerAddress}/get-UserInfoData/${email}/${role}`
    );
    if (endpoint.status === 200) {
      return endpoint.data;
    } else {
      return null;
    }
  } catch (error) {
    console.log(
      `An Exception occurred while initializing the getUserInfoData Service : ${error}`
    );
    console.error(error);
  }
};

export const getPending = async (email) => {
  try {
    let endpoint = await axios.get(`${ServerAddress}/get-Pending/${email}`);
    if (endpoint.status === 200) {
      return endpoint.data;
    } else {
      return null;
    }
  } catch (error) {
    console.log(
      `An Exception occurred while initializing the getPending Service : ${error}`
    );
    console.error(error);
  }
};

export const getPendingList = async () => {
  try {
    let endpoint = await axios.get(`${ServerAddress}/get-PendingList`);
    if (endpoint.status === 200) {
      return endpoint.data;
    } else {
      return null;
    }
  } catch (error) {
    console.log(
      `An Exception occurred while initializing the getPendingList Service : ${error}`
    );
    console.error(error);
  }
};

// *********************************************All Post Request******************************

export const addFormToContactUs = async (frm) => {
  try {
    await axios.post(`${ServerAddress}/post-ContactUs`, frm);
  } catch (error) {
    console.log(
      `An Exception occurred while initializing the addFormToContactUs Service : ${error}`
    );
    console.error(error);
  }
};

export const addFormRole = async (frm, role) => {
  try {
    await axios.post(`${ServerAddress}/post${role}`, frm);
  } catch (error) {
    console.log(
      `An Exception occurred while initializing the addFormRole Service : ${error}`
    );
    console.error(error);
  }
};

export const UpdateIs_Approved = async (Is_ApprovedToUpdate) => {
  try {
    await axios.post(
      `${ServerAddress}/update-Is_Approved`,
      Is_ApprovedToUpdate
    );
  } catch (error) {
    console.log(
      `An Exception occurred while initializing the UpdateIs_Approved Service : ${error}`
    );
    console.error(error);
  }
};

export const UpdateIs_Active = async (Is_ActiveToUpdate) => {
  try {
    await axios.post(`${ServerAddress}/update-Is_Active`, Is_ActiveToUpdate);
  } catch (error) {
    console.log(
      `An Exception occurred while initializing the UpdateIs_Active Service : ${error}`
    );
    console.error(error);
  }
};

export const AddOrEditForm = async (frm, action, Type) => {
  try {
    await axios.post(`${ServerAddress}/post${action}/${Type}`, frm);
  } catch (error) {
    console.log(
      `An Exception occurred while initializing the UpdateIs_Active Service : ${error}`
    );
    console.error(error);
  }
};

export const UpdateIs_send = async (Is_sendToUpdate) => {
  try {
    await axios.post(`${ServerAddress}/update-Is_send`, Is_sendToUpdate);
  } catch (error) {
    console.log(
      `An Exception occurred while initializing the UpdateIs_Active Service : ${error}`
    );
    console.error(error);
  }
};
