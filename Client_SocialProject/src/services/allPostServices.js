import axios from "axios";

const ServerAddress = "http://localhost:7153/api/Users";

export const addFormToContactUs = async (frm) => {
  await axios.post(`${ServerAddress}/post`, frm);
};

export const addFormRole = async (frm) => {
  await axios.post(`${ServerAddress}/post`, frm);
};

export const UpdateProduct = async (ProductToUpdate) => {
  await axios.post(`${ServerAddress}/update`, ProductToUpdate);
  console.log(ProductToUpdate);
};
