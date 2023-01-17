import axios from "axios";

const ServerAddress = "http://localhost:7153/api/Users";

export const addFormToContactUs = async (frm) => {
  await axios.post(`${ServerAddress}/post-ContactUs`, frm);
};

export const addFormRole = async (frm, role) => {
  await axios.post(`${ServerAddress}/post${role}`, frm);
};

export const UpdateIs_Approved = async (Is_ApprovedToUpdate) => {
  await axios.post(`${ServerAddress}/update-Is_Approved`, Is_ApprovedToUpdate);
};

export const UpdateIs_Active = async (Is_ActiveToUpdate) => {
  // console.log(Is_ActiveToUpdate);
  await axios.post(`${ServerAddress}/update-Is_Active`, Is_ActiveToUpdate);
};

export const AddOrEditForm = async (frm, action, Type) => {
  // console.log(frm);
  // console.log(action);
  // console.log(Type);
  await axios.post(`${ServerAddress}/post${action}/${Type}`, frm);
};

export const sendToOrderDetails = async (Order, UnitsInStock) => {
  console.log(8, Order, UnitsInStock);
  await axios.post(
    `${ServerAddress}/post-sendToOrderDetails/${UnitsInStock}`,
    Order
  );
};

export const UpdateIs_send = async (Is_sendToUpdate) => {
  await axios.post(`${ServerAddress}/update-Is_send`, Is_sendToUpdate);
};

export const AddTweetToDB = async (Tweet, SA_code) => {
  await axios.post(`${ServerAddress}/Post-tweet/${SA_code}`, Tweet);
};
