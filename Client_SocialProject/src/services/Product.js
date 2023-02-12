import axios from "axios";

const ServerAddress = "http://localhost:7153/api/Product";

// *********************************************All Get Request*******************************
export const getAllMyProduct = async (SA_Code) => {
  let endpoint = await axios.get(
    `${ServerAddress}/get-AllMyProduct/${SA_Code}`
  );
  if (endpoint.status === 200) {
    return endpoint.data;
  } else {
    return null;
  }
};

export const getProductPerCompany = async (BC_Code) => {
  console.log(10, BC_Code);
  let endpoint = await axios.get(
    `${ServerAddress}/get-ProductPerCompany/${BC_Code}`
  );
  if (endpoint.status === 200) {
    return endpoint.data;
  } else {
    return null;
  }
};

export const getProductListForActivist = async (Campaign_code) => {
  let endpoint = await axios.get(
    `${ServerAddress}/get-ProductListForActivist/${Campaign_code}`
  );
  if (endpoint.status === 200) {
    return endpoint.data;
  } else {
    return null;
  }
};

export const getOrderDetail = async (BC_Code) => {
  console.log(55, BC_Code);
  let endpoint = await axios.get(`${ServerAddress}/get-OrderDetail/${BC_Code}`);
  if (endpoint.status === 200) {
    return endpoint.data;
  } else {
    return null;
  }
};

// *********************************************All Post Request******************************

export const sendToOrderDetails = async (Order, UnitsInStock) => {
  try {
    await axios.post(
      `${ServerAddress}/post-sendToOrderDetails/${UnitsInStock}`,
      Order
    );
  } catch (error) {}
};

// *********************************************All Delete Request******************************
export const DeleteProduct = async (ProductId) => {
  try {
    await axios.delete(`${ServerAddress}/delete-CompanyProduct/${ProductId}`);
  } catch (error) {
    console.error(error);
  }
};
