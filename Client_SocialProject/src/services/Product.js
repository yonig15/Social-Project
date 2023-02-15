import axios from "axios";

const ServerAddress = "http://localhost:7153/api/Product";

// *********************************************All Get Request*******************************
export const getAllMyProduct = async (SA_Code) => {
  try {
    let endpoint = await axios.get(
      `${ServerAddress}/get-AllMyProduct/${SA_Code}`
    );
    if (endpoint.status === 200) {
      return endpoint.data;
    } else {
      return null;
    }
  } catch (error) {
    console.log(
      `An Exception occurred while initializing the getAllMyProduct Service : ${error}`
    );
    console.error(error);
  }
};

export const getProductPerCompany = async (BC_Code) => {
  try {
    let endpoint = await axios.get(
      `${ServerAddress}/get-ProductPerCompany/${BC_Code}`
    );
    if (endpoint.status === 200) {
      return endpoint.data;
    } else {
      return null;
    }
  } catch (error) {
    console.log(
      `An Exception occurred while initializing the getProductPerCompany Service : ${error}`
    );
    console.error(error);
  }
};

export const getProductListForActivist = async (Campaign_code) => {
  try {
    let endpoint = await axios.get(
      `${ServerAddress}/get-ProductListForActivist/${Campaign_code}`
    );
    if (endpoint.status === 200) {
      return endpoint.data;
    } else {
      return null;
    }
  } catch (error) {}
};

export const getOrderDetail = async (BC_Code) => {
  try {
    let endpoint = await axios.get(
      `${ServerAddress}/get-OrderDetail/${BC_Code}`
    );
    if (endpoint.status === 200) {
      return endpoint.data;
    } else {
      return null;
    }
  } catch (error) {
    console.log(
      `An Exception occurred while initializing the getOrderDetail Service : ${error}`
    );
    console.error(error);
  }
};

// *********************************************All Post Request******************************

export const sendToOrderDetails = async (Order, UnitsInStock) => {
  try {
    await axios.post(
      `${ServerAddress}/post-sendToOrderDetails/${UnitsInStock}`,
      Order
    );
  } catch (error) {
    console.log(
      `An Exception occurred while initializing the getOrderDetail Service : ${error}`
    );
    console.error(error);
  }
};

// *********************************************All Delete Request******************************
export const DeleteProduct = async (ProductId) => {
  try {
    await axios.delete(`${ServerAddress}/delete-CompanyProduct/${ProductId}`);
  } catch (error) {
    console.log(
      `An Exception occurred while initializing the getOrderDetail Service : ${error}`
    );
    console.error(error);
  }
};
