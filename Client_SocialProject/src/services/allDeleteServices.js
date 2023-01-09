import axios from "axios";

const ServerAddress = "http://localhost:7153/api/Users";

export const deleteProduct = async (ProductId) => {
  try {
    await axios.delete(`${ServerAddress}/delete/${ProductId}`);
  } catch (error) {
    console.error(error);
  }
};
